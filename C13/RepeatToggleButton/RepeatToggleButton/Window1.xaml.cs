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
using System.Windows.Controls.Primitives;

namespace RepeatToggleButton
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //初始化按钮状态
            GetButtonStatus();
        }
        //用于保存计数
        private int number = 0;
        //当单击RepeatButton不放时，根据ToggleButton的选择，
        private void repeatbtn_Click(object sender, RoutedEventArgs e)
        {
            //如果按钮被点中，则减1
            if (tlb.IsChecked==true)
            {
                number -= 1;
            }
            //如果按钮被释放，则加1 
            else if(tlb.IsChecked==false)
            {
                number += 1;
            }
             //如果按钮未确定，则加2
            else if (tlb.IsChecked == null)
            {
                number += 2;
            }
            textBlock1.Text = number.ToString();
        }
        //用于获取当前ToggleButton的状态，并更新状态文本
        private void GetButtonStatus()
        {
            if (tlb.IsChecked == true)
            {
                txt.Text = "选中状态";
            }
            if (tlb.IsChecked == false)
            {
                txt.Text = "释放状态";
            }
            if (tlb.IsChecked == null)
            {
                txt.Text = "未确定状态";
            }
        }
        //当ToggleButton被单击时，显示状态文本
        private void tlb_Click(object sender, RoutedEventArgs e)
        {
            GetButtonStatus();
        }
    }
}
