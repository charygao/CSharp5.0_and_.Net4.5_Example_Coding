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
using System.Windows.Shapes;

namespace HeaderedContentControlDemo
{
    /// <summary>
    /// ExpanderDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ExpanderDemo : Window
    {
        public ExpanderDemo()
        {
            InitializeComponent();
        }

        private void expander1_Expanded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("我被展开了");
        }

        private void expander1_Collapsed(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("我被收起了");
        }
    }
}
