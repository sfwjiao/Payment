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

        /// <summary>
        /// 是否为调试环境
        /// </summary>
        bool IsDebug { set; }
    }
}
