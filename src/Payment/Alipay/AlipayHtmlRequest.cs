using Payment.Core;

namespace Payment.Alipay
{
    public abstract class AlipayHtmlRequest<T> : HtmlRequest<T> where T : IRequestParamaters
    {
        protected AlipayHtmlRequest(IGateWay gateWay) : base(gateWay) { }

        protected override string GetActionUrl(IContent content)
        {
            if (!(content is AlipayRequestContent webpayContent)) throw new PaymentException(GateWay.Name, "请求正文类型错误，必须继承自AlipayRequestContent类型");

            return $"{(IsDebug ? "https://openapi.alipaydev.com/gateway.do" : "https://openapi.alipay.com/gateway.do")}?charset={webpayContent.Charset}";
        }

        protected override ISignature Signature => new AlipaySignature(GateWay);

        public override INotify Notify => new AlipayNotify(GateWay);
    }
}
