using System;
using System.Text;
using Payment.Core;
using Payment.Exceptions;

namespace Payment.Alipay
{
    /// <summary>
    /// 支付宝手机网站支付
    /// </summary>
    public class AlipayWapPayRequest : AlipayRequest, IWapPayRequest
    {
        public string GetHtml(IOrder order, Action<IRequestContent, IOrder> otherSet = null)
        {
            var content = new AlipayWapPayRequestContent(MerchantConfigure, order);
            content.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SettingParamaters?.Invoke(this, new SettingParamatersEventArgs(content));
            otherSet?.Invoke(content, order);

            if (Signature == null) throw new PaymentException("Signature不能为空");
            content.Sign = Signature.Sign(content);

            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<html>");
            htmlBuilder.AppendLine("    <body onload='payment.submit()'>");
            htmlBuilder.AppendLine($"       <form id='payment' method='post' action='{GateWayUrl}'>");
            foreach (var paramater in content.Paramaters)
            {
                htmlBuilder.AppendLine($"           <input type='hidden' name='{paramater.Key}' value='{paramater.Value}' />");
            }
            htmlBuilder.AppendLine("        </form>");
            htmlBuilder.AppendLine("    </body>");
            htmlBuilder.AppendLine("</html>");

            return htmlBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public INotify Notify => new AlipayNotify();
    }
}
