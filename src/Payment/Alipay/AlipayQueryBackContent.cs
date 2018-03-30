using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayQueryBackContent : AlipayPostBackContent, IQueryBackContent
    {
        public AlipayQueryBackContent(string json) : base(json) { }

        public string Status => this["trade_status"];

        public string OrderNo => this["out_trade_no"];

        public string PlatformTradeNo => this["trade_no"];

        public bool IsSuccessPay => this["trade_status"] == "TRADE_SUCCESS";

        public decimal TotalAmount
        {
            get
            {
                decimal.TryParse(this["total_amount"], out var result);
                return result;
            }
        }
    }
}
