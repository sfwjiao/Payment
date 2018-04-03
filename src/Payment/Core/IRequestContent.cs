using System.Text;

namespace Payment.Core
{
    /// <summary>
    /// 请求正文
    /// </summary>
    public interface IRequestContent : IContent
    {
        /// <summary>
        /// 签名类型
        /// </summary>
        string SignType { get; set; }

        /// <summary>
        /// 编码格式
        /// </summary>
        Encoding Encoding { get; }

        /// <summary>
        /// 签名
        /// </summary>
        string Sign { set; }
    }
}
