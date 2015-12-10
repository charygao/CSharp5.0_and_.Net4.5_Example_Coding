using System;
//必须在类中添加此命名空间
using System.Windows;
namespace CreateApplicationByHand
{
    public class Startup
    {
        //[STAThread]
        //public static void Main()
        //{
        //    //创建一个Application对象
        //    Application app = new Application();
        //    //实例化Window1对象，作为应用程序的主窗口
        //    Window1 win = new Window1();
        //    //指定应用程序的标题
        //    win.Title = "这是应用程序的主窗口";
        //    //调用Run方法开始运行应用程序，显示主窗口
        //    app.Run(win);
        //}


        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            Window1 win = new Window1();
            win.Title = "这是应用程序的主窗口";
            win.Show();
            app.Run();
        }
    }
}
