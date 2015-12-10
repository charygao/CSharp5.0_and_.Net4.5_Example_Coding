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

namespace StackPanelLoadedDemo
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

        private void stackpanel_Loaded(object sender, RoutedEventArgs e)
        {
            ////设置StackPanel的布局方向
            //stackpanel.Orientation = Orientation.Horizontal;
            ////循环添加4个Button
            //for (int i = 0; i <= 3; i++)
            //{
            //    Button btn = new Button();
            //    btn.Content = "Loaded事件示例";
            //    stackpanel.Children.Add(btn);
            //}
        }

        private void stackpanel_Initialized(object sender, EventArgs e)
        {
            stackpanel.Orientation = Orientation.Horizontal;
            for (int i = 0; i <= 3; i++)
            {
                Button btn = new Button();
                btn.Content = "Loaded事件示例";
                stackpanel.Children.Add(btn);
            }
            stackpanel.Orientation = Orientation.Vertical;
        }
    }
}
