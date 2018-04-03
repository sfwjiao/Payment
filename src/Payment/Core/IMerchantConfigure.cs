namespace Payment.Core
{
    /// <summary>
    /// 商户配置信息
    /// </summary>
    public interface IMerchantConfigure
    {
        /// <summary>
        /// 商户编号
        /// </summary>
        string MerchantId { get; }

        /// <summary>
        /// 签名类型
        /// </summary>
        string SignType { get; }
    }
}
