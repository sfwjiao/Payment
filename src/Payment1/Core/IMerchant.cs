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
        /// 回调地址
        /// </summary>
        string ReturnUrl { get; }

        /// <summary>
        /// 通知地址
        /// </summary>
        string NotifyUrl { get; }
    }

    /// <summary>
    /// 商户配置信息
    /// </summary>
    public class MerchantConfigure : IMerchantConfigure
    {
        public string MerchantId { get; set; }

        public string ReturnUrl { get; set; }

        public string NotifyUrl { get; set; }
    }
}
