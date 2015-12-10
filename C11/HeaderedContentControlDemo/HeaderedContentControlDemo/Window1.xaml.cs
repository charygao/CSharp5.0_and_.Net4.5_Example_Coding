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

namespace HeaderedContentControlDemo
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GroupBoxDemo gbd = new GroupBoxDemo();
            gbd.Owner = this;
            gbd.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            TabItemDemo tid = new TabItemDemo();
            tid.Owner = this;
            tid.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ExpanderDemo ed = new ExpanderDemo();
            ed.Owner = this;
            ed.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ExpanderLazyLoad ell = new ExpanderLazyLoad();
            ell.Owner = this;
            ell.Show();
        }
    }
}
