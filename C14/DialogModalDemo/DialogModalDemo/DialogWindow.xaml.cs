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

namespace DialogModalDemo
{
    /// <summary>
    /// DialogWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }
        //定义一个公共属性
        public string WindowTitle { get; set; }
        //当单击确定按钮时，为公共属性赋值，并将DialogResult设置为True
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            WindowTitle = this.Title;
            DialogResult = true;
        }
    }
}
