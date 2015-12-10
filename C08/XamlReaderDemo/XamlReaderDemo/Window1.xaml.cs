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
using System.Windows.Markup;
using System.IO;
namespace XamlReaderDemo
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        private Button btn1;
        public Window1()
        {
            InitializeComponent();
            Title = "动态加载XAML文档示例";
            //读取XamlSnippet.xaml文件
            FileStream fs = new FileStream("XamlSnippet.xaml", FileMode.Open);
            //调用XamlReader方法加载文件流，并转换为DependencyObject基类。
            DependencyObject rootElement = (DependencyObject)XamlReader.Load(fs);
            //将XAML中的内容设置为窗口内容
            this.Content = rootElement;            
            //从逻辑树中搜索XAML中具有指定元素名称的元素。
            btn1 = (Button)LogicalTreeHelper.FindLogicalNode(rootElement, "b1");
            //为按钮绑定事件处理器
            btn1.Click += new RoutedEventHandler(btn1_Click);        
        }
        void btn1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("按钮被点击了，事实上本按钮是来自一个单独的XAML文档");
        }
    }
}
