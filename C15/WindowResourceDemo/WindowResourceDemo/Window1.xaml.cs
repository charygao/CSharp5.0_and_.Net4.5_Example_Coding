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

namespace WindowResourceDemo
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

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            ////变更静态资源的ImageBrush属性
            //ImageBrush img = (ImageBrush)this.Resources["TileBrush"];
            //img.Viewport = new Rect(0, 0, 5, 5);    

            this.Resources["TileBrush"] = new SolidColorBrush(Colors.AliceBlue);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            //查找资源并进行强制类型转换
            b.Background = (Brush)this.FindResource("TileBrush");
        }
    }
}
