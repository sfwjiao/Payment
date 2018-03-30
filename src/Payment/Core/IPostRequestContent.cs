namespace Payment.Core
{
    public interface IPostRequestContent : IRequestContent
    {
        /// <summary>
        /// 请求参数字符串
        /// </summary>
        string RequestPostData { get; }
    }
}
