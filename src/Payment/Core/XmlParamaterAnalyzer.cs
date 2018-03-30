using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Payment.Core
{
    /// <summary>
    /// xml类型参数的解析器
    /// </summary>
    public class XmlParamaterAnalyzer : IParamaterAnalyzer
    {
        public IDictionary<string, string> Invoke(string body)
        {
            var doc = new XmlDocument();
            doc.LoadXml(body);
            var root = doc.DocumentElement;
            return root?.ChildNodes.Cast<XmlNode>().ToDictionary(node => node.Name, node => node.InnerText);
        }
    }
}
