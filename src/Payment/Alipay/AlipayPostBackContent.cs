using System.Collections.Generic;
using Payment.Core;

namespace Payment.Alipay
{
    public abstract class AlipayPostBackContent : AlipayBackContent, IPostBackContent
    {
        public bool IsSuccessRequest => this["code"] == "10000";

        public string Code => this["code"];

        public virtual string Msg => this["msg"];

        public string SubCode => this["sub_code"];

        public virtual string SubMsg => this["sub_msg"];

        /// <summary>
        /// 解析器
        /// </summary>
        protected IParamaterAnalyzer ParamaterAnalyzer => new JsonParamaterAnalyzer();

        /// <summary>
        /// 根节点参数
        /// </summary>
        protected IDictionary<string, string> RootParamaters { get; set; }

        protected AlipayPostBackContent(string json)
        {
            Body = json;

            RootParamaters = ParamaterAnalyzer.Invoke(json);
            ParamaterDictionary = ParamaterAnalyzer.Invoke(RootParamaters["alipay_trade_query_response"]);
        }
    }
}
