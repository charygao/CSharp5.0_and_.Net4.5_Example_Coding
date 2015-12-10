using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//添加如下的命名空间
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
namespace SingleInstanceWithCommunication
{
    public class SingleApplicationBase:WindowsFormsApplicationBase
    {
        public SingleApplicationBase()
        {
            //设置为允许单实例模式
            this.IsSingleInstance = true;
        }
        //创建WPF的Application类
        private App wpfApp;
        //重载OnStartup方法，当应用程序启动时，创建WPF应用程序类
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            wpfApp = new App();
            //应行WPF应用程序
            wpfApp.Run();
            return false;
        }
        //当有其他应用程序实例化时，则触发此事件，将在WPF应用程序中显示一个新的窗口
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);
            if (eventArgs.CommandLine.Count > 0)
            {
                wpfApp.ShowWindowText(eventArgs.CommandLine[0]);
            }
        }
    }
}
