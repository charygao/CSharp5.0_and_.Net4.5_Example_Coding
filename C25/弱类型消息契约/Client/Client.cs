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
                Binding binding = new WSHttpBinding();
                using (ServiceClient proxy = new ServiceClient(binding, new EndpointAddress("http://localhost:8675/Service")))
                {
                    //发送消息
                    Log log = new Log(typeof(Client).ToString(), "弱类型消息契约", DateTime.Now);
                    Message message = Message.CreateMessage(binding.MessageVersion, "http://tempuri.org/IService/PrintMessage", log);
                    MessageHeader sessionId = MessageHeader.CreateHeader("SessionId", "http://ProfessionalWCF", 10);
                    MessageHeader description = MessageHeader.CreateHeader("Description", "http://ProfessionalWCF", "");
                    message.Headers.Add(sessionId);
                    message.Headers.Add(description);
                    //读取返回消息
                    Message response = proxy.PrintMessage(message);
                    Console.WriteLine("消息Header部分：");
                    foreach (MessageHeaderInfo header in response.Headers)
                    {
                        Console.WriteLine("{0}：{1}", header.Name, header.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }
    }
    [Serializable]
    public class Log
    {
        public String Type;
        public String Content;
        public DateTime Time;
        public Log(String type, String content, DateTime time)
        {
            Type = type;
            Content = content;
            Time = time;
        }
        public override string ToString()
        {
            return Time.ToString() + "：" + "[" + Type + "] " + Content;
        }
    }
}
