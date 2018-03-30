using System;

namespace Payment.Core
{
    public interface IRequestParamaters
    {
        /// <summary>
        /// 设置参数的委托
        /// </summary>
        Action<IRequestContent> SetParamaters { get; }
    }
}
