using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayWebPayRequest<TOrder> : AlipayHtmlRequest<TOrder>, IWebPayRequest<TOrder> where TOrder : IReturnOrder
    {
        public AlipayWebPayRequest(IGateWay gateWay) : base(gateWay) { }
        protected override IRequestContent CreateContent(TOrder order)
        {
            return new AlipayWebPayRequestContent(GateWay, order);
        }
    }
}
