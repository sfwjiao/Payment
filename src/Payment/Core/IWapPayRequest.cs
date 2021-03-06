﻿namespace Payment.Core
{
    /// <summary>
    /// 手机网站支付请求
    /// </summary>
    public interface IWapPayRequest<TOrder> : IHtmlRequest<TOrder> where TOrder : IOrder
    {
    }
}
