using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Payment.Core;

namespace Payment.Alipay
{
    public abstract class AlipayRequestContent : Content, IRequestContent
    {
        protected AlipayRequestContent(IGateWay gateWay)
        {
            Format = "JSON";
            Charset = "utf-8";
            SignType = "RSA2";
            Version = "1.0";
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            AppId = gateWay.MerchantConfigure.MerchantId;
        }

        /// <summary>
        /// 支付宝分配给开发者的应用ID
        /// </summary>
        [Required, MaxLength(32), DisplayName("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 接口名称
        /// </summary>
        [Required, MaxLength(128), DisplayName("method")]
        public abstract string Method { get; }

        /// <summary>
        /// 仅支持JSON
        /// </summary>
        [MaxLength(40), DisplayName("format")]
        public string Format { get; set; }

        /// <summary>
        /// 请求使用的编码格式，如utf-8,gbk,gb2312等
        /// </summary>
        [Required, MaxLength(10), DisplayName("charset")]
        public string Charset { get; set; }

        /// <summary>
        /// 商户生成签名字符串所使用的签名算法类型，目前支持RSA2和RSA，推荐使用RSA2
        /// </summary>
        [Required, MaxLength(10), DisplayName("sign_type")]
        public string SignType { get; set; }

        /// <summary>
        /// 发送请求的时间，格式"yyyy-MM-dd HH:mm:ss"
        /// </summary>
        [Required, MaxLength(19), DisplayName("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// 调用的接口版本，固定为：1.0
        /// </summary>
        [Required, MaxLength(3), DisplayName("version")]
        public string Version { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [Required, DisplayName("sign")]
        public string Sign { protected get; set; }

        public override string this[string index]
        {
            get
            {
                if (ParamaterDictionary.ContainsKey(index))
                {
                    return ParamaterDictionary[index];
                }

                foreach (var property in GetType().GetProperties())
                {
                    var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                    if (string.IsNullOrEmpty(displayName) || index != displayName) continue;

                    return property.GetValue(this).ToString();
                }

                return null;
            }
            set => AddOrUpdate(index, value);
        }

        public override void AddOrUpdate(string key, string value)
        {
            var isComplated = false;
            //从属性中查找并设置
            foreach (var property in GetType().GetProperties())
            {
                var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                if (string.IsNullOrEmpty(displayName) || key != displayName) continue;

                property.SetValue(this, value);
                isComplated = true;
                break;
            }
            if (isComplated) return;

            //从字典中查找并设置
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
        public override void Remove(string key)
        {
            var isComplated = false;
            //从属性中查找并设置
            foreach (var property in GetType().GetProperties())
            {
                var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                if (string.IsNullOrEmpty(displayName) || key != displayName) continue;

                property.SetValue(this, null);
                isComplated = true;
                break;
            }
            if (isComplated) return;

            //从字典中查找并设置
            if (ParamaterDictionary.ContainsKey(key))
            {
                ParamaterDictionary.Remove(key);
            }
        }

        public Encoding Encoding => Encoding.GetEncoding(Charset);

        public override IEnumerable<KeyValuePair<string, string>> Paramaters
        {
            get
            {
                foreach (var property in GetType().GetProperties())
                {
                    var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                    if (string.IsNullOrEmpty(displayName)) continue;

                    var value = property.GetValue(this)?.ToString();
                    if (string.IsNullOrEmpty(value)) continue;

                    yield return new KeyValuePair<string, string>(displayName, value);
                }

                yield return new KeyValuePair<string, string>("biz_content", JsonConvert.SerializeObject(ParamaterDictionary));
            }
        }
    }
}
