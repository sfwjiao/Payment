using System;
using System.Runtime.Serialization;

namespace Payment.Core
{
    /// <summary>
    /// 支付异常
    /// </summary>
    [Serializable]
    public class PaymentException : Exception, ISerializable
    {
        /// <summary>
        /// 网关平台名称
        /// </summary>
        public string PlatformName { get; set; }

        #region ISerializable接口

        protected PaymentException(SerializationInfo info, StreamingContext context)
            : base(info, context)//让基类反序列化其内定义的字段
        {
            PlatformName = info.GetString("Platform");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //序列化新定义的每个字段
            info.AddValue("Platform", PlatformName);
            //让基类序列化其内定义的字段
            base.GetObjectData(info, context);
        }

        #endregion

        #region 扩展构造函数，方便传入PlatformName

        public PaymentException(string platformName = null, string message = null, Exception inner = null)
            : base(message, inner)
        {
            PlatformName = platformName;
        }

        #endregion
    }
}
