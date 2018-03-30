using System.Web;
using Payment.Core;

namespace Payment.Alipay
{
    public class AlipayNotify : Notify
    {
        public AlipayNotify(IGateWay gateWay)
            : base(gateWay)
        {
        }

        protected override ISignature Signature => new AlipaySignature(GateWay);

        protected override INotifyContent CreateNotifyContent(HttpContext httpContext)
        {
            return new AlipayNotifyContent(httpContext);
        }

        protected override INotifyContent CreateNotifyContent(HttpContextBase httpContext)
        {
            return new AlipayNotifyContent(httpContext);
        }

        public override string SuccessFlag => "success";
    }
}
