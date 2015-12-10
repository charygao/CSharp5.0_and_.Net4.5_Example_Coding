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

namespace UnderstandingDP
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
        //用于改变当前窗体的字体大小
        private void btnWindowSize_Click(object sender, RoutedEventArgs e)
        {
            this.FontSize = 20;         
        }
        //用于改变文本块的字体大小
        private void btnButtonSize_Click(object sender, RoutedEventArgs e)
        {
            txt.FontSize = 10;
        }
    }
}
