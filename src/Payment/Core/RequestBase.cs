namespace Payment.Core
{
    /// <summary>
    /// 基础请求
    /// </summary>
    public abstract class RequestBase : IRequest
    {
        protected RequestBase(IGateWay gateWay)
        {
            GateWay = gateWay;
        }

        /// <summary>
        /// 平台名称
        /// </summary>
        public IGateWay GateWay { get; protected set; }

        /// <summary>
        /// 签名器
        /// </summary>
        protected abstract ISignature Signature { get; }
        
        /// <summary>
        /// 表单请求地址
        /// </summary>
        protected abstract string GetActionUrl(IContent content);
    }
}
