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

namespace AttachedEvents
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //使用AddHandler方法关联附加事件
            stackpanel.AddHandler(Button.ClickEvent, new RoutedEventHandler(OnClick));            
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button)
            {
                MessageBox.Show(((Button)e.Source).Content.ToString());
            }
        }
    }
}
