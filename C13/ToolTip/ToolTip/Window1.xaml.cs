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
using System.Windows.Controls.Primitives;

namespace ToolTip
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //关联ToolTipService的两个依赖事件
            ellipse2.AddHandler(ToolTipService.ToolTipOpeningEvent,new RoutedEventHandler(whenToolTipOpens));
            ellipse2.AddHandler(ToolTipService.ToolTipClosingEvent,new RoutedEventHandler(whenToolTipCloses));            
        }
        //在ToolTip打开前，改变元素的前景色为蓝色
        void whenToolTipOpens(object sender, RoutedEventArgs e)
        {
            Ellipse ell = new Ellipse();
            if (sender.GetType().FullName.Equals("System.Windows.Shapes.Ellipse"))
            {
                ell = (Ellipse)sender;
                ell.Fill = Brushes.Blue;
            }
            else if (sender.GetType().FullName.Equals(
                                     "System.Windows.Controls.ToolTip"))
            {
                System.Windows.Controls.ToolTip t = (System.Windows.Controls.ToolTip)sender;
                Popup p = (Popup)t.Parent;
                ell = (Ellipse)p.PlacementTarget;
                ell.Fill = Brushes.Blue;
            }
        }
        //在ToolTip关闭后，改变元素的前景色为灰色
        void whenToolTipCloses(object sender, RoutedEventArgs e)
        {
            Ellipse ell = new Ellipse();
            if (sender.GetType().FullName.Equals(
                              "System.Windows.Shapes.Ellipse"))
            {
                ell = (Ellipse)sender;
                ell.Fill = Brushes.Gray;
            }
            else if (sender.GetType().FullName.Equals(
                                   "System.Windows.Controls.ToolTip"))
            {
                System.Windows.Controls.ToolTip t = (System.Windows.Controls.ToolTip)sender;
                Popup p = (Popup)t.Parent;
                ell = (Ellipse)p.PlacementTarget;
                ell.Fill = Brushes.Gray;
            }            
        }


        private void ToolTip_Opened(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("工具提示条被打开了");
        }

        private void ToolTip_Closed(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("工具提示条被关毕了");
        }
    }
}
