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

namespace BindingToElementDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Owner = this;
            win.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            TwoWayBinding twb = new TwoWayBinding();
            twb.Owner = this;
            twb.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MultiBindings mtb = new MultiBindings();
            mtb.Owner = this;
            mtb.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            UpdateSourceTrigger ust = new UpdateSourceTrigger();
            ust.Owner = this;
            ust.Show();
        }
    }
}
