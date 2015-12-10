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

namespace BindingToElementDemo
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

        public void CreateBinding()
        {
            //实例化一个新的绑定类型
            Binding binding = new Binding();
            //指定绑定来源
            binding.Source = scroll;
            //指定绑定路径
            binding.Path = new PropertyPath("Value");
            //指定绑定模式，或称为绑定方向
            binding.Mode = BindingMode.TwoWay;
            //调用SetBinding进行绑定
            scrollfontsize.SetBinding(ContentProperty, binding);
        }

    }
}
