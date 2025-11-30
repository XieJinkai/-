using Aop.Api.Request;
using Aop.Api;
using Aop.Api.Response;
using HmExtension.Pay;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Diagnostics;
using System.Xml.Linq;
using System.Data.SqlTypes;

namespace 团建活动在线报名智能平台
{

    public class userformBLL
    {
        string txt_orderNum;
        string txt_price;
        string uitxt_name;
        string txt_payCode;
        public userformBLL(string txt_orderNum, string txt_price, string uitxt_name, string txt_payCode)
        {
            this.txt_orderNum = txt_orderNum;
            this.txt_price = txt_price;
            this.uitxt_name = uitxt_name;
            this.txt_payCode = txt_payCode;
        }
        public string getTransferHelp_outTradeNo()
        {
            return TransferHelp.outTradeNO;
        }

        public string getTransferHelp_TrandeNo()
        {
            return TransferHelp.TradeNo;
        }

        public string ResponseReturnMsg(string outTradeNO, string TradeNo)
        {
            IAopClient client = new DefaultAopClient("https://openapi-sandbox.dl.alipaydev.com/gateway.do", TransferHelp.APPID, TransferHelp.Apply_private_key, "json", "1.0", "RSA2", TransferHelp.Alipay_public_key, "GBK", false);

            AlipayTradeQueryRequest request = new AlipayTradeQueryRequest();
            Dictionary<string, object> bizContent = new Dictionary<string, object>();
            bizContent.Add("out_trade_no", outTradeNO);
            bizContent.Add("trade_no", TradeNo);
            string Contentjson = JsonConvert.SerializeObject(bizContent);
            request.BizContent = Contentjson;
            request.BizContent += "{" +
                "  \"query_options\":[" +
                "    \"trade_settle_info\"" +
                "  ]" +
                "}";
            AlipayTradeQueryResponse response = client.Execute(request);
            return response.TradeStatus;

        }
        public bool Pay(string orderNum, string price, string name, string payCode, Timer timer1)
        {
            // 初始化必要参数
            AlipayContext.Init("https://openapi-sandbox.dl.alipaydev.com/gateway.do", TransferHelp.APPID, TransferHelp.Apply_private_key, TransferHelp.Alipay_public_key);
            PayInPersonApi api = new PayInPersonApi();
            var task = api.Pay(orderNum, name, price.ToDouble(), payCode);
            AlipayTradePayResponse payresponse = task.Result;
            TransferHelp.outTradeNO = payresponse.OutTradeNo;
            TransferHelp.TradeNo = payresponse.TradeNo; 
            if (payresponse != null && payresponse.IsSuccess())
                return true;
            else
                // 支付失败逻辑
                return false;
        }

        internal bool Pay(string orderNum, string price, string name, string payCode, System.Windows.Forms.Timer timer1)
        {
            // 初始化必要参数
            AlipayContext.Init("https://openapi-sandbox.dl.alipaydev.com/gateway.do", TransferHelp.APPID, TransferHelp.Apply_private_key, TransferHelp.Alipay_public_key);
            PayInPersonApi api = new PayInPersonApi();
            var task = api.Pay(orderNum, name, price.ToDouble(), payCode);
            AlipayTradePayResponse payresponse = task.Result;
            TransferHelp.outTradeNO = payresponse.OutTradeNo;
            TransferHelp.TradeNo = payresponse.TradeNo;
            if (payresponse != null && payresponse.IsSuccess())
                return true;
            else
                // 支付失败逻辑
                return false;
        }

        public void setTransferHelp(string APPID, string Apply_private_key, string Alipay_public_key)
        {
            TransferHelp.APPID = APPID;
            TransferHelp.Apply_private_key = Apply_private_key;
            TransferHelp.Alipay_public_key = Alipay_public_key;

        }
      


        public class TransferHelp
        {
            /// <summary>
            /// 登录时候用户ID
            /// </summary>
            /// 
           
            public static int? userId;

            public static string outTradeNO { get; set; }

            public static string TradeNo { get; set; }

            public static string APPID { get; set; }

            public static string Apply_private_key { get; set; }

            public static string Alipay_public_key { get; set; }
        }
        /*    Timer timer1;*/

    }
}
