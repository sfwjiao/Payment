using System.Collections.Generic;

namespace Payment.Core
{
    public interface IContent
    {
        /// <summary>
        /// 读取或设置参数值
        /// 读取时参数不存在返回空
        /// 设置时参数不存在则创建参数
        /// </summary>
        /// <param name="index">参数名</param>
        /// <returns></returns>
        string this[string index] { get; set; }

        /// <summary>
        /// 添加参数
        /// 参数已存在则修改参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        void AddOrUpdate(string key, string value);

        /// <summary>
        /// 删除参数
        /// </summary>
        /// <param name="key">参数名</param>
        void Remove(string key);

        /// <summary>
        /// 请求参数集合
        /// </summary>
        IEnumerable<KeyValuePair<string, string>> Paramaters { get; }
    }
}
