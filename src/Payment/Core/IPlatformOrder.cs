namespace Payment.Core
{
    /// <summary>
    /// 平台订单
    /// </summary>
    public interface IPlatformOrder : IRequestParamaters
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        string OrderNo { get; }


        /// <summary>
        /// 第三方平台交易流水号
        /// </summary>
        string PlatformTradeNo { get; }
    }
}
