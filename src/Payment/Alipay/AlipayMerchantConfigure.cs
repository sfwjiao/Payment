using Payment.Core;

namespace Payment.Alipay
{
    /// <summary>
    /// 支付宝商户配置信息
    /// </summary>
    public class AlipayMerchantConfigure : MerchantConfigure
    {
        public AlipayMerchantConfigure()
        {
            SignType = "RSA2";
        }

        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; set; }
    }
}
