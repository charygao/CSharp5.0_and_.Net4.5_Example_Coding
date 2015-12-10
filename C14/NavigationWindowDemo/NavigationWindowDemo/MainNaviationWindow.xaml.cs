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
using System.Windows.Navigation;

namespace NavigationWindowDemo
{
    /// <summary>
    /// MainNaviationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainNaviationWindow : NavigationWindow
    {
        public MainNaviationWindow()
        {
            InitializeComponent();
            Image img = new Image();
            BitmapImage bimg = new BitmapImage(new Uri("php.gif", UriKind.Relative));
            img.Source = bimg;
            img.Stretch = Stretch.None;
            //为导航窗体指定图像内容
            Navigate(img);
        }
    }
}
