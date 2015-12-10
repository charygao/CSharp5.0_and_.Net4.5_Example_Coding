using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
namespace SingleInstanceWithCommunication
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        //重载OnStartup方法，显示应用程序的主窗口，并显示命令行参数文本文件
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow win = new MainWindow();
            this.MainWindow = win;  
            win.Show();
            if (e.Args.Length > 0)
            {
                ShowWindowText(e.Args[0]);
            }
        }
        //实例化一个显示文本文件的窗口
        public void ShowWindowText(string fileName)
        {
            Window1 win = new Window1();
            win.Title = fileName;
            ((MainWindow)this.MainWindow).LstBox.Items.Add(fileName);
            win.Owner = this.MainWindow;
            win.LoadFile(fileName);
            win.Show();            
        }                  
    }
}
