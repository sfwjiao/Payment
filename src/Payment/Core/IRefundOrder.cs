namespace Payment.Core
{
    /// <summary>
    /// 退款订单
    /// </summary>
    public interface IRefundOrder : IPlatformOrder
    {
        /// <summary>
        /// 退款金额，单位元
        /// </summary>
        decimal RefundAmount { get; }
    }
}
