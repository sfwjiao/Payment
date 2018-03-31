using Payment.Alipay;
using Payment.Core;

namespace Demo
{
    public class PaymentConfig : PaymentContainer<object>
    {
        public void RegisterGateWays()
        {
            InitGateWay(new GateWay(new AlipayMerchantConfigure
            {
                MerchantId = "2016091200495283",
                PublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAu73VfjknPpAjCrKyvmIPaHOJyw23B+BcmtmwUVqfFLfLLOHoGtW8OctiWAr01FXo1gHRmqvTLvX+FhCteg7tQ9CSfnSGsSXaotDSgPTq2NKvJWXSPhka9gMJ7hVYmleIx+L/X7bhLLcRXCfG76kDbpAXSze/yPXV8yHW7IXgYS0PHK11GsCcgJjr9mlqjyVNaJZUbrVbQ6Uw9ZhBawfVRRaD9gwqoESE0kt55SB8Z9SmYxDaV1SYh72hAUyI8iPaHOx3djAbyJTyU3D1yneTjUzHx08cj8GZEYGOdn7ZIltuBR3iGCZL1r1E67QnPZmOByeyrRZ88bCac0ABatXuKQIDAQAB",
                PrivateKey = "MIIEpAIBAAKCAQEAu73VfjknPpAjCrKyvmIPaHOJyw23B+BcmtmwUVqfFLfLLOHoGtW8OctiWAr01FXo1gHRmqvTLvX+FhCteg7tQ9CSfnSGsSXaotDSgPTq2NKvJWXSPhka9gMJ7hVYmleIx+L/X7bhLLcRXCfG76kDbpAXSze/yPXV8yHW7IXgYS0PHK11GsCcgJjr9mlqjyVNaJZUbrVbQ6Uw9ZhBawfVRRaD9gwqoESE0kt55SB8Z9SmYxDaV1SYh72hAUyI8iPaHOx3djAbyJTyU3D1yneTjUzHx08cj8GZEYGOdn7ZIltuBR3iGCZL1r1E67QnPZmOByeyrRZ88bCac0ABatXuKQIDAQABAoIBAQCzHDzeGzCxo1mLD0kwEOWaRQAk1ITV4tr2cNCiDM7QOTiBLVT+pQLaMIs2a91/5iYoZbvO0Da+CrnJ20dlt2/szsO0GP+XagHYa1ko5oBXM0kdaLLXw6PRKL0EgyDwvqoj6RCyBAt3WYAaZ2iHpLs9dAKFJD64PrFLL/GX3XFfwrUN/seXnevhObk1JgucYqzpGNqOeuCCTqgbf7ou6ZIsdRorHKxIbTlUvAX6mDq9skHpM+sBo1J9sRflLZ3g4sllg43wFMz/Dkr01A/Vg1lMAJhJ/EbaO4X8Ce9/udUG4i9nJ0B/zO4bnwD38f3mmg1bIPgrYEKmtgWt8/a9pyXxAoGBAPDIDzgxMNZETipWmzfzaao5nnd6wMpTNQ3F3yGI4rYwieh0dLBPw0u1aHKePIzInnXi/xc6kabcl1d8TEHTVma/BBjOUCfuUUcRLmjWij3u7sc7eOniHSH9bS+MV4fit0Ms73XG7mRcBduttagHVCVxMksz4ulCIEguKbjjVGwjAoGBAMebkSl6g7jwt/xXy7SF05vt19zKug2A081kIesrSfNPi3ND6wGwKStY+JpnTyfKIjGh7lYYjyxteQmJ9RROcUzgwv+AtFnFjKf8pG/9l+Fjf3obf+qwH0OrrAe+5QRvJ/+ic5qe9R/dlYoiBncedUff6SxEQCWMxlVdiEDCeWtDAoGBALnL9oqK0r+UJ6jd+ZpcFx5GpfRWYav+NwMwu/Q5l4+0tsYMDvr6IZ4rFrTTS6/rIvOevO6kwD29HH9ip8lnldVk8nldwlZ9vHQVWvWFD1mpJNHSH4SCea5/yyAUsHpnxLhuVT1RyyTgKZkRWwqU1SarSX7kQ+VwpE5uaL2FleB3AoGAR7byzo4/6SBDWhxJCdDTGEC5v4/ujI9uiWqibRWeehZoKb+LHY4nHHXYy9C2Nbt/0Yk2UiR8vB+QzwaL0QHl3xMZvCaHpYE+adRxV/MqsEXJNRvQN4eTlAKHyjihm5g8LLI3CqR1uT8pTPmwjPead3pREiBrU5JiZ6U1IN8+NHUCgYBRiIchILYVBqvUjgP4d3fBUsG+ZI0V4me24lq4+9sJIj8S8Le89vMubl2JHl9JQodQK+kB5JCDmIHLcWURi2oZK3lHk6Fm1biOiH7LgtWxT9CxUWChy8hP84aofeDQ1z2D9QArRV1ByWhCCPfk8pbxpGLsJsPfAPsiHNAZGEhYag==",
            }), "Alipay");

            InjectRequest<IHtmlRequest<IReturnOrder>, AlipayWebPayRequest<IReturnOrder>>("Alipay");
        }
    }
}