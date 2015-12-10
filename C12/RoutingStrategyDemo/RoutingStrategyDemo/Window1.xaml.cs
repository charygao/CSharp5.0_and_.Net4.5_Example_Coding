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

namespace RoutingStrategyDemo
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
        //Grid鼠标单击遂道事件
        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txt.Text += "Grid_PreviewMouseDown" + Environment.NewLine;
            e.Handled = true;
        }
        //鼠标单击遂道事件
        private void btn1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txt.Text += "btn1_PreviewMouseDown" + Environment.NewLine;
        }
        //StackPanel鼠标单击遂道事件
        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txt.Text += "StackPanel_PreviewMouseDown" + Environment.NewLine;
        }
        //StackPanel鼠标单击事件
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txt.Text += "StackPanel_MouseDown" + Environment.NewLine;
        }
        //Image遂道事件
        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txt.Text += "Image_PreviewMouseDown" + Environment.NewLine;
        }
        //Image鼠标单击事件
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txt.Text += "Image_MouseDown" + Environment.NewLine;
        }
        //Button按钮单击事件
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txt.Text += "Click" + Environment.NewLine;
        }
    }
}
