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

namespace PathGeometriesDemo1
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
            GeomotryGroupDemo ggd = new GeomotryGroupDemo();
            ggd.Owner = this;
            ggd.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CombinedGeometryDemo cgd = new CombinedGeometryDemo();
            cgd.Owner = this;
            cgd.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            PathGeometryObjectDemo1 pgod = new PathGeometryObjectDemo1();
            pgod.Owner = this;
            pgod.Show();
        }
    }
}
