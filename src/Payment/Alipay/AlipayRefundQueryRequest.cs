using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayRefundQueryRequest : AlipayPostRequest<IRefundQueryOrder, IRefundQueryBackContent>, IRefundQueryRequest
    {
        public AlipayRefundQueryRequest(IGateWay gateWay) : base(gateWay) { }

        protected override IPostRequestContent CreateContent(IRefundQueryOrder obj)
        {
            return new AlipayRefundQueryRequestContent(GateWay, obj);
        }

        protected override IRefundQueryBackContent Load(string backstr)
        {
            return new AlipayRefundQueryBackContent(backstr);
        }
    }
}
