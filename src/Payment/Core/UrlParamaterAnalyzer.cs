using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace Payment.Core
{
    /// <summary>
    /// url请求类型的参数解析器
    /// </summary>
    public class UrlParamaterAnalyzer : IParamaterAnalyzer
    {
        public IDictionary<string, string> Invoke(string body)
        {
            var result = new Dictionary<string, string>();

            var regex = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
            var mc = regex.Matches(body);

            foreach (Match item in mc)
            {
                var value = item.Result("$3");
                result.Add(item.Result("$2"), value);
            }

            return result;
        }
    }
}
