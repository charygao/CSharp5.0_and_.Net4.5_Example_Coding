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

namespace TextBlockDemo
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            CreateTextBlock();
            Menu
        }

        private void CreateTextBlock()
        {
            TextBlock textBlock1 = new TextBlock();
            TextBlock textBlock2 = new TextBlock();
            //指定TextBlock的格式
            textBlock1.TextWrapping = textBlock2.TextWrapping = TextWrapping.Wrap;
            textBlock2.Background = Brushes.AntiqueWhite;
            textBlock2.TextAlignment = TextAlignment.Center;
            //使用内联元素为TextBlock添加文本
            textBlock1.Inlines.Add(new Bold(new Run("TextBlock")));
            textBlock1.Inlines.Add(new Run(" 被设计为一个 "));
            textBlock1.Inlines.Add(new Italic(new Run("轻量级的")));
            textBlock1.Inlines.Add(new Run(",特别适合于整合"));
            textBlock1.Inlines.Add(new Italic(new Run("小型")));
            textBlock1.Inlines.Add(new Run(" 部分的流式内容到用户界面"));
            //指定TextBlock2的Text属性
            textBlock2.Text =
                "默认情况下, 一个TextBlock只是显简单的文本内容";
            stackpanel.Children.Add(textBlock1);
            stackpanel.Children.Add(textBlock2);
        }
    }
}
