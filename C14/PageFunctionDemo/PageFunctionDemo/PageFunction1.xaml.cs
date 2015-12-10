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
    /// PageFunction1.xaml 的交互逻辑
    /// </summary>
    public partial class PageFunction1 : PageFunction<String>
    {
        public PageFunction1()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //返回字符串值
            ListBoxItem lbt=(ListBoxItem)lst.SelectedItem;
            string BookName=lbt.Content.ToString();
            OnReturn(new ReturnEventArgs<string>(BookName));
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //返回一个空值，指定没有选择任何东西
            OnReturn(null);
        }
    }
}
