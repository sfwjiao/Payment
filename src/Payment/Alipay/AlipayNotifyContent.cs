using System.Linq;
using System.Web;
using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayNotifyContent : AlipayBackContent, INotifyContent
    {
        protected IParamaterAnalyzer ParamaterAnalyzer => new UrlParamaterAnalyzer();

        public AlipayNotifyContent(HttpContext context)
        {
            var body = context.Request.Form.AllKeys.Aggregate("", (current, key) => current + $"{key}={context.Request.Form[key]}&");
            if (context.Request.Form.Count > 0) Body = body.TrimEnd('&');

            ParamaterDictionary = ParamaterAnalyzer.Invoke(Body);
        }

        public AlipayNotifyContent(HttpContextBase context)
        {
            var body = context.Request.Form.AllKeys.Aggregate("", (current, key) => current + $"{key}={context.Request.Form[key]}&");
            if (context.Request.Form.Count > 0) Body = body.TrimEnd('&');

            ParamaterDictionary = ParamaterAnalyzer.Invoke(Body);
        }

        public string MerchantId => this["app_id"];

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
