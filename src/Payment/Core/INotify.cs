using System;
using System.Web;

namespace Payment.Core
{
    /// <summary>
    /// 回调通知
    /// </summary>
    public interface INotify
    {
        /// <summary>
        /// 网关
        /// </summary>
        IGateWay GateWay { get; }

        /// <summary>
        /// 加载完成事件
        /// </summary>
        Action<INotify, INotifyContent> OnLoaded { get; }

        /// <summary>
        /// 加载通知数据
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <returns></returns>
        INotifyContent Load(HttpContext httpContext);

        /// <summary>
        /// 加载通知数据
        /// </summary>
        /// <param name="httpContext">HttpContextBase</param>
        /// <returns></returns>
        INotifyContent Load(HttpContextBase httpContext);

        /// <summary>
        /// 通知处理成功
        /// </summary>
        string SuccessFlag { get; }
    }
}
