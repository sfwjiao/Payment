using System;
using System.Runtime.Serialization;

namespace Payment.Exceptions
{
    /// <summary>
    /// 支付参数异常
    /// </summary>
    public class PaymentArgumentException : PaymentException, ISerializable
    {
        public PaymentArgumentException() { }

        public PaymentArgumentException(string message)
            : base(message)
        { }

        public PaymentArgumentException(string message, Exception inner)
            : base(message, inner)
        { }

        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParamName { get; set; }

        #region ISerializable接口

        protected PaymentArgumentException(SerializationInfo info, StreamingContext context)
            : base(info, context)//让基类反序列化其内定义的字段
        {
            ParamName = info.GetString("ParamName");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //序列化新定义的每个字段
            info.AddValue("ParamName", ParamName);
            //让基类序列化其内定义的字段
            base.GetObjectData(info, context);
        }

        #endregion

        #region 扩展构造函数，方便传入RequestType

        public PaymentArgumentException(string message, string paramName)
            : base(message)
        {
            ParamName = paramName;
        }

        public PaymentArgumentException(string message, string paramName, Exception inner)
            : base(message, inner)
        {
            ParamName = paramName;
        }

        #endregion
    }
}
