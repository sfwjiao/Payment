using System;
using System.Text;
using Payment.Core;
using Payment.Exceptions;
using Payment.Security;

namespace Payment.Alipay
{
    /// <summary>
    /// 支付宝签名器
    /// </summary>
    public class AlipaySignature : ISignature
    {
        /// <summary>
        /// 支付宝账户信息
        /// </summary>
        protected AlipayMerchantConfigure MerchantConfigure { get; set; }

        public AlipaySignature(AlipayMerchantConfigure merchantConfigure)
        {
            MerchantConfigure = merchantConfigure;
        }

        public string Sign(IRequestContent content)
        {
            if (content.SignType != "RSA" && content.SignType != "RSA2") throw new PaymentArgumentException($"不支持的sign_type:{content.SignType}", "sign_type");
            if (content.Encoding == null) throw new PaymentArgumentException("编码格式错误", "charset");

            return SecurityUtiity.RSA(content.SignOrigin, MerchantConfigure.PrivateKey, content.Encoding.BodyName, content.SignType, false);
        }

        public bool Verify(IBackContent content)
        {
            throw new NotImplementedException();
        }
    }
}
