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

namespace MessageBoxDemo
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

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("一个简单的消息框");
            MessageBox.Show("消息框的内容", "消息框的标题", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            CustomerMessageBox cmb = new CustomerMessageBox();
            cmb.Owner = this;
            cmb.Show();
        }
    }
}
