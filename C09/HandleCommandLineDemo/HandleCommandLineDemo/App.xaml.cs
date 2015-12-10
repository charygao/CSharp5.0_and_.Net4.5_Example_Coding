using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
namespace HandleCommandLineDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //该布尔值将从命令行参数中获取，如果指定了特定的命令行参数，则将该布尔值设为True
            bool startMinimized = false;
            //命令行参数是一个字符串数组类型，遍历这个数组，寻找特定的命令行参数
            for (int i = 0; i != e.Args.Length; ++i)
            {
                if (e.Args[i] == "/StartMinimized")
                {
                    startMinimized = true;
                }                
            }
            // 创建应用程序主窗口，如果指定了命令行参数，则最小化应用程序主窗口，并在窗口显示第一个命令行参数
            Window1 win1 = new Window1();
            if (startMinimized)
            {
                win1.WindowState = WindowState.Minimized;
                win1.Content = "当前命令行参数为:" + e.Args[0];
            }
            win1.Show();            
        }
    }
}
