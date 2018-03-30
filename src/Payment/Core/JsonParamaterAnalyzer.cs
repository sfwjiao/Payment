using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Payment.Core
{
    /// <summary>
    /// json类型参数的解析器
    /// </summary>
    public class JsonParamaterAnalyzer : IParamaterAnalyzer
    {
        public IDictionary<string, string> Invoke(string body)
        {
            var jsonObj = JObject.Parse(body);

            var dictionary = new Dictionary<string, string>();
            foreach (var items in jsonObj)
            {
                dictionary.Add(items.Key, items.Value.ToString());
            }

            return dictionary;
        }
    }
}
