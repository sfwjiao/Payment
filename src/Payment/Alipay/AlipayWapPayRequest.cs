using Payment.Core;

namespace Payment.Alipay
{
    /// <summary>
    /// 支付宝手机网站支付
    /// </summary>
    public class AlipayWapPayRequest<TOrder> : AlipayHtmlRequest<TOrder>, IWapPayRequest<TOrder> where TOrder : IReturnOrder
    {
        public AlipayWapPayRequest(IGateWay gateWay) : base(gateWay) { }
        protected override IRequestContent CreateContent(TOrder order)
        {
            return new AlipayWapPayRequestContent(GateWay, order);
        }
    }
}
