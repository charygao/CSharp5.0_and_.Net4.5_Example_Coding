using System;
using System.ServiceModel;
namespace WCF.Fourth
{
    class Host
    {
        static void Main(string[] args)
        {
            try
            {
                using (ServiceHost host = new ServiceHost(typeof(Service)))
                {
                    host.Open();
                    Console.WriteLine("服务已经启动！");
                    Console.Read();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
        }
    }
}