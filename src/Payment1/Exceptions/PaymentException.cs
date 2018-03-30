using System;
using System.Runtime.Serialization;

namespace Payment.Exceptions
{
    /// <summary>
    /// 支付异常
    /// </summary>
    [Serializable]
    public class PaymentException : Exception
    {
        public PaymentException() { }

        public PaymentException(string message)
            : base(message)
        { }

        public PaymentException(string message, Exception inner)
            : base(message, inner)
        { }

        protected PaymentException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
