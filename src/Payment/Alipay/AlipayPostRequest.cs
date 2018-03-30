using Payment.Core;

namespace Payment.Alipay
{
    public abstract class AlipayPostRequest<T, TPostBackContent> : PostRequest<T, TPostBackContent>
        where TPostBackContent : IPostBackContent
        where T : IRequestParamaters
    {
        protected AlipayPostRequest(IGateWay gateWay) : base(gateWay) { }

        protected override string GetActionUrl(IContent content)
        {
            if (!(content is AlipayRequestContent queryRequestContent)) throw new PaymentException(GateWay.Name, "请求正文类型错误，必须继承自AlipayRequestContent类型");

            return $"{(IsDebug ? "https://openapi.alipaydev.com/gateway.do" : "https://openapi.alipay.com/gateway.do")}?charset={queryRequestContent.Charset}";
        }

        protected override ISignature Signature => new AlipaySignature(GateWay);
    }
}
