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
//加入此命名空间，用于读取文本文件。
using System.IO;
namespace ScrollViewer
{
    public partial class ComplexScrollViewer : Window
    {
        public const string FileName = "Chapter4.txt";
        public ComplexScrollViewer()
        {
            InitializeComponent();
            //在构造函数中，从文本文件中加载TextBlock内容。
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, FileName);
            string str = File.ReadAllText(filePath,Encoding.Default);
            txt1.Text = str;
        }
        private void svLineUp(object sender, RoutedEventArgs e)
        {
            //向上滚动一行
            sv1.LineUp();
        }
        private void svLineDown(object sender, RoutedEventArgs e)
        {
            //向下滚动一行
            sv1.LineDown();
        }
        private void svLineRight(object sender, RoutedEventArgs e)
        {
            //向右滚动一行
            sv1.LineRight();
        }
        private void svLineLeft(object sender, RoutedEventArgs e)
        {
            //向左滚动一行
            sv1.LineLeft();
        }
        private void svPageUp(object sender, RoutedEventArgs e)
        {
            //向上滚动一页
            sv1.PageUp();
        }
        private void svPageDown(object sender, RoutedEventArgs e)
        {
            //向下滚动一页
            sv1.PageDown();
        }
        private void svPageRight(object sender, RoutedEventArgs e)
        {
            //向右滚动一页
            sv1.PageRight();
        }
        private void svPageLeft(object sender, RoutedEventArgs e)
        {
            //向左滚动一页
            sv1.PageLeft();
        }
    }
}
