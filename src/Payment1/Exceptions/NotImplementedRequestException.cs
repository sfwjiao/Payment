using System;
using System.Runtime.Serialization;

namespace Payment.Exceptions
{
    /// <summary>
    /// 未实现的请求类型异常
    /// </summary>
    [Serializable]
    public class NotImplementedRequestException : PaymentException, ISerializable
    {
        public Type RequestType { get; set; }

        public NotImplementedRequestException() { }

        public NotImplementedRequestException(string message)
            : base(message)
        { }

        public NotImplementedRequestException(string message, Exception inner)
            : base(message, inner)
        { }

        #region ISerializable接口
        
        protected NotImplementedRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)//让基类反序列化其内定义的字段
        {
            RequestType = Type.GetType(info.GetString("RequestType"));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //序列化新定义的每个字段
            info.AddValue("RequestType", RequestType.FullName);
            //让基类序列化其内定义的字段
            base.GetObjectData(info, context);
        }

        #endregion

        #region 扩展构造函数，方便传入RequestType

        public NotImplementedRequestException(Type requestType)
        {
            RequestType = requestType;
        }

        public NotImplementedRequestException(string message, Type requestType)
            : base(message)
        {
            RequestType = requestType;
        }

        public NotImplementedRequestException(string message, Type requestType, Exception inner)
            : base(message, inner)
        {
            RequestType = requestType;
        }

        #endregion
    }
}
