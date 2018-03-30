using System;
using System.Runtime.Serialization;

namespace Payment.Core
{
    /// <summary>
    /// 网关异常
    /// </summary>
    [Serializable]
    public class GateWayException : PaymentException, ISerializable
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        #region ISerializable接口

        protected GateWayException(SerializationInfo info, StreamingContext context)
            : base(info, context)//让基类反序列化其内定义的字段
        {
            PlatformName = info.GetString("Platform");
            Code = info.GetString("Code");
            Msg = info.GetString("Msg");
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //序列化新定义的每个字段
            info.AddValue("Platform", PlatformName);
            info.AddValue("Code", Code);
            info.AddValue("Msg", Msg);
            //让基类序列化其内定义的字段
            base.GetObjectData(info, context);
        }

        #endregion

        #region 扩展构造函数，方便传入Code,Msg

        public GateWayException(string platformName = null, string code = null, string msg = null, string message = null, Exception inner = null)
            : base(platformName, message ?? string.Format("{0}网关异常，{1}:{2}", platformName, code, msg), inner)
        {
            Code = code;
            Msg = msg;
        }

        #endregion
    }
}
