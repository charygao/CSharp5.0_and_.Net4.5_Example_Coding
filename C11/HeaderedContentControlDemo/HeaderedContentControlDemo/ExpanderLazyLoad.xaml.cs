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

namespace HeaderedContentControlDemo
{
    /// <summary>
    /// ExpanderLazyLoad.xaml 的交互逻辑
    /// </summary>
    public partial class ExpanderLazyLoad : Window
    {

        public ExpanderLazyLoad()
        {
            InitializeComponent();
        }
        //指定文件名。
        public const string FileName = "Chapter4.txt";
        private void expander1_Expanded(object sender, RoutedEventArgs e)
        {
            //获取文件的路径
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, FileName);
            //读取文本文件
            string str = File.ReadAllText(filePath, Encoding.Default);
            //赋文本文件的内容和当前的日期给TextBlock
            txt.Text = DateTime.Now.ToString() + Environment.NewLine + str;
        }
    }
}
