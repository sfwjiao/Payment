using System;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;
using Payment.Alipay;
using Payment.Core;
using Payment.Http;
using Xunit;

namespace PaymentTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            PaymentContainer.InitGateWay(new AlipayGateWay(new AlipayMerchantConfigure
            {
                MerchantId = "2016091200495283",
                PublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAu73VfjknPpAjCrKyvmIPaHOJyw23B+BcmtmwUVqfFLfLLOHoGtW8OctiWAr01FXo1gHRmqvTLvX+FhCteg7tQ9CSfnSGsSXaotDSgPTq2NKvJWXSPhka9gMJ7hVYmleIx+L/X7bhLLcRXCfG76kDbpAXSze/yPXV8yHW7IXgYS0PHK11GsCcgJjr9mlqjyVNaJZUbrVbQ6Uw9ZhBawfVRRaD9gwqoESE0kt55SB8Z9SmYxDaV1SYh72hAUyI8iPaHOx3djAbyJTyU3D1yneTjUzHx08cj8GZEYGOdn7ZIltuBR3iGCZL1r1E67QnPZmOByeyrRZ88bCac0ABatXuKQIDAQAB",
                PrivateKey = "MIIEpAIBAAKCAQEAu73VfjknPpAjCrKyvmIPaHOJyw23B+BcmtmwUVqfFLfLLOHoGtW8OctiWAr01FXo1gHRmqvTLvX+FhCteg7tQ9CSfnSGsSXaotDSgPTq2NKvJWXSPhka9gMJ7hVYmleIx+L/X7bhLLcRXCfG76kDbpAXSze/yPXV8yHW7IXgYS0PHK11GsCcgJjr9mlqjyVNaJZUbrVbQ6Uw9ZhBawfVRRaD9gwqoESE0kt55SB8Z9SmYxDaV1SYh72hAUyI8iPaHOx3djAbyJTyU3D1yneTjUzHx08cj8GZEYGOdn7ZIltuBR3iGCZL1r1E67QnPZmOByeyrRZ88bCac0ABatXuKQIDAQABAoIBAQCzHDzeGzCxo1mLD0kwEOWaRQAk1ITV4tr2cNCiDM7QOTiBLVT+pQLaMIs2a91/5iYoZbvO0Da+CrnJ20dlt2/szsO0GP+XagHYa1ko5oBXM0kdaLLXw6PRKL0EgyDwvqoj6RCyBAt3WYAaZ2iHpLs9dAKFJD64PrFLL/GX3XFfwrUN/seXnevhObk1JgucYqzpGNqOeuCCTqgbf7ou6ZIsdRorHKxIbTlUvAX6mDq9skHpM+sBo1J9sRflLZ3g4sllg43wFMz/Dkr01A/Vg1lMAJhJ/EbaO4X8Ce9/udUG4i9nJ0B/zO4bnwD38f3mmg1bIPgrYEKmtgWt8/a9pyXxAoGBAPDIDzgxMNZETipWmzfzaao5nnd6wMpTNQ3F3yGI4rYwieh0dLBPw0u1aHKePIzInnXi/xc6kabcl1d8TEHTVma/BBjOUCfuUUcRLmjWij3u7sc7eOniHSH9bS+MV4fit0Ms73XG7mRcBduttagHVCVxMksz4ulCIEguKbjjVGwjAoGBAMebkSl6g7jwt/xXy7SF05vt19zKug2A081kIesrSfNPi3ND6wGwKStY+JpnTyfKIjGh7lYYjyxteQmJ9RROcUzgwv+AtFnFjKf8pG/9l+Fjf3obf+qwH0OrrAe+5QRvJ/+ic5qe9R/dlYoiBncedUff6SxEQCWMxlVdiEDCeWtDAoGBALnL9oqK0r+UJ6jd+ZpcFx5GpfRWYav+NwMwu/Q5l4+0tsYMDvr6IZ4rFrTTS6/rIvOevO6kwD29HH9ip8lnldVk8nldwlZ9vHQVWvWFD1mpJNHSH4SCea5/yyAUsHpnxLhuVT1RyyTgKZkRWwqU1SarSX7kQ+VwpE5uaL2FleB3AoGAR7byzo4/6SBDWhxJCdDTGEC5v4/ujI9uiWqibRWeehZoKb+LHY4nHHXYy9C2Nbt/0Yk2UiR8vB+QzwaL0QHl3xMZvCaHpYE+adRxV/MqsEXJNRvQN4eTlAKHyjihm5g8LLI3CqR1uT8pTPmwjPead3pREiBrU5JiZ6U1IN8+NHUCgYBRiIchILYVBqvUjgP4d3fBUsG+ZI0V4me24lq4+9sJIj8S8Le89vMubl2JHl9JQodQK+kB5JCDmIHLcWURi2oZK3lHk6Fm1biOiH7LgtWxT9CxUWChy8hP84aofeDQ1z2D9QArRV1ByWhCCPfk8pbxpGLsJsPfAPsiHNAZGEhYag==",
                NotifyUrl = "http://payment.isaacjoy.com/PayNotify",
                ReturnUrl = "http://payment.isaacjoy.com/PayCallBack",
            }), "Alipay:租户编号001");

            PaymentContainer.InitGateWay(new AlipayGateWay(new AlipayMerchantConfigure
            {
                MerchantId = "2016091200495283",
                PublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAu73VfjknPpAjCrKyvmIPaHOJyw23B+BcmtmwUVqfFLfLLOHoGtW8OctiWAr01FXo1gHRmqvTLvX+FhCteg7tQ9CSfnSGsSXaotDSgPTq2NKvJWXSPhka9gMJ7hVYmleIx+L/X7bhLLcRXCfG76kDbpAXSze/yPXV8yHW7IXgYS0PHK11GsCcgJjr9mlqjyVNaJZUbrVbQ6Uw9ZhBawfVRRaD9gwqoESE0kt55SB8Z9SmYxDaV1SYh72hAUyI8iPaHOx3djAbyJTyU3D1yneTjUzHx08cj8GZEYGOdn7ZIltuBR3iGCZL1r1E67QnPZmOByeyrRZ88bCac0ABatXuKQIDAQAB",
                PrivateKey = "MIIEpAIBAAKCAQEAu73VfjknPpAjCrKyvmIPaHOJyw23B+BcmtmwUVqfFLfLLOHoGtW8OctiWAr01FXo1gHRmqvTLvX+FhCteg7tQ9CSfnSGsSXaotDSgPTq2NKvJWXSPhka9gMJ7hVYmleIx+L/X7bhLLcRXCfG76kDbpAXSze/yPXV8yHW7IXgYS0PHK11GsCcgJjr9mlqjyVNaJZUbrVbQ6Uw9ZhBawfVRRaD9gwqoESE0kt55SB8Z9SmYxDaV1SYh72hAUyI8iPaHOx3djAbyJTyU3D1yneTjUzHx08cj8GZEYGOdn7ZIltuBR3iGCZL1r1E67QnPZmOByeyrRZ88bCac0ABatXuKQIDAQABAoIBAQCzHDzeGzCxo1mLD0kwEOWaRQAk1ITV4tr2cNCiDM7QOTiBLVT+pQLaMIs2a91/5iYoZbvO0Da+CrnJ20dlt2/szsO0GP+XagHYa1ko5oBXM0kdaLLXw6PRKL0EgyDwvqoj6RCyBAt3WYAaZ2iHpLs9dAKFJD64PrFLL/GX3XFfwrUN/seXnevhObk1JgucYqzpGNqOeuCCTqgbf7ou6ZIsdRorHKxIbTlUvAX6mDq9skHpM+sBo1J9sRflLZ3g4sllg43wFMz/Dkr01A/Vg1lMAJhJ/EbaO4X8Ce9/udUG4i9nJ0B/zO4bnwD38f3mmg1bIPgrYEKmtgWt8/a9pyXxAoGBAPDIDzgxMNZETipWmzfzaao5nnd6wMpTNQ3F3yGI4rYwieh0dLBPw0u1aHKePIzInnXi/xc6kabcl1d8TEHTVma/BBjOUCfuUUcRLmjWij3u7sc7eOniHSH9bS+MV4fit0Ms73XG7mRcBduttagHVCVxMksz4ulCIEguKbjjVGwjAoGBAMebkSl6g7jwt/xXy7SF05vt19zKug2A081kIesrSfNPi3ND6wGwKStY+JpnTyfKIjGh7lYYjyxteQmJ9RROcUzgwv+AtFnFjKf8pG/9l+Fjf3obf+qwH0OrrAe+5QRvJ/+ic5qe9R/dlYoiBncedUff6SxEQCWMxlVdiEDCeWtDAoGBALnL9oqK0r+UJ6jd+ZpcFx5GpfRWYav+NwMwu/Q5l4+0tsYMDvr6IZ4rFrTTS6/rIvOevO6kwD29HH9ip8lnldVk8nldwlZ9vHQVWvWFD1mpJNHSH4SCea5/yyAUsHpnxLhuVT1RyyTgKZkRWwqU1SarSX7kQ+VwpE5uaL2FleB3AoGAR7byzo4/6SBDWhxJCdDTGEC5v4/ujI9uiWqibRWeehZoKb+LHY4nHHXYy9C2Nbt/0Yk2UiR8vB+QzwaL0QHl3xMZvCaHpYE+adRxV/MqsEXJNRvQN4eTlAKHyjihm5g8LLI3CqR1uT8pTPmwjPead3pREiBrU5JiZ6U1IN8+NHUCgYBRiIchILYVBqvUjgP4d3fBUsG+ZI0V4me24lq4+9sJIj8S8Le89vMubl2JHl9JQodQK+kB5JCDmIHLcWURi2oZK3lHk6Fm1biOiH7LgtWxT9CxUWChy8hP84aofeDQ1z2D9QArRV1ByWhCCPfk8pbxpGLsJsPfAPsiHNAZGEhYag==",
                NotifyUrl = "http://payment.isaacjoy.com/PayNotify",
                ReturnUrl = "http://payment.isaacjoy.com/PayCallBack",
            }), "Alipay:租户编号002");

            PaymentContainer.InjectRequest<IHtmlRequest<IOrder>, AlipayWapPayRequest<IOrder>>("Alipay:租户编号001", "0001");
            PaymentContainer.InjectRequest<IHtmlRequest<IOrder>, AlipayWebPayRequest>("Alipay:租户编号001", "0002");

            var request = PaymentContainer.GetRequest<IWapPayRequest<IOrder>>("Alipay:租户编号002");
            var html = request.GetHtml(new MyOrder
            {
                OrderNo = "12345678901234567891",
                Subject = "测试",
                Price = 0.01M,
            });
            Assert.NotNull(html);

            var req = PaymentContainer.GetRequest<IHtmlRequest<IOrder>>("Alipay:租户编号001", "0001");
            html = req.GetHtml(new MyOrder
            {

                OrderNo = "123456789012345678912",
                Subject = "测试2",
                Price = 0.01M,
            });
            Assert.NotNull(html);

            req = PaymentContainer.GetRequest<IHtmlRequest<IOrder>>("Alipay:租户编号001", "0002");
            html = req.GetHtml(new MyOrder
            {
                OrderNo = "123456789012345678913",
                Subject = "测试3",
                Price = 0.01M,
            });
            Assert.NotNull(html);
        }

        [Fact]
        public void TestMethod2()
        {
            DateTime.TryParse("", out var result);

            Assert.True(result.Day == 1);
        }

        [Fact]
        public void TestJsonRead()
        {
            var json = new StringBuilder();

            #region jsonContent

            json.AppendLine("{");
            json.AppendLine("   \"alipay_trade_query_response\": {");
            json.AppendLine("       \"code\": \"10000\",");
            json.AppendLine("       \"msg\": \"Success\",");
            json.AppendLine("       \"trade_no\": \"2013112011001004330000121536\",");
            json.AppendLine("       \"out_trade_no\": \"6823789339978248\",");
            json.AppendLine("       \"buyer_logon_id\": \"159****5620\",");
            json.AppendLine("       \"trade_status\": \"TRADE_CLOSED\",");
            json.AppendLine("       \"total_amount\": 88.88,");
            json.AppendLine("       \"receipt_amount\": \"15.25\",");
            json.AppendLine("       \"buyer_pay_amount\": 8.88,");
            json.AppendLine("       \"point_amount\": 10,");
            json.AppendLine("       \"invoice_amount\": 12.11,");
            json.AppendLine("       \"send_pay_date\": \"2014-11-27 15:45:57\",");
            json.AppendLine("       \"store_id\": \"NJ_S_001\",");
            json.AppendLine("       \"terminal_id\": \"NJ_T_001\",");
            json.AppendLine("       \"fund_bill_list\": [{");
            json.AppendLine("           \"fund_channel\": \"ALIPAYACCOUNT\",");
            json.AppendLine("           \"amount\": 10,");
            json.AppendLine("           \"real_amount\": 11.21");
            json.AppendLine("       }],");
            json.AppendLine("       \"store_name\": \"证大五道口店\",");
            json.AppendLine("       \"buyer_user_id\": \"2088101117955611\",");
            json.AppendLine("       \"buyer_user_type\": \"PRIVATE\"");
            json.AppendLine("   },");
            json.AppendLine("   \"sign\": \"ERITJKEIJKJHKKKKKKKHJEREEEEEEEEEEE\"");
            json.AppendLine("}");

            #endregion

            var jsonObj = JObject.Parse(json.ToString());
            var v = jsonObj["alipay_trade_query_response"].ToString();
            foreach (var child in jsonObj.Properties())
            {
                var token = child.SelectToken("/");
                var x1 = child.Path;
                var x2 = jsonObj[child.Path].ToString();
                var x3 = child.ToString();

            }
        }

        [Fact]
        public void TestXmlRead()
        {
            var xml = new StringBuilder();

            #region xmlContent

            xml.AppendLine("<xml>");
            xml.AppendLine("<code>10000</code>");
            xml.AppendLine("<msg>Success</msg>");
            xml.AppendLine("<trade_no>2014112611001004680073956707</trade_no>");
            xml.AppendLine("<out_trade_no>20150320010101001</out_trade_no>");
            xml.AppendLine("<out_request_no>20150320010101001</out_request_no>");
            xml.AppendLine("<refund_reason><result>ssss</result></refund_reason>");
            xml.AppendLine("<total_amount>100.20</total_amount>");
            xml.AppendLine("<refund_amount>12.33</refund_amount>");
            xml.AppendLine("</xml>");

            #endregion

            var doc = new XmlDocument();
            doc.LoadXml(xml.ToString());
            var root = doc.DocumentElement;

            if (root != null)
                foreach (XmlNode node in root.ChildNodes)
                {
                    var s1 = node.Name;
                    var s2 = node.InnerText;
                }
        }

        [Fact]
        public void Test()
        {
            var xml = new StringBuilder();

            #region xmlContent

            xml.AppendLine("<xml>");
            xml.AppendLine("<bank_type><![CDATA[CFT]]></bank_type>");
            xml.AppendLine("<cash_fee><![CDATA[1]]></cash_fee>");
            xml.AppendLine("<charset><![CDATA[UTF-8]]></charset>");
            xml.AppendLine("<device_info><![CDATA[AND_WAP]]></device_info>");
            xml.AppendLine("<fee_type><![CDATA[CNY]]></fee_type>");
            xml.AppendLine("<is_subscribe><![CDATA[N]]></is_subscribe>");
            xml.AppendLine("<mch_id><![CDATA[105550034119]]></mch_id>");
            xml.AppendLine("<nonce_str><![CDATA[1521604084680]]></nonce_str>");
            xml.AppendLine("<openid><![CDATA[omcSiwp92p4vYiraNNmqoJUMyiXM]]></openid>");
            xml.AppendLine("<out_trade_no><![CDATA[ID201803211148580078775]]></out_trade_no>");
            xml.AppendLine("<out_transaction_id><![CDATA[4200000071201803212758707709]]></out_transaction_id>");
            xml.AppendLine("<pay_result><![CDATA[0]]></pay_result>");
            xml.AppendLine("<result_code><![CDATA[0]]></result_code>");
            xml.AppendLine("<sign><![CDATA[DAC8AC97A25418FF13091A5F31A12FAA]]></sign>");
            xml.AppendLine("<sign_type><![CDATA[MD5]]></sign_type>");
            xml.AppendLine("<status><![CDATA[0]]></status>");
            xml.AppendLine("<time_end><![CDATA[20180321114804]]></time_end>");
            xml.AppendLine("<total_fee><![CDATA[1]]></total_fee>");
            xml.AppendLine("<trade_type><![CDATA[pay.weixin.wappay]]></trade_type>");
            xml.AppendLine("<transaction_id><![CDATA[105550034119201803212162675319]]></transaction_id>");
            xml.AppendLine("<version><![CDATA[2.0]]></version>");
            xml.AppendLine("</xml>");

            #endregion

            var client = new LiteHttpClient(Encoding.UTF8);
            var result = client.PostString("http://m.pp373.com/sdk/paynotify?configType=10016", xml.ToString());

            Assert.Equal("success", result);
        }
    }
}
