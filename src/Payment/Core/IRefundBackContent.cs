using System;

namespace Payment.Core
{
    /// <summary>
    /// 退款返回正文数据
    /// </summary>
    public interface IRefundBackContent : IPostBackContent
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
        /// 退款总金额
        /// </summary>
        decimal RefundFee { get; }

        /// <summary>
        /// 退款时间
        /// </summary>
        DateTime? RefundTime { get; }

        /// <summary>
        /// 是否退款成功
        /// </summary>
        bool IsSuccessRefund { get; }
    }
}
