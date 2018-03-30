using System;
using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayRefundBackContent : AlipayPostBackContent, IRefundBackContent
    {
        public AlipayRefundBackContent(string json)
            : base(json)
        {
        }

        public string OrderNo => this["out_trade_no"];

        public string PlatformTradeNo => this["trade_no"];

        public string RefundTradeNo => this["trade_no"];

        public decimal RefundFee
        {
            get
            {
                decimal.TryParse(this["refund_fee"], out var result);
                return result;
            }
        }

        public DateTime? RefundTime
        {
            get
            {
                var success = DateTime.TryParse(this["gmt_refund_pay"], out var result);
                return success ? (DateTime?)result : null;
            }
        }

        public bool IsSuccessRefund => this["fund_change"] == "Y";
    }
}
