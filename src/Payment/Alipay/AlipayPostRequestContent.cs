using System.Linq;
using System.Text;
using System.Web;
using Payment.Core;

namespace Payment.Alipay
{
    public abstract class AlipayPostRequestContent : AlipayRequestContent, IPostRequestContent
    {
        protected AlipayPostRequestContent(IGateWay gateWay)
            : base(gateWay)
        {
        }

        public string RequestPostData
        {
            get
            {
                var originBuilder = new StringBuilder();
                foreach (var paramater in Paramaters.OrderBy(x => x.Key))
                {
                    originBuilder.Append($"{paramater.Key}={HttpUtility.UrlEncode(paramater.Value, Encoding)}&");
                }
                return originBuilder.ToString().TrimEnd('&');
            }
        }
    }
}
