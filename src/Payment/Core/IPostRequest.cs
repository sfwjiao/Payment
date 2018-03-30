using System;

namespace Payment.Core
{
    /// <summary>
    /// 使用post方式提交请求，获取响应并解析结果的请求方式
    /// </summary>
    public interface IPostRequest<T, out TPostBackContent> : IRequest where TPostBackContent : IPostBackContent
    {
        /// <summary>
        /// 获取响应数据
        /// </summary>
        /// <returns></returns>
        TPostBackContent GetBack(T obj, Action<IPostRequestContent, T> otherSet = null);
    }
}