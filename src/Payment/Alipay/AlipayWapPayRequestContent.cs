using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayWapPayRequestContent : AlipayRequestContent
    {
        /// <summary>
        /// HTTP/HTTPS开头字符串
        /// </summary>
        [MaxLength(256), DisplayName("return_url")]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 支付宝服务器主动通知商户服务器里指定的页面http/https路径
        /// </summary>
        [MaxLength(256), DisplayName("notify_url")]
        public string NotifyUrl { get; set; }

        public AlipayWapPayRequestContent(IGateWay gateWay, IReturnOrder order)
            : base(gateWay)
        {
            ReturnUrl = order.ReturnUrl;

            if (string.IsNullOrEmpty(order.NotifyUrl)) throw new PaymentArgumentException(gateWay.Name, "notify_url", "notify_url参数错误");
            NotifyUrl = order.NotifyUrl;

            if (string.IsNullOrEmpty(order.Subject)) throw new PaymentArgumentException(gateWay.Name, "subject", "subject参数错误");
            this["subject"] = order.Subject;

            if (string.IsNullOrEmpty(order.OrderNo)) throw new PaymentArgumentException(gateWay.Name, "out_trade_no", "out_trade_no参数错误");
            this["out_trade_no"] = order.OrderNo;

            if (order.Price <= 0) throw new PaymentArgumentException(gateWay.Name, "total_amount", "total_amount参数错误");

            this["total_amount"] = order.Price.ToString(CultureInfo.InvariantCulture);
            this["product_code"] = "QUICK_WAP_WAY";
        }

        public override string Method => "alipay.trade.wap.pay";
    }
}
