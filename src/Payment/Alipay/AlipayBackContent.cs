using Payment.Core;

namespace Payment.Alipay
{
    public abstract class AlipayBackContent : Content, IBackContent
    {
        public string Body { get; protected set; }

        public virtual string SignType => this["sign_type"];

        public virtual string Sign => this["sign"];
    }
}
