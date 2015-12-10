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

namespace KeyInputDemo
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt2.Clear();
        }

        private void txt1_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
        //键盘事件
        private void KeyEvents(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            //如果选中的忽略重复键，并且当前是重复按键，则返回。
            if ((bool)isRepeatcb.IsChecked && e.IsRepeat)
            {
                return;
            }
            //在文本框中显示事件名称
            string eventMessage = "事件名称: " + e.RoutedEvent + " " + " 键: " + e.Key + "\n";
            txt2.Text += eventMessage;
        }
        //键盘输入事件
        private void InputEvent(object sender, TextCompositionEventArgs e)
        {
            int val;
            if(!Int32.TryParse(e.Text,out val))
            {
                //禁止非数字的输入
                e.Handled = true;
            }
            string eventMessage = "事件名称: " + e.RoutedEvent + " " +
            " 输入文本: " + e.Text + "\n";
            txt2.Text += eventMessage;
        }
    }
}
