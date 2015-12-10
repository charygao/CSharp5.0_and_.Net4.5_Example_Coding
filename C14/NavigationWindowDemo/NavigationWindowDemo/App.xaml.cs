using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;

namespace NavigationWindowDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //需要在命名空间区添加对System.Windows.Navigation的引用
            NavigationWindow nw = new NavigationWindow();
            nw.Content = new Page1();
            nw.Show();
        }
    }
}
