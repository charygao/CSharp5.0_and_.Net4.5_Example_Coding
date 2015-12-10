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
namespace AccessingCurrentApplication
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        //添加一个当前窗口计数器
        private int newWindowCount=0;
        //当主窗口激活时，向windowMenuItem的子菜单添加菜单项，每个菜单项显示窗口的标题
        void MainWindow_Activated(object sender, EventArgs e)
        {
            this.windowMenuItem.Items.Clear();
            int windowCount = 0;
            //这里使用Application.Current.Windows属性
            foreach (Window window in Application.Current.Windows)
            {
                ++windowCount;
                MenuItem menuItem = new MenuItem();
                menuItem.Tag = window;
                menuItem.Header = window.Title;
                menuItem.Click += new RoutedEventHandler(menuItem_Click);
                this.windowMenuItem.Items.Add(menuItem);
            }
        }
        //当单击菜单项时，激活窗口
        void menuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            ((Window)menuItem.Tag).Activate();
        }
        //当单击新建按钮时，创建一个新的窗口，并设置当前窗口内容为窗口标题
        private void newWindowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window win1 = new Window();
            win1.Height = 300;
            win1.Width = 300;
            ++newWindowCount;
            win1.Content=win1.Title = "这是第" + newWindowCount.ToString().PadLeft(2, '0') + "个子窗口";
            win1.Show();
        }
        //当单击退出按钮时，直接关闭主窗口，这里必须在App.xaml中设置ShutdownMode为OnMainWindowClose。
        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

    }
}
