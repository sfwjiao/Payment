namespace Payment.Core
{
    public interface IRefundQueryBackContent : IPostBackContent
    {
        /// <summary>
        /// 订单号
        /// </summary>
        string OrderNo { get; }

        /// <summary>
        /// 第三方平台交易流水号
        /// </summary>
        string PlatformTradeNo { get; }

        /// <summary>
        /// 退款流水号
        /// </summary>
        string RefundTradeNo { get; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        decimal OrderAmount { get; }

        /// <summary>
        /// 退款总金额
        /// </summary>
        decimal RefundFee { get; }
    }
}
