using System;

namespace Payment.Core
{
    /// <summary>
    /// 网关基类
    /// </summary>
    public class GateWay : IGateWay
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商户配置信息
        /// </summary>
        public IMerchantConfigure MerchantConfigure { get; set; }

        public GateWay(IMerchantConfigure merchantConfigure)
        {
            MerchantConfigure = merchantConfigure;
        }

        public GateWay(IMerchantConfigure merchantConfigure, string name)
        {
            MerchantConfigure = merchantConfigure;
            Name = name;
        }

        /// <summary>
        /// 注入请求类型
        /// </summary>
        /// <typeparam name="TInterface">请求类型接口</typeparam>
        /// <typeparam name="TImpl">注入的类型</typeparam>
        public void InjectRequest<TInterface, TImpl>(string requestName = null)
            where TInterface : IRequest
            where TImpl : class, TInterface
        {
            var implName = requestName ?? typeof(TInterface).FullName;
            RequestHandler.AddOrUpdate<TInterface, TImpl>(Name, implName);
        }

        /// <summary>
        /// 获取请求处理对象
        /// </summary>
        /// <typeparam name="T">请求处理类型</typeparam>
        /// <param name="requestName">请求名称</param>
        /// <returns></returns>
        public T GetRequest<T>(string requestName = null) where T : IRequest
        {
            var implName = requestName ?? typeof(T).FullName;
            return RequestHandler.Get<T>(Name, implName, new object[] { this });
        }

        /// <summary>
        /// 获取请求处理对象
        /// </summary>
        /// <param name="type">请求处理类型</param>
        /// <param name="requestName">请求名称</param>
        /// <returns></returns>
        public IRequest GetRequest(Type type, string requestName = null)
        {
            var implName = requestName ?? type.FullName;
            return RequestHandler.Get(type, Name, implName, new object[] {this});
        }
    }
}
