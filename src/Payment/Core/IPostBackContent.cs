using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payment.Core;

namespace Payment.Core
{
    public interface IPostBackContent : IBackContent
    {
        /// <summary>
        /// 请求是否成功
        /// </summary>
        bool IsSuccessRequest { get; }

        /// <summary>
        /// 返回码
        /// </summary>
        string Code { get; }

        /// <summary>
        /// 返回消息
        /// </summary>
        string Msg { get; }

        /// <summary>
        /// 返回码（业务返回码，网关返回码使用异常的方式处理）
        /// </summary>
        string SubCode { get; }

        /// <summary>
        /// 返回消息(业务返回消息，网关消息使用异常的方式处理)
        /// </summary>
        string SubMsg { get; }
    }
}
