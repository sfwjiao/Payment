namespace Payment.Core
{
    /// <summary>
    /// 商户配置信息
    /// </summary>
    public abstract class MerchantConfigure : IMerchantConfigure
    {
        public string MerchantId { get; set; }

        public string SignType { get; set; }
    }
}