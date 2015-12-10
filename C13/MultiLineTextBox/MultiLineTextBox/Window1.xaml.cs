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

namespace MultiLineTextBox
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

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(tbMultiLine.LineCount.ToString());
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            //选择从第11个字符开始，具有10个长度的字符。
            tbMultiLine.Select(10, 10);            
            //将当前焦点定位在TextBox控件上。
            tbMultiLine.Focus();
        }

        private void tbMultiLine_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //如果当前选择了内容，则显示关于当前选择的内容的信息。
            if (tbMultiLine.SelectionLength > 0)
            {
                string str = "当前选择了：" + tbMultiLine.SelectionLength.ToString() + "个字符!选择起始位置" +
                    tbMultiLine.SelectionStart.ToString() + "所选择的文本是：" + tbMultiLine.SelectedText;
                MessageBox.Show(str);
            }
        }

    }
}
