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

namespace SimpleComboBox示例
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

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            if (cb.IsDropDownOpen == true)
            {
                txt.Text += "下拉列表框己打开\n";
            }
        }
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (cb.IsDropDownOpen == false)
            {
                txt.Text += "下拉列表框己经关闭\n";
            }
        }
    }
}
