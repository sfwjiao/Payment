using System;
using System.Net;
using Payment.Http;

namespace Payment.Core
{
    /// <summary>
    /// 通过网络POST方式调用接口的基类
    /// </summary>
    /// <typeparam name="T">POST相关参数</typeparam>
    /// <typeparam name="TPostBackContent">返回正文</typeparam>
    public abstract class PostRequest<T, TPostBackContent> : RequestBase, IPostRequest<T, TPostBackContent>
        where TPostBackContent : IPostBackContent
        where T : IRequestParamaters
    {
        protected PostRequest(IGateWay gateWay) : base(gateWay) { }

        /// <summary>
        /// 创建请求正文
        /// </summary>
        /// <param name="obj">参数</param>
        /// <returns></returns>
        protected abstract IPostRequestContent CreateContent(T obj);

        /// <summary>
        /// 执行请求前，设置http请求
        /// </summary>
        /// <param name="request">http请求</param>
        /// <param name="content">请求正文</param>
        protected virtual void BeforePost(HttpWebRequest request, IPostRequestContent content) { }

        /// <summary>
        /// 加载返回对象
        /// </summary>
        /// <param name="backstr"></param>
        /// <returns></returns>
        protected abstract TPostBackContent Load(string backstr);

        public TPostBackContent GetBack(T obj, Action<IPostRequestContent, T> otherSet = null)
        {
            //根据商户配置信息、传入参数创建请求正文
            var content = CreateContent(obj);

            //触发设置参数相关事件
            obj.SetParamaters?.Invoke(content);
            otherSet?.Invoke(content, obj);

            //为请求正文签名
            if (Signature == null) throw new PaymentException(GateWay.Name, "Signature不能为空");
            content.Sign = Signature.Sign(content);

            //创建http请求对象
            var client = new LiteHttpClient(content.Encoding);
            var request = DefaultRequest.FromString(GetActionUrl(content));
            BeforePost(request, content);

            //执行请求获得响应字符串
            string backstr;
            try
            {
                backstr = client.PostString(request, content.RequestPostData);
            }
            catch (Exception ex)
            {
                throw new GateWayException(GateWay.Name, message: "网络异常！", inner: ex);
            }

            //加载响应字符串获取返回对象
            var back = Load(backstr);
            
            if (!Signature.Verify(back)) throw new VerifyException(GateWay.Name, back);
            if (!back.IsSuccessRequest) throw new GateWayException(GateWay.Name, back.SubCode, back.SubMsg);

            return back;
        }
    }
}
