using System;
using System.Runtime.Serialization;

namespace Payment.Core
{
    [Serializable]
    public class VerifyException : PaymentException, ISerializable
    {
        public IBackContent Content { get; set; }

        #region ISerializable接口

        protected VerifyException(SerializationInfo info, StreamingContext context)
            : base(info, context)//让基类反序列化其内定义的字段
        {
            Content = (INotifyContent)info.GetValue("Content", typeof(INotifyContent));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //序列化新定义的每个字段
            info.AddValue("Content", Content);
            //让基类序列化其内定义的字段
            base.GetObjectData(info, context);
        }

        #endregion

        #region 扩展构造函数，方便传入PlatformName

        public VerifyException(string platformName = null, IBackContent content = null, string message = null, Exception inner = null)
            : base(platformName, message, inner)
        {
            Content = content;
        }

        #endregion
    }
}
