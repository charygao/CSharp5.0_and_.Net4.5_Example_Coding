using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
//在命名空间中添加如下的代码：
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections;

namespace ApplicationEventDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public void OnStartup(object sender,StartupEventArgs e)
        {
            Window1 win = new Window1();
            win.Title = "这是通过OnStartup事件启动的主窗口";
            win.Show();
            //创建第二个窗口，目的用于演示Actived和DeActived事件
            Window2 win2 = new Window2();
            win2.Title = "在OnStartup事件中打开的第二窗口";
            win2.Show();
        }

        protected override void OnActivated(EventArgs e)
        {
            System.Diagnostics.Debug.Write("当前应用程序被激活！");
            //当应用程序激活后，变不再处理任何窗口激活的信息，因此，下面的代码将不会产生任何效果。
            //要处理Window的激活，需要处理窗口事件，本书后面会有讨论。
            foreach(Window win in Windows)
            {
                if (win.IsActive)
                {
                    System.Diagnostics.Debug.WriteLine("当前的活动窗口是：" + win.Title);
                }
            }
            base.OnActivated(e);
        }
        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            System.Diagnostics.Debug.WriteLine("当前应用程序停止激活！");
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string err = "异常信息为: " + e.Exception.Message;
            MessageBox.Show(err, "Exception", MessageBoxButton.OK);
            //表示己经处理过异常，将不会传递异常给操作系统
            e.Handled = true; 
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            // 询问用户是否允许终止会话
            string msg = string.Format("{0}.是否要终止Windows会话?", e.ReasonSessionEnding);
            MessageBoxResult result = MessageBox.Show(msg, "Session Ending", MessageBoxButton.YesNo);
            // 如果单击YES，则允许终止，否则禁止终止会话
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        //定义应用程序退出码的枚举字段
        public enum ApplicationExitCode
        {
            Success = 0,
            Failure = 1,
            CantWriteToApplicationLog = 2,
            CantPersistApplicationState = 3
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                // 向应用程序日志写入项
                if (e.ApplicationExitCode == (int)ApplicationExitCode.Success)
                {
                    WriteApplicationLogEntry("Failure", e.ApplicationExitCode);
                }
                else
                {
                    WriteApplicationLogEntry("Success", e.ApplicationExitCode);
                }
            }
            catch
            {
                //当写入应用程序失败时，更新退出代码以反映出写入失败
                e.ApplicationExitCode = (int)ApplicationExitCode.CantWriteToApplicationLog;
            }
            // 保存应用程序状态
            try
            {
                PersistApplicationState();
            }
            catch
            {
                // 当写入应用程序失败时，更新退出代码以反映出写入失败
                e.ApplicationExitCode = (int)ApplicationExitCode.CantPersistApplicationState;
            }
        }
        private void WriteApplicationLogEntry(string message, int exitCode)
        {
            //写入日志项到用户隔离存储区
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly();
            using (Stream stream = new IsolatedStorageFileStream("log.txt", FileMode.Append, FileAccess.Write, store))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                string entry = string.Format("{0}: {1} - {2}", message, exitCode, DateTime.Now);
                writer.WriteLine(entry);
            }
        }
       private void PersistApplicationState()
        {
            // 保存应用程序状态到用户隔离存储区
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly();
            using (Stream stream = new IsolatedStorageFileStream("state.txt", FileMode.Create, store))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                //可以在这里更改为自定义的保存应用程序状态的程序代码
                foreach (DictionaryEntry entry in this.Properties)
                {
                    writer.WriteLine(entry.Value);
                }
            }
        }

             
    }
}
