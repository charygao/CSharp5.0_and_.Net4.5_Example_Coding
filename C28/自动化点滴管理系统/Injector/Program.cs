using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;
using System.ServiceModel.Channels;
namespace WCF.CaseStudy
{
    static class Program
    {
        /// <summary>
        /// 入口方法
        /// </summary>
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //创建主窗体对象
            InjectorConsole console = new InjectorConsole();
            //创建代理
            using (ServiceProxy proxy = new ServiceProxy(
                    new InstanceContext(console),
                    new NetTcpBinding(),
                    new EndpointAddress("net.tcp://localhost:12000/Service")))
            {
                //代开代理
                proxy.Open();
                using (HeartBeat hb = new HeartBeat(proxy,console))
                {
                    //将代理的引用赋值给窗体对象
                    console.SetProxy(proxy);
                    Application.Run(console);
                    console.RemoveRroxy();
                }
            }
        }
    }
}
