namespace Payment.Core
{
    /// <summary>
    /// 通知正文数据
    /// </summary>
    public interface INotifyContent : IBackContent
    {
        /// <summary>
        /// 商户编号
        /// </summary>
        string MerchantId { get; }

        /// <summary>
        /// 状态码
        /// </summary>
        string Status { get; }

        /// <summary>
        /// 订单号
        /// </summary>
        string OrderNo { get; }

        /// <summary>
        /// 第三方平台交易流水号
        /// </summary>
        string PlatformTradeNo { get; }

        /// <summary>
        /// 交易是否成功
        /// </summary>
        bool IsSuccessPay { get; }

        /// <summary>
        /// 交易总金额
        /// </summary>
        decimal TotalAmount { get; }
    }
}
