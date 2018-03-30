using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Payment.Core;

namespace Payment.Alipay
{
    public abstract class AlipayRequestContent : IRequestContent
    {
        //参数字典
        protected Dictionary<string, string> BizContentParamaters { get; set; }

        protected AlipayRequestContent(IMerchantConfigure merchantConfigure)
        {
            AppId = merchantConfigure.MerchantId;
            ReturnUrl = merchantConfigure.ReturnUrl;
            NotifyUrl = merchantConfigure.NotifyUrl;

            BizContentParamaters = new Dictionary<string, string>();
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
        public virtual string Method => throw new NotImplementedException();

        /// <summary>
        /// 仅支持JSON
        /// </summary>
        [MaxLength(40), DisplayName("format")]
        public string Format { get; set; } = "JSON";

        /// <summary>
        /// HTTP/HTTPS开头字符串
        /// </summary>
        [MaxLength(256), DisplayName("return_url")]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 请求使用的编码格式，如utf-8,gbk,gb2312等
        /// </summary>
        [Required, MaxLength(10), DisplayName("charset")]
        public string Charset { get; set; } = "utf-8";

        /// <summary>
        /// 商户生成签名字符串所使用的签名算法类型，目前支持RSA2和RSA，推荐使用RSA2
        /// </summary>
        [Required, MaxLength(10), DisplayName("sign_type")]
        public string SignType { get; set; } = "RSA2";

        /// <summary>
        /// 发送请求的时间，格式"yyyy-MM-dd HH:mm:ss"
        /// </summary>
        [Required, MaxLength(19), DisplayName("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// 调用的接口版本，固定为：1.0
        /// </summary>
        [Required, MaxLength(3), DisplayName("version")]
        public string Version { get; set; } = "1.0";

        /// <summary>
        /// 支付宝服务器主动通知商户服务器里指定的页面http/https路径
        /// </summary>
        [MaxLength(256), DisplayName("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [Required, DisplayName("sign")]
        public string Sign { protected get; set; }

        public string this[string index]
        {
            get
            {
                if (BizContentParamaters.ContainsKey(index))
                {
                    return BizContentParamaters[index];
                }

                foreach (var property in GetType().GetProperties())
                {
                    var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                    if (string.IsNullOrEmpty(displayName) || index != displayName) continue;

                    return property.GetValue(this).ToString();
                }

                return null;
            }
            set
            {
                var isComplated = false;
                //从属性中查找并设置
                foreach (var property in GetType().GetProperties())
                {
                    var displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                    if (string.IsNullOrEmpty(displayName) || index != displayName) continue;

                    property.SetValue(this, value);
                    isComplated = true;
                    break;
                }
                if (isComplated) return;

                //从字典中查找并设置
                if (BizContentParamaters.ContainsKey(index))
                {
                    BizContentParamaters[index] = value;
                }
                else
                {
                    BizContentParamaters.Add(index, value);
                }
            }
        }

        public Encoding Encoding => Encoding.GetEncoding(Charset);

        public string SignOrigin
        {
            get
            {
                var originBuilder = new StringBuilder();
                foreach (var paramater in Paramaters.OrderBy(x => x.Key))
                {
                    if (paramater.Key == "sign") continue;
                    originBuilder.Append($"{paramater.Key}={paramater.Value}&");
                }
                return originBuilder.ToString().TrimEnd('&');
            }
        }

        public IEnumerable<KeyValuePair<string, string>> Paramaters
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

                yield return new KeyValuePair<string, string>("biz_content", JsonConvert.SerializeObject(BizContentParamaters));
            }
        }
    }
}
