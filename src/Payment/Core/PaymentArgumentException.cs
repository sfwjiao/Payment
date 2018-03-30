using System;
using System.Runtime.Serialization;

namespace Payment.Core
{
    /// <summary>
    /// 支付参数异常
    /// </summary>
    public class PaymentArgumentException : PaymentException, ISerializable
    {
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

        #region 扩展构造函数，方便传入ParamName

        public PaymentArgumentException(string platformName = null, string paramName = null, string message = null, Exception inner = null)
            : base(platformName, message, inner)
        {
            ParamName = paramName;
        }

        #endregion
    }
}
