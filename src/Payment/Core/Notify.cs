using System;
using System.Web;

namespace Payment.Core
{
    public abstract class Notify : INotify
    {
        public IGateWay GateWay { get; protected set; }
        
        public virtual Action<INotify, INotifyContent> OnLoaded { get; set; }

        protected Notify(IGateWay gateWay)
        {
            GateWay = gateWay;
        }

        /// <summary>
        /// 签名器
        /// </summary>
        protected abstract ISignature Signature { get; }

        /// <summary>
        /// 创建具体通知对象
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected abstract INotifyContent CreateNotifyContent(HttpContext httpContext);

        /// <summary>
        /// 创建具体通知对象
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected abstract INotifyContent CreateNotifyContent(HttpContextBase httpContext);

        public INotifyContent Load(HttpContext httpContext)
        {
            var content = CreateNotifyContent(httpContext);
            OnLoaded?.Invoke(this, content);

            if (!Signature.Verify(content)) throw new VerifyException(GateWay.Name, content);

            return content;
        }

        public INotifyContent Load(HttpContextBase httpContext)
        {
            var content = CreateNotifyContent(httpContext);
            OnLoaded?.Invoke(this, content);

            if (!Signature.Verify(content)) throw new VerifyException(GateWay.Name, content);

            return content;
        }

        public abstract string SuccessFlag { get; }
    }
}
