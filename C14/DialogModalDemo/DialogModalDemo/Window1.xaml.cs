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

namespace DialogModalDemo
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
        //显示对话框窗口，并获取返回值
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow dw = new DialogWindow();
            if (dw.ShowDialog() == true)
            {
                MessageBox.Show("模式窗口己经单击确认，窗口标题为：" + dw.WindowTitle);
            }
            else
            {
                MessageBox.Show("模式窗口己单击取消！");
            }
        }
    }
}
