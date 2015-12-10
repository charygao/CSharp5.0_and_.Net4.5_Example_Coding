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
                EventPublisher instance = new EventPublisher();
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
                            case '1':
                                {
                                    //通过ServiceHost的SingletonInstance属性来获得寄宿实例
                                    EventPublisher service = (EventPublisher)host.SingletonInstance;
                                    if (service != null)
                                        service.OnEvent(EventType.Event1);
                                    break;
                                }
                            case '2':
                                {
                                    //通过ServiceHost的SingletonInstance属性来获得寄宿实例
                                    EventPublisher service = (EventPublisher)host.SingletonInstance;
                                    if (service != null)
                                        service.OnEvent(EventType.Event2,0);
                                    break;
                                }
                            case '3':
                                {
                                    //通过ServiceHost的SingletonInstance属性来获得寄宿实例
                                    EventPublisher service = (EventPublisher)host.SingletonInstance;
                                    if (service != null)
                                        service.OnEvent(EventType.Event3,"a");
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
