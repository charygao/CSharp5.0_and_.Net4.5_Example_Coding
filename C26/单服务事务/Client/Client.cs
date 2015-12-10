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
                //访问服务操作，并且查看账户是否一致
                using (ServiceClient proxy = new ServiceClient(new WSHttpBinding(),
                            new EndpointAddress("http://localhost:8675/Service")))
                {
                    proxy.SuccessOperation();
                    proxy.Assert();
                    //这里将捕获到异常
                    try
                    {
                        proxy.FailOperation();
                    }
                    catch
                    {
                    }
                    proxy.Assert();
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
