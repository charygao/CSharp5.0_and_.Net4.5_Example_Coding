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

namespace MouseInputInfo
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
        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            //获取相对于窗口的X,Y坐标
            Point position = e.GetPosition(Canvas1);
            double pX = position.X;
            double pY = position.Y;
            //设置矩形的宽度和高度
            ellipse.Width = pX;
            ellipse.Height = pY;
            //获取当前鼠标指针所在的位置
            xPositionLabel.Text = pX.ToString();
            yPositionLabel.Text = pY.ToString();
        }

    }
}
