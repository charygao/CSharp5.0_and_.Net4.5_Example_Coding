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

namespace MessageBoxDemo
{
    /// <summary>
    /// CustomerMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class CustomerMessageBox : Window
    {
        public CustomerMessageBox()
        {
            InitializeComponent();
        }
        void showMessageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            //配置消息框
            Window owner = ((bool)ownerCheckBox.IsChecked ? this : null);
            string messageBoxText = this.messageBoxText.Text;
            string caption = this.caption.Text;
            MessageBoxButton button = (MessageBoxButton)Enum.Parse(typeof(MessageBoxButton), this.buttonComboBox.Text);
            MessageBoxImage icon = (MessageBoxImage)Enum.Parse(typeof(MessageBoxImage), this.imageComboBox.Text);
            MessageBoxResult defaultResult = (MessageBoxResult)Enum.Parse(typeof(MessageBoxResult), this.defaultResultComboBox.Text);
            MessageBoxOptions options = (MessageBoxOptions)Enum.Parse(typeof(MessageBoxOptions), this.optionsComboBox.Text);
            // 显示消息框，如果配置了窗口宿主，则设定该宿主 
            MessageBoxResult result;
            if (owner == null)
            {
                result = MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options);
            }
            else
            {
                result = MessageBox.Show(owner, messageBoxText, caption, button, icon, defaultResult, options);
            }
            //显示结果
            resultTextBlock.Text = "Result = " + result.ToString();
        }

    }
}
