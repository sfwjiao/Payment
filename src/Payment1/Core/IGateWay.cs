namespace Payment.Core
{
    /// <summary>
    /// 支付平台，支付网关
    /// </summary>
    public interface IGateWay
    {
        IMerchantConfigure Merchant { get; set; }

        /// <summary>
        /// 注入请求类型
        /// </summary>
        /// <typeparam name="TInterface">请求类型接口</typeparam>
        /// <typeparam name="T">注入的类型</typeparam>
        void InjectRequest<TInterface, T>() where TInterface : IRequest where T : class, TInterface, new();

        /// <summary>
        /// 获取请求处理对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetRequest<T>() where T : IRequest;
    }
}
