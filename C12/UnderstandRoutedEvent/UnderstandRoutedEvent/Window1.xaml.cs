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

namespace UnderstandRoutedEvent
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
        int i = 0;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ++i;
            StringBuilder eventstr = new StringBuilder();
            //获取触发事件的元素
            FrameworkElement fe = (FrameworkElement)sender;
            //显示触发的次序
            eventstr.Append("触发时次序：" + i.ToString()+"\n");
            eventstr.Append("触发事件的元素名：");
            eventstr.Append(fe.Name);
            eventstr.Append("\n");
            //获取事件源，也就是是由哪个元素所引发的事件。
            FrameworkElement fe2 = (FrameworkElement)e.Source;
            eventstr.Append("事件源类型：");
            eventstr.Append(e.Source.GetType().ToString());
            eventstr.Append("\n");
            eventstr.Append(" 名称：");
            eventstr.Append(fe2.Name);
            eventstr.Append("\n");
            //获知事件传递的方法
            eventstr.Append("路由策略：");
            eventstr.Append(e.RoutedEvent.RoutingStrategy);
            eventstr.Append("\n");
            textBox1.Text += eventstr.ToString();
        }
    }
}
