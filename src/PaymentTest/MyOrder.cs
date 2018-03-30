using System;
using Payment.Core;

namespace PaymentTest
{
    public class MyOrder : IOrder, IPlatformOrder
    {
        public MyOrder()
        {
        }

        public string OrderNo { get; set; }

        public string PlatformTradeNo { get; set; }

        public decimal Price { get; set; }

        public string Subject { get; set; }

        public Action<IRequestContent> SetParamaters
        {
            get
            {
                return content =>
                {
                    content["123"] = OrderNo;
                };
            }
        }
    }
}
