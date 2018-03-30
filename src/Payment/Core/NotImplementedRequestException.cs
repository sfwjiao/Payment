using System;
using System.Runtime.Serialization;

namespace Payment.Core
{
    /// <summary>
    /// 未实现的请求类型异常
    /// </summary>
    [Serializable]
    public class NotImplementedRequestException : PaymentException, ISerializable
    {
        public Type RequestType { get; set; }

        public string ImplName { get; set; }

        #region ISerializable接口

        protected NotImplementedRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)//让基类反序列化其内定义的字段
        {
            RequestType = Type.GetType(info.GetString("RequestType"));
            ImplName = info.GetString("ImplName");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //序列化新定义的每个字段
            info.AddValue("RequestType", RequestType.FullName);
            info.AddValue("ImplName", ImplName);
            //让基类序列化其内定义的字段
            base.GetObjectData(info, context);
        }

        #endregion

        #region 扩展构造函数，方便传入RequestType

        public NotImplementedRequestException(string platformName = null, Type requestType = null, string name = null, string message = null, Exception inner = null)
            : base(platformName, message, inner)
        {
            RequestType = requestType;
            ImplName = name;
        }

        #endregion
    }
}
