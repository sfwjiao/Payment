using System.IO;
using System.Xml.Serialization;

namespace Payment.Xml
{
    internal class XmlHelper
    {
        /// <summary>  
        /// 反序列化  
        /// </summary>
        /// <param name="xml">XML字符串</param>  
        /// <returns></returns>  
        public static T Deserialize<T>(string xml)
        {
            using (var sr = new StringReader(xml))
            {
                var xmldes = new XmlSerializer(typeof(T));
                return (T)xmldes.Deserialize(sr);
            }
        }

        /// <summary>  
        /// 序列化  
        /// </summary>  
        /// <param name="obj">对象</param>  
        /// <returns></returns>  
        public static string Serialize<T>(T obj)
        {
            var stream = new MemoryStream();
            var xml = new XmlSerializer(typeof(T));
            //序列化对象  
            xml.Serialize(stream, obj);
            stream.Position = 0;
            var sr = new StreamReader(stream);
            var str = sr.ReadToEnd();

            sr.Dispose();
            stream.Dispose();

            return str;
        }
    }
}
