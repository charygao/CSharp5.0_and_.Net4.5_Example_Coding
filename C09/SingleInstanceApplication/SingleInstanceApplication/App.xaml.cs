using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
//添加此命名空间用于引用Mutex
using System.Threading;
namespace SingleInstanceApplication
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        Mutex mutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //检查己经存在的实例
            string mutexName = "SingleInstanceApplication";
            bool CreatedNew;
            mutex = new Mutex(true, mutexName,out CreatedNew);
            //如果这里有一个己经存在的实例，则关闭当前实例
            if (!CreatedNew)
            {
                MessageBox.Show("己经存在一个应用程序实例");
                Shutdown();
            }
        }
    }
}
