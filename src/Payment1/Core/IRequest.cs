using System;

namespace Payment.Core
{
    /// <summary>
    /// 请求
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// 设置参数的方法
        /// </summary>
        Action<IRequest, SettingParamatersEventArgs> SettingParamaters { get; set; }

        /// <summary>
        /// 商户信息
        /// </summary>
        IMerchantConfigure MerchantConfigure { set; }

        /// <summary>
        /// 是否为调试环境
        /// </summary>
        bool IsDebug { set; }
    }
    
    /// <summary>
    /// 使用html跳转的请求方式
    /// </summary>
    public interface IHtmlRequest : IRequest
    {
        /// <summary>
        /// 获取html内容
        /// </summary>
        /// <returns></returns>
        string GetHtml(IOrder order, Action<IRequestContent, IOrder> otherSet = null);
    }
    
    /// <summary>
    /// 使用post方式提交请求，获取响应并解析结果的请求方式
    /// </summary>
    public interface IPostRequest : IRequest
    {
        /// <summary>
        /// 获取响应数据
        /// </summary>
        /// <returns></returns>
        IBackContent GetBack();
    }

    /// <summary>
    /// 下载文件方式的请求
    /// </summary>
    public interface IDownRequest : IRequest
    {
        /// <summary>
        /// 请求并下载保存文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        void SaveAs(string filePath);
    }

    /// <summary>
    /// 获取二维码的请求方式
    /// </summary>
    public interface IScanRequest : IRequest
    {
        /// <summary>
        /// 获取二维码图片路径
        /// </summary>
        /// <returns></returns>
        string GetImgUrl();
    }
}
