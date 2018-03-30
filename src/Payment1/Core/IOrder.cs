namespace Payment.Core
{
    /// <summary>
    /// 订单数据
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        string OrderNo { get; }

        /// <summary>
        /// 订单价格，单位：元
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// 商品名称，标题，描述等信息
        /// </summary>
        string Subject { get; }
    }
}
