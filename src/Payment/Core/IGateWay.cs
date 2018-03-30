using System;

namespace Payment.Core
{
    /// <summary>
    /// 支付平台，支付网关
    /// </summary>
    public interface IGateWay
    {
        /// <summary>
        /// 平台名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 商户配置信息
        /// </summary>
        IMerchantConfigure MerchantConfigure { get; set; }

        /// <summary>
        /// 注入请求类型
        /// </summary>
        /// <typeparam name="TInterface">请求类型接口</typeparam>
        /// <typeparam name="T">注入的类型</typeparam>
        void InjectRequest<TInterface, T>(string requestName = null)
            where TInterface : IRequest
            where T : class, TInterface;

        /// <summary>
        /// 获取请求处理对象
        /// </summary>
        /// <typeparam name="T">请求处理类型</typeparam>
        /// <param name="requestName">请求名称</param>
        /// <returns></returns>
        T GetRequest<T>(string requestName = null) where T : IRequest;

        /// <summary>
        /// 获取请求处理对象
        /// </summary>
        /// <param name="type">请求处理类型</param>
        /// <param name="requestName">请求名称</param>
        /// <returns></returns>
        IRequest GetRequest(Type type, string requestName = null);
    }
}
