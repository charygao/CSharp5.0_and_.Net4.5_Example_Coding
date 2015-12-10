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
//添加如下的命名空间
using System.IO;
using System.Windows.Markup;
namespace XamlReaderDemo
{
    /// <summary>
    /// LoadXamlFromStream.xaml 的交互逻辑
    /// </summary>
    public partial class LoadXamlFromStream : Window
    {
        private Button btn1;
        public LoadXamlFromStream()
        {
            InitializeComponent();
            Title = "动态加载XAML文档示例";
            //从资源文件中加载XAML文档，并作为窗口的内容
            Uri uri = new Uri("/XamlSnippet.xaml",UriKind.RelativeOrAbsolute);
            Stream stream = Application.GetResourceStream(uri).Stream;
            FrameworkElement el = XamlReader.Load(stream) as FrameworkElement;
            Content = el;
            btn1 = el.FindName("b1") as Button;
            if (btn1 != null)
            { 
                btn1.Click+=new RoutedEventHandler(btn1_Click);
            }
        }
        void btn1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("按钮被点击了，事实上本按钮是来自一个单独的XAML文档");
        }
    }
}
