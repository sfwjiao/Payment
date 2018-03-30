using System;
using System.Text;

namespace Payment.Core
{
    /// <summary>
    /// 通过Url跳转网关的方式调用接口的基类
    /// </summary>
    public abstract class HtmlRequest<T> : RequestBase, IHtmlRequest<T> where T : IRequestParamaters
    {
        protected HtmlRequest(IGateWay gateWay) : base(gateWay) { }

        /// <summary>
        /// 创建请求正文
        /// </summary>
        /// <param name="obj">订单信息</param>
        /// <returns></returns>
        protected abstract IRequestContent CreateContent(T obj);

        /// <summary>
        /// 设置参数事件处理函数
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="content"></param>
        protected virtual void OnSetParamaters(T obj, IRequestContent content)
        {
            obj.SetParamaters?.Invoke(content);
        }

        /// <summary>
        /// 获取可以跳转网关的Html页面正文
        /// </summary>
        /// <param name="obj">订单信息</param>
        /// <param name="otherSet">设置参数事件</param>
        /// <returns></returns>
        public string GetHtml(T obj, Action<IRequestContent, T> otherSet = null)
        {
            //根据商户配置信息、传入参数创建请求正文
            var content = CreateContent(obj);

            //触发设置参数相关事件
            OnSetParamaters(obj, content);
            otherSet?.Invoke(content, obj);


            //为请求正文签名
            if (Signature == null) throw new PaymentException(GateWay.Name, "Signature不能为空");
            content.Sign = Signature.Sign(content);

            //创建Html正文
            var htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine($"<form id='payment' method='post' action='{GetActionUrl(content)}'>");
            foreach (var paramater in content.Paramaters)
            {
                htmlBuilder.AppendLine($"<input type='hidden' name='{paramater.Key}' value='{paramater.Value}' />");
            }
            htmlBuilder.AppendLine("</form>");
            htmlBuilder.AppendLine("<script>payment.submit()</script>");

            return htmlBuilder.ToString();
        }

        public abstract INotify Notify { get; }
    }
}
