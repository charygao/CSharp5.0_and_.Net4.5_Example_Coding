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
                //创建服务实例
                Service instance = new Service();
                instance._count = 0;
                //使用手动创建的服务实例初始化ServiceHost
                using (ServiceHost host = new ServiceHost(instance))
                {
                    host.Open();
                    Console.WriteLine("服务已经启动！");
                    //这里通过SingletonInstance属性访问服务实例
                    Service myinstance = (Service)host.SingletonInstance;
                    Console.WriteLine(myinstance._count);
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