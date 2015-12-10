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

namespace GridDemo
{
    /// <summary>
    /// IsSharedSizeScopeDemo.xaml 的交互逻辑
    /// </summary>
    public partial class IsSharedSizeScopeDemo : Window
    {
        public IsSharedSizeScopeDemo()
        {
            InitializeComponent();
        }
        //将IsSharedSizeScope属性设置为True
        public void setTrue(object sender, System.Windows.RoutedEventArgs e)
        {
            Grid.SetIsSharedSizeScope(dp1, true);
            txt1.Text = "IsSharedSizeScope属性被设置为" + Grid.GetIsSharedSizeScope(dp1).ToString();
        }
        //将IsSharedSizeScope属性设置为False
        public void setFalse(object sender, System.Windows.RoutedEventArgs e)
        {
            Grid.SetIsSharedSizeScope(dp1, false);
            txt1.Text = "IsSharedSizeScope属性被设置为" + Grid.GetIsSharedSizeScope(dp1).ToString();
        }



    }
}
