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

namespace PolyLineDemo
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CreatePolyLine();
        }
        private void CreatePolyLine()
        {
            // 添加多段线
            Polyline myPolyline = new Polyline();
            //定义线条颜色
            myPolyline.Stroke = Brushes.Red;
            //线宽
            myPolyline.StrokeThickness = 2;
            //填充规则
            myPolyline.FillRule = FillRule.EvenOdd;
            //指定多边形的点 
            Point Point4 = new Point(1, 50);
            Point Point5 = new Point(10, 80);
            Point Point6 = new Point(20, 40);
            //将定义的点添加到PointCollection集合中
            PointCollection myPointCollection2 = new PointCollection();
            myPointCollection2.Add(Point4);
            myPointCollection2.Add(Point5);
            myPointCollection2.Add(Point6);
            //指定多边形的Points属性为前面定义的PointCollection集合
            myPolyline.Points = myPointCollection2;
            cav.Children.Add(myPolyline);
        }
    }
}
