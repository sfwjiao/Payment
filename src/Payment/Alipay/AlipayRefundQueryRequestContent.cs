using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayRefundQueryRequestContent : AlipayPostRequestContent
    {
        public AlipayRefundQueryRequestContent(IGateWay gateWay, IRefundQueryOrder order)
            : base(gateWay)
        {
            if (string.IsNullOrEmpty(order.OrderNo) && string.IsNullOrEmpty(order.PlatformTradeNo)) throw new PaymentArgumentException(gateWay.Name, "out_trade_no,trade_no", "参数错误out_trade_no和trade_no不能同时为空");
            if (string.IsNullOrEmpty(order.RefundTradeNo)) throw new PaymentArgumentException(gateWay.Name, "out_request_no", "参数错误out_request_no");
            if (!string.IsNullOrEmpty(order.OrderNo)) this["out_trade_no"] = order.OrderNo;
            if (!string.IsNullOrEmpty(order.PlatformTradeNo)) this["trade_no"] = order.PlatformTradeNo;
            this["out_request_no"] = order.RefundTradeNo;
        }

        public override string Method => "alipay.trade.fastpay.refund.query";
    }
}
