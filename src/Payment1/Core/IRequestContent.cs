using System.Collections.Generic;
using System.Text;

namespace Payment.Core
{
    /// <summary>
    /// 请求正文
    /// </summary>
    public interface IRequestContent
    {
        /// <summary>
        /// 签名类型
        /// </summary>
        string SignType { get; }

        /// <summary>
        /// 编码格式
        /// </summary>
        Encoding Encoding { get; }

        /// <summary>
        /// 签名源字符串
        /// </summary>
        string SignOrigin { get; }

        /// <summary>
        /// 签名
        /// </summary>
        string Sign { set; }

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <param name="index">参数名</param>
        /// <returns></returns>
        string this[string index] { get; set; }

        /// <summary>
        /// 请求参数集合
        /// </summary>
        IEnumerable<KeyValuePair<string, string>> Paramaters { get; }
    }
}
