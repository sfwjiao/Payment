using System;
using Payment.Core;
using Payment.Exceptions;

namespace Payment.Alipay
{
    public class AlipayRequest : IRequest
    {
        /// <summary>
        /// 设置参数事件
        /// </summary>
        public Action<IRequest, SettingParamatersEventArgs> SettingParamaters { get; set; }

        /// <summary>
        /// 请求网关地址
        /// </summary>
        protected string GateWayUrl => IsDebug ? "https://openapi.alipaydev.com/gateway.do" : "https://openapi.alipay.com/gateway.do";

        private IMerchantConfigure _merchantConfigure;
        /// <summary>
        /// 商户信息
        /// </summary>
        public IMerchantConfigure MerchantConfigure
        {
            protected get { return _merchantConfigure; }
            set
            {
                _merchantConfigure = value;
                if (!(_merchantConfigure is AlipayMerchantConfigure alipayMerchantConfigure)) throw new PaymentException("商户信息错误");

                Signature = new AlipaySignature(alipayMerchantConfigure);
            }
        }

        public bool IsDebug { protected get; set; }

        protected AlipaySignature Signature { get; set; }
    }
}
