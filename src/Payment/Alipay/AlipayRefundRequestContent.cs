using System.Globalization;
using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayRefundRequestContent : AlipayPostRequestContent
    {
        public AlipayRefundRequestContent(IGateWay gateWay, IRefundOrder order)
            : base(gateWay)
        {
            if (string.IsNullOrEmpty(order.OrderNo) && string.IsNullOrEmpty(order.PlatformTradeNo)) throw new PaymentArgumentException(gateWay.Name, "out_trade_no,trade_no", "参数错误out_trade_no和trade_no不能同时为空");
            if (order.RefundAmount <= 0) throw new PaymentArgumentException(gateWay.Name, "refund_amount", "参数错误refund_amount");
            if (!string.IsNullOrEmpty(order.OrderNo)) this["out_trade_no"] = order.OrderNo;
            if (!string.IsNullOrEmpty(order.PlatformTradeNo)) this["trade_no"] = order.PlatformTradeNo;
            this["refund_amount"] = order.RefundAmount.ToString(CultureInfo.InvariantCulture);
        }

        public override string Method => "alipay.trade.refund";
    }
}
