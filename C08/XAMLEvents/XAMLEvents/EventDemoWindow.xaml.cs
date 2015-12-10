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

namespace XAMLEvents
{
    /// <summary>
    /// EventDemoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EventDemoWindow : Window
    {
        public EventDemoWindow()
        {
            InitializeComponent();
        }
        public void MakeButton(object sender, RoutedEventArgs e)
        {
            Button b2 = new Button();
            b2.Content = "新按钮";
            // 为按钮关联事件处理器. 除了使用+=添加事件处理器外，也可以使用-=移除事件处理器
            b2.Click += new RoutedEventHandler(Onb2Click);
            root.Children.Insert(root.Children.Count, b2);
            DockPanel.SetDock(b2, Dock.Top);
            text1.Text = "现在单击第二个按钮";
            b1.IsEnabled = false;
        }
       public void Onb2Click(object sender, RoutedEventArgs e)
       {
           text1.Text = "新按钮(b2)己经被单击!!";
       }

    }
}
