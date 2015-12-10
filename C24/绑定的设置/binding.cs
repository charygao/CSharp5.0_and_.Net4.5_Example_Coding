using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace HelloWorldClient
{
    class Client
    {
        /// <summary>
        /// 入口方法
        /// </summary>
        static void Main(string[] args)
        {
            NetNamedPipeBinding binding = new NetNamedPipeBinding();
            EndpointAddress address=new EndpointAddress(new Uri("net.pipe://localhost/HelloWorld");
            using (HelloWorldProxy proxy = new HelloWorldProxy(binding,address))
            {
                //利用代理调用服务
                Console.WriteLine(proxy.HelloWorld("WCF"));
                Console.Read();
            }
        }
    }
}
