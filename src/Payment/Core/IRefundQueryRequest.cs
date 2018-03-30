namespace Payment.Core
{
    /// <summary>
    /// 退款查询请求
    /// </summary>
    public interface IRefundQueryRequest : IPostRequest<IRefundQueryOrder, IRefundQueryBackContent>
    {
    }
}
