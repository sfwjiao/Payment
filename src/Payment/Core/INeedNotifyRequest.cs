namespace Payment.Core
{
    /// <summary>
    /// 需要通知的请求
    /// </summary>
    public interface INeedNotifyRequest
    {
        INotify Notify { get; }
    }
}
