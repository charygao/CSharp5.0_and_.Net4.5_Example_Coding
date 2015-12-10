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

namespace SharpedWindow
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
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //定义一个是否可以调整宽度的布尔值
        bool isWiden = false;
        private void LeftButtonDown(object sender, MouseEventArgs e)
        {
            //如果用户按下的鼠标左键，则允许调整宽度
            isWiden = true;
        }
        //当鼠标左键移动时，开始捕捉鼠标，并调整当前窗口的宽度
        private void RectangleMouseMove(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            if (isWiden)
            {
                rect.CaptureMouse();
                double newWidth = e.GetPosition(this).X + 5;
                if (newWidth > 0) this.Width = newWidth;
            }
        }
        //当鼠标左键释放时，停止鼠标捕捉
        private void LeftButtonUp(object sender, MouseEventArgs e)
        {
            isWiden = false;
            // 停止捕捉鼠标
            Rectangle rect = (Rectangle)sender;
            rect.ReleaseMouseCapture();
        }
    }
}
