using System.Collections.Generic;

namespace Payment.Core
{
    /// <summary>
    /// 正文基类
    /// 使用Dictionary方式存储正文信息
    /// </summary>
    public abstract class Content : IContent
    {
        /// <summary>
        /// 参数字典
        /// </summary>
        protected IDictionary<string, string> ParamaterDictionary { get; set; }

        protected Content()
        {
            ParamaterDictionary = new Dictionary<string, string>();
        }

        /// <summary>
        /// 读取或设置参数值
        /// 读取时参数不存在返回空
        /// 设置时参数不存在则创建参数
        /// </summary>
        /// <param name="index">参数名</param>
        /// <returns></returns>
        public virtual string this[string index]
        {
            get => ParamaterDictionary.ContainsKey(index) ? ParamaterDictionary[index] : null;
            set => AddOrUpdate(index, value);
        }

        /// <summary>
        /// 添加参数
        /// 参数已存在则修改参数值
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        public virtual void AddOrUpdate(string key, string value)
        {
            if (ParamaterDictionary.ContainsKey(key))
            {
                ParamaterDictionary[key] = value;
            }
            else
            {
                ParamaterDictionary.Add(key, value);
            }
        }

        /// <summary>
        /// 删除参数
        /// </summary>
        /// <param name="key">参数名</param>
        public virtual void Remove(string key)
        {
            if (ParamaterDictionary.ContainsKey(key)) ParamaterDictionary.Remove(key);
        }

        /// <summary>
        /// 请求参数集合
        /// </summary>
        public virtual IEnumerable<KeyValuePair<string, string>> Paramaters => ParamaterDictionary;
    }
}
