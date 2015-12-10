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

namespace CheckBoxList
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //中果SelectedItem为空
            if (lst.SelectedItem == null) return;
            //获取当前的选中位置和CheckBox的状态
            txtSelection.Text = String.Format(
            "你选择的项位于{0}.\r\n按钮的选中状态为{1}.",lst.SelectedIndex,((CheckBox)lst.SelectedItem).IsChecked);
        }
    }
}
