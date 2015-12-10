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

namespace BackgroundLinearGradientBrushDemo
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CreateButton();
        }

        //使用代码创建按钮，并赋前景和背景色。
        public void CreateButton()
        {
            Button btn = new Button();
            btn.Content = "这是代码创建的按钮";
            btn.Margin = new Thickness(10, 10, 10, 10);
            btn.Width = 200;
            Grid.SetRow(btn, 1);
            grd.Children.Add(btn);
            //设置按钮的前景色
            btn.Foreground = new SolidColorBrush(Colors.White);
            // 创建按钮背景所使用的渐变色 
            LinearGradientBrush myVerticalGradient =
                new LinearGradientBrush();
            myVerticalGradient.StartPoint = new Point(0.5, 0);
            myVerticalGradient.EndPoint = new Point(0.5, 1);
            myVerticalGradient.GradientStops.Add(
                new GradientStop(Colors.Yellow, 0.0));
            myVerticalGradient.GradientStops.Add(
                new GradientStop(Colors.Red, 0.25));
            myVerticalGradient.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.75));
            myVerticalGradient.GradientStops.Add(
                new GradientStop(Colors.LimeGreen, 1.0));
            //设置按钮的背景色
            btn.Background = myVerticalGradient;
        }

        public void ColorDemo()
        {
            btn1.Background = SystemColors.ActiveBorderBrush;
            btn1.Background = new SolidColorBrush(SystemColors.InactiveBorderColor);

            int red = 0; 
            int green = 255; 
            int blue = 0;
            //使用FromRgb静态方法创建一个颜色对象，作为SolidColorBrush的参数。
            btn1.Foreground = new SolidColorBrush(Color.FromRgb(red, green, blue));
            btn1.Foreground = new SolidColorBrush(Color.FromArgb(10, 100, 100, 100));
        }
    }
}
