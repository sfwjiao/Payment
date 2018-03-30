using System;
using System.Collections.Generic;
using Payment.Core;
using Payment.Exceptions;

namespace Payment.Alipay
{
    /// <summary>
    /// 支付宝支付网关
    /// </summary>
    public class AlipayGateWay : IGateWay
    {
        /// <summary>
        /// 设置参数事件
        /// </summary>
        public Action<IRequest, SettingParamatersEventArgs> SettingParamaters { get; set; }

        //支付宝商户数据
        private MerchantConfigure _merchantConfigure;

        private static IDictionary<Type, Type> _requestHandler;
        /// <summary>
        /// 请求处理对象的容器，保存每个接口的具体实现类型
        /// </summary>
        protected IDictionary<Type, Type> RequestHandler
        {
            get
            {
                if (_requestHandler != null) return _requestHandler;

                _requestHandler = new Dictionary<Type, Type>
                {
                    {typeof(IWapPayRequest), typeof(AlipayWapPayRequest)},
                };

                return _requestHandler;
            }
        }

        public AlipayGateWay(AlipayMerchantConfigure merchantConfigure)
        {
            _merchantConfigure = merchantConfigure;
        }
        
        public IMerchantConfigure Merchant
        {
            get => _merchantConfigure;
            set => _merchantConfigure = value as AlipayMerchantConfigure;
        }

        public void InjectRequest<TInterface, T>() where TInterface : IRequest where T : class, TInterface, new()
        {
            var interfaceType = typeof(TInterface);
            var implType = typeof(T);

            if (RequestHandler.ContainsKey(interfaceType))
            {
                RequestHandler[interfaceType] = implType;
            }
            else
            {
                RequestHandler.Add(interfaceType, implType);
            }
        }

        public T GetRequest<T>() where T : IRequest
        {
            var interfaceType = typeof(T);
            if(!RequestHandler.ContainsKey(interfaceType)) throw new NotImplementedRequestException(interfaceType);

            var implType = RequestHandler[interfaceType];

            var impl = implType.Assembly.CreateInstance(implType.FullName);
            if(impl == null) throw new NotImplementedRequestException($"未能正确实例化类型{implType.FullName}", interfaceType);
            if(!(impl is T request)) throw new NotImplementedRequestException($"未能正确实例化类型{implType.FullName}", interfaceType);

            request.MerchantConfigure = _merchantConfigure;
            if (SettingParamaters != null) request.SettingParamaters += SettingParamaters;

            return request;
        }
    }
}
