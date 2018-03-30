using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayRefundQueryBackContent : AlipayPostBackContent, IRefundQueryBackContent
    {
        public AlipayRefundQueryBackContent(string json)
            : base(json)
        {
        }

        public string OrderNo => this["out_trade_no"];
        public string PlatformTradeNo => this["trade_no"];
        public string RefundTradeNo => this["out_request_no"];

        public decimal OrderAmount
        {
            get
            {
                decimal.TryParse(this["total_amount"], out var result);
                return result;
            }
        }
        public decimal RefundFee
        {
            get
            {
                decimal.TryParse(this["refund_amount"], out var result);
                return result;
            }
        }
    }
}
