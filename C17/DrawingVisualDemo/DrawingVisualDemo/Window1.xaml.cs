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
using System.Globalization;

namespace DrawingVisualDemo
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //实例化MyVisualHost对象
            MyVisualHost visualHost = new MyVisualHost();
            //添加到MyCanvas中
            MyCanvas.Children.Add(visualHost);
        }
    }
    // 创建一个派生自FrameworkElement的Visual宿主
    // 该类为Visual对象提供了布局、事件处理和容器支持
    public class MyVisualHost : FrameworkElement
    {
        // 创建子元素的集合私有变量
        private VisualCollection _children;
        //构造函数中添加DrawingVisual对象
        public MyVisualHost()
        {
            _children = new VisualCollection(this);
            _children.Add(CreateDrawingVisualRectangle());
            _children.Add(CreateDrawingVisualText());
            _children.Add(CreateDrawingVisualEllipses());
            //添加MouseLeftButtonUp事件处理器
            this.MouseLeftButtonUp += new MouseButtonEventHandler(MyVisualHost_MouseLeftButtonUp);
        }

        void MyVisualHost_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 获取当前鼠标所在的坐标位置
            Point pt = e.GetPosition((UIElement)sender);
            // 调用HitTest初始化命中测试，并指定myCallback回调函数
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallback), new PointHitTestParameters(pt));
        }

        //如果Visual对象被命中,设置其透明度指定其被命中
        public HitTestResultBehavior myCallback(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)result.VisualHit).Opacity == 1.0)
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 0.4;
                }
                else
                {
                    ((DrawingVisual)result.VisualHit).Opacity = 1.0;
                }
            }
            //停止命中测试
            return HitTestResultBehavior.Stop;
        }



        // 创建一个包含矩形的DrawingVisual
        private DrawingVisual CreateDrawingVisualRectangle()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            // 获取DrawingContext以便于创建一个绘图上下文
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            // 绘制一个矩形
            Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
            drawingContext.DrawRectangle(Brushes.LightBlue, (Pen)null, rect);
            // 保存绘图上下
            drawingContext.Close();
            return drawingVisual;
        }
        // 创建一个包含文本的DrawingVisual
        private DrawingVisual CreateDrawingVisualText()
        {
            // 创建DrawingVisual实例
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            //在DrawingContext上下文中绘制格式化文本字符串
            drawingContext.DrawText(
               new FormattedText("单击",
                  CultureInfo.GetCultureInfo("zh-cn"),
                  FlowDirection.LeftToRight,
                  new Typeface("Verdana"),
                  36, Brushes.Black),
                  new Point(200, 116));
            // 关闭DrawingContext以保存DrawingVisual的变更
            drawingContext.Close();
            return drawingVisual;
        }
        //创建一个包含矩形的DrawingVisual
        private DrawingVisual CreateDrawingVisualEllipses()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            //绘制矩形
            drawingContext.DrawEllipse(Brushes.Maroon, null, new Point(430, 136), 20, 20);
            drawingContext.Close();
            return drawingVisual;
        }
        // 重载VisualChildrenCount方法，反回当前的DrawingVisual数量
        protected override int VisualChildrenCount
        {
            get { return _children.Count; }
        }
        // 提供所需要的GetVisualChild重载方法
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return _children[index];
        }
    }

}
