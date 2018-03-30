namespace Payment.Core
{
    /// <summary>
    /// 电脑网站支付请求
    /// </summary>
    public interface IWebPayRequest<TOrder> : IHtmlRequest<TOrder> where TOrder : IOrder
    {
    }
}
