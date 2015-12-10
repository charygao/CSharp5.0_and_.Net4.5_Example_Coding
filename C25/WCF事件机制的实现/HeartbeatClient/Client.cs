using System;
using System.ServiceModel;
using System.Threading;
using System.ServiceModel.Channels;
namespace WCF.Third
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                EventHandler handler = new EventHandler();
                using (MyProxy proxy = new MyProxy(new InstanceContext(handler), 
                    new NetNamedPipeBinding(),
                    new EndpointAddress("net.pipe://localhost/EventService")))
                {
                    while (true)
                    {
                        String command = Console.ReadLine();
                        switch (command)
                        {
                            //输入q表示退出程序
                            case "q":
                                return;
                            case "s1":
                                {
                                    proxy.Subscribe(EventType.Event1);
                                    break;
                                }
                            case "s2":
                                {
                                    proxy.Subscribe(EventType.Event2);
                                    break;
                                }
                            case "s3":
                                {
                                    proxy.Subscribe(EventType.Event3);
                                    break;
                                }
                            case "s12":
                                {
                                    proxy.Subscribe(EventType.Event1|EventType.Event2);
                                    break;
                                }
                            case "s13":
                                {
                                    proxy.Subscribe(EventType.Event1 | EventType.Event3);
                                    break;
                                }
                            case "s23":
                                {
                                    proxy.Subscribe(EventType.Event3 | EventType.Event2);
                                    break;
                                }
                            case "s123":
                                {
                                    proxy.Subscribe(EventType.Event1 | EventType.Event2 | EventType.Event3);
                                    break;
                                }
                            case "u1":
                                {
                                    proxy.Unsubscribe(EventType.Event1);
                                    break;
                                }
                            case "u2":
                                {
                                    proxy.Unsubscribe(EventType.Event2);
                                    break;
                                }
                            case "u3":
                                {
                                    proxy.Unsubscribe(EventType.Event3);
                                    break;
                                }
                            case "u12":
                                {
                                    proxy.Unsubscribe(EventType.Event1 | EventType.Event2);
                                    break;
                                }
                            case "u13":
                                {
                                    proxy.Unsubscribe(EventType.Event1 | EventType.Event3);
                                    break;
                                }
                            case "u23":
                                {
                                    proxy.Unsubscribe(EventType.Event3 | EventType.Event2);
                                    break;
                                }
                            case "u123":
                                {
                                    proxy.Unsubscribe(EventType.Event1 | EventType.Event2 | EventType.Event3);
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
            }
            finally
            {
                Console.Read();
            }
        }
    }
    /// <summary>
    /// 回调契约的实现
    /// </summary>
    public class EventHandler:IEvents
    {
        public void OnEvent1()
        {
            Console.WriteLine("事件1触发。");
        }
        public void OnEvent2(int arg)
        {
            Console.WriteLine("事件2触发，参数：{0}。", arg);
        }
        public void OnEvent3(String arg)
        {
            Console.WriteLine("事件3触发，参数：{0}。", arg);
        }
    }
 
    /// <summary>
    /// 客户端代理的实现
    /// </summary>
    public class MyProxy : DuplexClientBase<IEventPublisher>, IEventPublisher
    {
        public MyProxy(InstanceContext context, Binding binding, EndpointAddress remoteAddress) :
            base(context, binding, remoteAddress) { }
        public void Subscribe(EventType events)
        {
            Channel.Subscribe(events);
        }
        public void Unsubscribe(EventType events)
        {
            Channel.Unsubscribe(events);
        }
    }
}
