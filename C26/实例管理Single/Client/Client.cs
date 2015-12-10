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
            try
            {
                //使用多个代理访问服务
                using (ServiceClient proxy = new ServiceClient(new WSHttpBinding(),
                            new EndpointAddress("http://localhost:8675/Service")))
                {
                    proxy.Operate();
                    proxy.Operate();
                    proxy.Operate();
                }
                using (ServiceClient proxy = new ServiceClient(new WSHttpBinding(),
                            new EndpointAddress("http://localhost:8675/Service")))
                {
                    proxy.Operate();
                    proxy.Operate();
                    proxy.Operate();
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
