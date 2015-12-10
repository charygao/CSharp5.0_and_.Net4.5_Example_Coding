using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SingleInstanceWithCommunication
{
   public class Startup
    {
       [STAThread]
       public static void Main(string[] args)
       {
           //实例化SingleApplicationBase类，并调用Run方法开始运行应用程序
           SingleApplicationBase sab = new SingleApplicationBase();
           sab.Run(args);
       }
    }
}
