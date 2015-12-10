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

namespace TransformDemo
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
            TranslateTransformDemo ttd = new TranslateTransformDemo();
            ttd.Owner = this;
            ttd.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            RotateTransformDemo rtd = new RotateTransformDemo();
            rtd.Owner = this;
            rtd.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransformDemo stf = new ScaleTransformDemo();
            stf.Owner = this;
            stf.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            SkewTransformDemo std = new SkewTransformDemo();
            std.Owner = this;
            std.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
