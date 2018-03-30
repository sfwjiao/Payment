using System.Text;
using System.Linq;
using Payment.Core;
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
        protected IGateWay GateWay { get; set; }

        public AlipaySignature(IGateWay gateWay)
        {
            GateWay = gateWay;
        }

        public string Sign(IRequestContent content)
        {
            if (content.SignType != "RSA" && content.SignType != "RSA2") throw new PaymentArgumentException(GateWay.Name, "sign_type", $"不支持的sign_type:{content.SignType}");
            if (content.Encoding == null) throw new PaymentArgumentException(GateWay.Name, "charset", "编码格式错误");

            if (!(GateWay.MerchantConfigure is AlipayMerchantConfigure merchantConfigure)) throw new PaymentException(GateWay.Name, "商户信息错误");

            return SecurityUtiity.RSA(GetSignOrigin(content), merchantConfigure.PrivateKey, content.Encoding.BodyName, content.SignType, false);
        }

        public bool Verify(IBackContent content)
        {
            if (content.SignType != "RSA" && content.SignType != "RSA2") throw new PaymentArgumentException(GateWay.Name, "sign_type",
                $"不支持的sign_type:{content.SignType}");
            var chatset = string.IsNullOrEmpty(content["chatset"]) ? "utf-8" : content["chatset"];

            if (!(GateWay.MerchantConfigure is AlipayMerchantConfigure merchantConfigure)) throw new PaymentException(GateWay.Name, "商户信息错误");

            return SecurityUtiity.RSAVerifyData(GetSignOrigin(content), content.Sign, merchantConfigure.PublicKey, chatset, content.SignType, false);
        }

        protected virtual string GetSignOrigin(IBackContent content)
        {
            var originBuilder = new StringBuilder();
            foreach (var paramater in content.Paramaters.OrderBy(x => x.Key))
            {
                if (paramater.Key.ToLower() == "sign") continue;
                if (paramater.Key.ToLower() == "sign_type") continue;
                originBuilder.Append($"{paramater.Key}={paramater.Value}&");
            }
            return originBuilder.ToString().TrimEnd('&');
        }

        protected virtual string GetSignOrigin(IRequestContent content)
        {
            var originBuilder = new StringBuilder();
            foreach (var paramater in content.Paramaters.OrderBy(x => x.Key))
            {
                if (paramater.Key.ToLower() == "sign") continue;
                originBuilder.Append($"{paramater.Key}={paramater.Value}&");
            }
            return originBuilder.ToString().TrimEnd('&');
        }
    }
}
