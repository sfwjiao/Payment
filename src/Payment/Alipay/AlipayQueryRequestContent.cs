using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayQueryRequestContent : AlipayPostRequestContent
    {
        public AlipayQueryRequestContent(IGateWay gateWay, IPlatformOrder order)
            : base(gateWay)
        {
            if (string.IsNullOrEmpty(order.OrderNo) && string.IsNullOrEmpty(order.PlatformTradeNo)) throw new PaymentArgumentException(gateWay.Name, "out_trade_no,trade_no", "参数错误out_trade_no和trade_no不能同时为空");
            if (!string.IsNullOrEmpty(order.OrderNo)) this["out_trade_no"] = order.OrderNo;
            if (!string.IsNullOrEmpty(order.PlatformTradeNo)) this["trade_no"] = order.PlatformTradeNo;
        }

        public override string Method => "alipay.trade.query";
    }
}
