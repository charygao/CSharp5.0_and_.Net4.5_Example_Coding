using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Collections;
namespace WCF.Third
{
    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                using (Proxy proxy = new Proxy(new WSHttpBinding(), new EndpointAddress("http://localhost:8675/Service")))
                {
                    LogCollectionOfstring logs = new LogCollectionOfstring();
                    logs.Add("系统已经启动");
                    logs.Add("客户端发送消息");
                    logs.Add("系统关闭");
                    proxy.PrintLogs(logs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }
    }
    /// <summary>
    /// 定义集合数据契约
    /// </summary>
    [CollectionDataContract]
    public class LogCollectionOfstring : List<String>
    {
        private List<String> _logs = new List<String>();
    }
    /// <summary>
    /// 定义简单的服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void PrintLogs(LogCollectionOfstring logs);
    }
    /// <summary>
    /// 代理类型
    /// </summary>
    public class Proxy : ClientBase<IService>, IService
    {
        public Proxy(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }
        public void PrintLogs(LogCollectionOfstring logs)
        {
            Channel.PrintLogs(logs);
        }
    }
}
