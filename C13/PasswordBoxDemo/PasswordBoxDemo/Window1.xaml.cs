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

namespace PasswordBoxDemo
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
        //当Window加载时，初始化ListBox以及ComboBox的初始值
        void WindowLoaded(Object sender, RoutedEventArgs args)
        {
            //将ComboBox控件的当前值设为当前PasswordBox的当前PasswordChar值。
            listMaskChar.Text = pwdBox.PasswordChar.ToString();
            //为ListBox控件赋初值，使其具有多个可选值来设置PasswordBox的MaxLength属性。
            for (int x = 6; x <= 256; x++)
                selectMaxLen.Items.Add(x.ToString());
            selectMaxLen.SelectedIndex = 0;
        }
        //当选择掩码发生变化后，重新设置PasswordBox的掩码
        void NewMaskChar(Object sender, RoutedEventArgs args)
        {
            pwdBox.PasswordChar = ((ComboBoxItem)listMaskChar.SelectedItem).Content.ToString().ToCharArray()[0];
        }
        //用于计数，当PasswordBox文本发生变化时，则自增这个整数值。
        private int pwChanges = 0;
        //PasswordChanged事件处理器，用于监视PasswordBox的变化
        void PasswordChanged(Object sender, RoutedEventArgs args)
        {
            pwChangesLabel.Content = ++pwChanges;
        }
        //单击拷贝内容时，全选并拷贝文本框的内容
        void CopyContents(Object sender, RoutedEventArgs args)
        {
            scratchTextBox.SelectAll();
            scratchTextBox.Copy();
        }
        //调用Clear方法清除密码框
        void PwbClear(Object sender, RoutedEventArgs args) 
        { 
            pwdBox.Clear(); 
        }
        //调用Paste方法清除密码框
        void PwbPaste(Object sender, RoutedEventArgs args) 
        {
            pwdBox.Paste(); 
        }
        //当选择最大长度ListBox的值后，执行此代码，设置PasswordBox的MaxLength属性，并更新currentMaxLen这个Label控件
        void MaxSelected(Object sender, RoutedEventArgs args)
        {
            if (selectMaxLen.SelectedIndex == 0)
            {
                pwdBox.MaxLength = 0;
                currentMaxLen.Content = "无限制";
            }
            else
                currentMaxLen.Content = pwdBox.MaxLength = selectMaxLen.SelectedIndex + 5;
        }
    }
}
