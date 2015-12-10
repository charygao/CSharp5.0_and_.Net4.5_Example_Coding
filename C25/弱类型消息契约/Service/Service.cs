using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;

namespace WCF.Third
{
    /// <summary>
    /// 定义服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Message PrintMessage(Message log);
    }
    /// <summary>
    /// 服务契约的实现
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// 打印消息的Body和Header
        /// </summary>
        public Message PrintMessage(Message log)
        {
            try
            {
                //打印消息
                internal_PrintMessage(log);
                //创建返回消息
                Message response = Message.CreateMessage(OperationContext.Current.IncomingMessageHeaders.MessageVersion,
                                                        "http://tempuri.org/IService/PrintMessageResponse");
                MessageHeader header = MessageHeader.CreateHeader("ResponseCode", "http://ProfessionalWCF", 101);
                response.Headers.Add(header);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Message response = Message.CreateMessage(OperationContext.Current.IncomingMessageHeaders.MessageVersion, 
                                                        "http://tempuri.org/IService/PrintMessageResponse");
                MessageHeader header = MessageHeader.CreateHeader("ResponseCode", "ProfessionalWCF", 102);
                return response;
            }
        }
        /// <summary>
        /// 打印消息
        /// </summary>
        private void internal_PrintMessage(Message message)
        {
            Console.WriteLine("消息Header部分：");
            foreach (MessageHeaderInfo header in message.Headers)
            {
                Console.WriteLine("{0}：{1}", header.Name, header.ToString());
            }
            Console.WriteLine("消息Body部分：");
            Log messageBody = message.GetBody<Log>();
            Console.WriteLine(messageBody);
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


