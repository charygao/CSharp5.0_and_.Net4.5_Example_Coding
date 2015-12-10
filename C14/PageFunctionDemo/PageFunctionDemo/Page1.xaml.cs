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

namespace PageFunctionDemo
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            PageFunction1 pf = new PageFunction1();
            pf.Return += new ReturnEventHandler<string>(pf_Return);
            //直接使用Page类的NavigationService来进行导航
            NavigationService.Navigate(pf);
        }
        void pf_Return(object sender, ReturnEventArgs<string> e)
        {
            if (e == null) return;
            //获取用户在PageFunction中的返回值
            this.txtResult.Text = e.Result;
        }
    }
}
