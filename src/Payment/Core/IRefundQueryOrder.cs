namespace Payment.Core
{
    /// <summary>
    /// 退款查询订单
    /// </summary>
    public interface IRefundQueryOrder : IPlatformOrder
    {
        /// <summary>
        /// 退款流水号
        /// </summary>
        string RefundTradeNo { get; }
    }
}
