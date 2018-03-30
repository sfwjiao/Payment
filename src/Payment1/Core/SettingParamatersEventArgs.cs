using System;

namespace Payment.Core
{
    /// <summary>
    /// 设置参数事件的参数
    /// </summary>
    public class SettingParamatersEventArgs : EventArgs
    {
        /// <summary>
        /// 订单数据
        /// </summary>
        public IRequestContent Content { get; set; }

        public SettingParamatersEventArgs(IRequestContent content)
        {
            Content = content;
        }
    }
}
