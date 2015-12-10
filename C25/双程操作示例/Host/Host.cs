using System;
using System.ServiceModel;
namespace WCF.Third
{
    /// <summary>
    /// 寄宿程序
    /// </summary>
    class Host
    {
        static void Main(string[] args)
        {
            try
            {
                //为了能否访问服务对象，这里手动创建服务对象并以该对象创建寄宿对象。
                HeartbeatService instance = new HeartbeatService();
                using (ServiceHost host = new ServiceHost(instance))
                {
                    //打开服务
                    host.Open();
                    Console.WriteLine("服务已经启动。");
                    //这里供用户在Console窗体中输入命令
                    while (true)
                    {
                        char command = Convert.ToChar(Console.Read());
                        switch (command)
                        {
                                //输入q表示退出程序
                            case 'q':
                                return;
                                //输入h表示切换到高负荷
                            case 'h':
                                {
                                    //通过ServiceHost的SingletonInstance属性来获得寄宿实例
                                    HeartbeatService service = (HeartbeatService)host.SingletonInstance;
                                    if (service != null)
                                        service.HighLoad = true;
                                    break;
                                }
                                //输入l表示切换到低负荷
                            case 'l':
                                {
                                    HeartbeatService service = (HeartbeatService)host.SingletonInstance;
                                    if (service != null)
                                        service.HighLoad = false;
                                    break;
                                }
                            default:
                                break;
                        }
                    }
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
