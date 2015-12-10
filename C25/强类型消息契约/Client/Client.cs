using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using Client.WCF.Third;

namespace WCF.Third
{
    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                //使用自动生成的代理类型
                using (ServiceClient proxy = new ServiceClient(new WSHttpBinding(), new EndpointAddress("http://localhost:8675/Service")))
                {
                    //消息的头部
                    HeaderInfo header = new HeaderInfo();
                    header.Description = "";
                    header.SessionId = 10;
                    //消息的Body部分
                    BodyInfo body = new BodyInfo();
                    body.Time = DateTime.Now;
                    body.Type = typeof(Client).ToString();
                    body.Content = "强类型消息";
                    //访问服务
                    ResponseMessage response = proxy.PrintLog(new LogMessage(header, body));
                    Console.WriteLine("返回码为{0}", response.responseCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }
    }
}
