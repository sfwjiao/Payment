using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayQueryRequest : AlipayPostRequest<IPlatformOrder, IQueryBackContent>, IQueryRequest
    {
        public AlipayQueryRequest(IGateWay gateWay) : base(gateWay) { }

        protected override IPostRequestContent CreateContent(IPlatformOrder obj)
        {
            return new AlipayQueryRequestContent(GateWay, obj);
        }

        protected override IQueryBackContent Load(string backstr)
        {
            return new AlipayQueryBackContent(backstr);
        }
    }
}
