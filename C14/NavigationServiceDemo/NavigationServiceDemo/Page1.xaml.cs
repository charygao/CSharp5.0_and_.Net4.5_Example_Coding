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

namespace NavigationServiceDemo
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        private NavigationService ns;
        public Page1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page1_Loaded);
        }

        void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            //获取NavigationService对象实例
            ns = NavigationService.GetNavigationService(this);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            //ns.Navigate("Page2.xaml");
            //为导航指定一个导航内容对象
            ns.Navigate(new Page2());
            //使用指定的Uri来导航一个页面
            ns.Navigate(new Uri("Page2.xaml", UriKind.Relative));
        }
        //前进按钮
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (ns.CanGoForward)
            {
                ns.GoForward();
            }
        }
        //后退按钮
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (ns.CanGoBack)
            {
                ns.GoBack();
            }
        }
        //停止按钮
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            ns.StopLoading();
        }
        //刷新按钮
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            ns.Refresh();
        }
    }
}
