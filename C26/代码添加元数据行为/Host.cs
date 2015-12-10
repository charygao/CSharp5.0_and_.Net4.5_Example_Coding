using System;
using System.ServiceModel;
using System.ServiceModel.Description;
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
                    //这里添加元数据行为
                    ServiceMetadataBehavior metadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    if (metadataBehavior == null)
                    {
                        metadataBehavior = new ServiceMetadataBehavior();
                        metadataBehavior.HttpGetEnabled = true;
                        host.Description.Behaviors.Add(metadataBehavior);
                    }
                    host.Open();
                    Console.WriteLine("服务已经启动！");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //这里服务已经关闭
            Console.WriteLine("服务已经关闭！");
            Console.ReadLine();
        }
    }
}