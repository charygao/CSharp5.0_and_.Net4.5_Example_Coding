using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaveandRestoreWindowState
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            try
            {
                //从用户配置中恢复窗口大小。
                Rect restoreBounds = Properties.Settings.Default.WindowPlacement;
                WindowState = WindowState.Normal;
                //分别为窗口的左、上、宽和高赋值。
                Left = restoreBounds.Left;
                Top = restoreBounds.Top;
                Width = restoreBounds.Width;
                Height = restoreBounds.Height;
                //从配置文件中恢复窗口的WindowState状态
                WindowState = Properties.Settings.Default.MainWindowState;
            }
            catch { }
            // 为主窗口添加关闭事件
            this.Closing += new System.ComponentModel.CancelEventHandler(Window1_Closing);
        }
        void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //当窗口关闭时，保存配置信息
            Properties.Settings.Default.WindowPlacement = RestoreBounds;
            Properties.Settings.Default.MainWindowState = WindowState;
            Properties.Settings.Default.Save();
        }
    }
}
