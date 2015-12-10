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

namespace BitmapEffectsDemo
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
            BlurBitmapEffectDemo bbfd = new BlurBitmapEffectDemo();
            bbfd.Owner = this;
            bbfd.Show();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            BevelBitmapEffectDemo bed = new BevelBitmapEffectDemo();
            bed.Owner = this;
            bed.Show();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            EmbossBitmapEffectDemo ebed = new EmbossBitmapEffectDemo();
            ebed.Owner = this;
            ebed.Show();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            OuterGlowBitmapEffectDemo ogbe = new OuterGlowBitmapEffectDemo();
            ogbe.Owner = this;
            ogbe.Show();
        }
    }
}
