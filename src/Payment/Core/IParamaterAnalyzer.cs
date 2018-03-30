using System.Collections.Generic;

namespace Payment.Core
{
    /// <summary>
    /// 参数解析器
    /// </summary>
    public interface IParamaterAnalyzer
    {
        /// <summary>
        /// 将字符串解析为字典
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        IDictionary<string, string> Invoke(string body);
    }
}
