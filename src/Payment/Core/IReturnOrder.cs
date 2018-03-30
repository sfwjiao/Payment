namespace Payment.Core
{
    public interface IReturnOrder : IOrder
    {
        /// <summary>
        /// 回调地址
        /// </summary>
        string ReturnUrl { get; }
    }
}
