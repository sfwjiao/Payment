using System.Globalization;
using Payment.Core;
using Payment.Exceptions;

namespace Payment.Alipay
{
    public class AlipayWapPayRequestContent : AlipayRequestContent
    {
        public AlipayWapPayRequestContent(IMerchantConfigure merchantConfigure, IOrder order) : base(merchantConfigure)
        {

            if (string.IsNullOrEmpty(order.Subject)) throw new PaymentArgumentException("subject参数错误", "subject");
            BizContentParamaters.Add("subject", order.Subject);

            if (string.IsNullOrEmpty(order.OrderNo)) throw new PaymentArgumentException("out_trade_no参数错误", "out_trade_no");
            BizContentParamaters.Add("out_trade_no", order.OrderNo);

            if (order.Price <= 0) throw new PaymentArgumentException("total_amount参数错误", "total_amount");
            BizContentParamaters.Add("total_amount", order.Price.ToString(CultureInfo.InvariantCulture));
        }

        public override string Method => "alipay.trade.wap.pay";
    }
}
