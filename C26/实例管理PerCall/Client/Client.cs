using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
namespace WCF.Fourth
{
    class Client
    {
        static void Main(string[] args)
        {
            using (ServiceClient proxy = new ServiceClient(new WSHttpBinding(), 
                        new EndpointAddress("http://localhost:8675/Service")))
            {
                //多次调用以测试实例管理
                proxy.Operate();
                proxy.Operate();
                proxy.Operate();
            }
            Console.Read();
        }
    }
}
