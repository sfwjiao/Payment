using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayRefundRequest : AlipayPostRequest<IRefundOrder, IRefundBackContent>, IRefundRequest
    {
        public AlipayRefundRequest(IGateWay gateWay) : base(gateWay) { }
        protected override IPostRequestContent CreateContent(IRefundOrder obj)
        {
            return new AlipayRefundRequestContent(GateWay, obj);
        }

        protected override IRefundBackContent Load(string backstr)
        {
            return new AlipayRefundBackContent(backstr);
        }
    }
}
