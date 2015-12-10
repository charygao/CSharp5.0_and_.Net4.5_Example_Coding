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

namespace ShowingaWindow
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            foreach (Window ownedWindow in this.OwnedWindows)
            {
                System.Diagnostics.Debug.WriteLine(ownedWindow.Title);
            }
        }

        private void btnmodel_Click(object sender, RoutedEventArgs e)
        {
            ShowingWindow sw = new ShowingWindow();
            //显示模式窗口
            sw.ShowDialog();
        }
        private void btnmodeless_Click(object sender, RoutedEventArgs e)
        {
            ShowingWindow sw = new ShowingWindow();
            //设置sw窗口的宿主为当前窗口
            sw.Owner = this;
            //显示非模式窗口
            sw.Show();
        }
    }
}
