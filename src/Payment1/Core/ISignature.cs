using System;

namespace Payment.Core
{
    /// <summary>
    /// 签名器
    /// </summary>
    public interface ISignature
    {
        /// <summary>
        /// 对请求进行签名
        /// </summary>
        /// <param name="content">请求正文</param>
        /// <returns></returns>
        string Sign(IRequestContent content);

        /// <summary>
        /// 验证返回是否可信
        /// </summary>
        /// <param name="content">返回正文</param>
        /// <returns></returns>
        bool Verify(IBackContent content);
    }
}
