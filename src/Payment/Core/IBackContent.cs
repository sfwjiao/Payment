namespace Payment.Core
{
    /// <summary>
    /// 接口返回数据
    /// </summary>
    public interface IBackContent : IContent
    {
        /// <summary>
        /// 参数正文
        /// </summary>
        string Body { get; }

        /// <summary>
        /// 签名类型
        /// </summary>
        string SignType { get; }

        /// <summary>
        /// 签名
        /// </summary>
        string Sign { get; }
    }
}
