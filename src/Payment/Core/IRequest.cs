using System;

namespace Payment.Core
{
    /// <summary>
    /// 请求
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// 网关信息
        /// </summary>
        IGateWay GateWay { get; }
    }
}
