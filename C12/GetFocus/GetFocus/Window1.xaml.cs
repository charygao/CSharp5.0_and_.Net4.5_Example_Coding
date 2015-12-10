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

namespace GetFocus
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            //使用静态类Keyboard的静态方法Focus来设置键盘焦点
            IInputElement iie = Keyboard.Focus(textBox2);
            //Focus返回当前获取焦点的元素
            MessageBox.Show(((TextBox)iie).Name);
        }
        //当textBox2控件获取焦点时
        private void textBox2_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox source = e.Source as TextBox;
            if (source != null)
            {
                //更改文本框的背景色
                source.Background = Brushes.LightBlue;
                //清除文本框
                source.Clear();
            }
        }
        //当textBox2控件失去焦点时
        private void textBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox source = e.Source as TextBox;
            //获取当前得到焦点的控件。
            if (source != null)
            {
                //当失去焦点时，将背景色恢复为白色
                source.Background = Brushes.White;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control)!=0)
            {
                textBox2.Text += "Ctrl键被按下";
            }
            //是否Insert键被按下。
            bool isKeyAlt = Keyboard.IsKeyDown(Key.Insert);
        }
    }
}
