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

namespace CaptureMouseDemo
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
        //根据复选框的选中与否开启追踪
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rec = e.Source as Rectangle;
            if (rec != null)
            {
                if (cb1.IsChecked==true)
                {
                    Mouse.Capture(rec);
                    IInputElement ui = Mouse.Captured;
                    txtInfo.Text = ui.ToString();
                }
                else
                {
                    Mouse.Capture(null);
                    txtInfo.Text = "当前没有开启追踪";
                }
            }
        }
        //鼠标放开时，更新矩形的位置
        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition(canvas1);
            Canvas.SetLeft(rectangle1, pt.X);
            Canvas.SetTop(rectangle1, pt.Y);
        }
        //鼠标右键单击时，
        private void rectangle1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Captured != null)
            {
                Mouse.Capture(null);
                cb1.IsChecked = false;
                txtInfo.Text = "当前没有开启追踪";
            }
        }
    }
}
