using System;

namespace Payment.Core
{
    /// <summary>
    /// 使用html跳转的请求方式
    /// </summary>
    public interface IHtmlRequest<T> : IRequest, INeedNotifyRequest where T : IRequestParamaters
    {
        /// <summary>
        /// 获取html内容
        /// </summary>
        /// <returns></returns>
        string GetHtml(T order, Action<IRequestContent, T> otherSet = null);
    }
}