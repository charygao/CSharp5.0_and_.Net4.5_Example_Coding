using System;
using System.ServiceModel;
using System.Windows.Forms;
namespace WCF.CaseStudy
{
    static class Program
    {
        /// <summary>
        /// 程序的入口
        /// </summary>
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //初始化一个服务实例
            ControlCenter cc = new ControlCenter();
            //初始化主窗体
            Console console = new Console(cc.CallbackList);
            //为主窗体定语服务中定义的事件，以使得窗体能够得到客户端访问服务的消息
            #region here add the events handlers
            cc.AddClientEventHandler(ClientEventType.StartMainline, console.StartMainlineHandler);
            cc.AddClientEventHandler(ClientEventType.EndMainline, console.EndMainlineHandler);
            cc.AddClientEventHandler(ClientEventType.EmergentCall, console.EmergentCall);
            cc.AddClientEventHandler(ClientEventType.EndEmergentCall, console.EndEmergentCall);
            cc.AddClientEventHandler(ClientEventType.MissHeartBeat, console.MissHeartBeat);
            cc.AddClientEventHandler(ClientEventType.HeartBeat, console.HeaertBeat);
            #endregion
            //初始化ServiceHost
            using (ServiceHost host = new ServiceHost(cc))
            {
                //开启服务
                host.Open();
                //开启主窗体
                Application.Run(console);
            }
        }
    }
}

