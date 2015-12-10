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

namespace BindingToElementDemo
{
    /// <summary>
    /// UpdateSourceTrigger.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateSourceTrigger : Window
    {
        public UpdateSourceTrigger()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            // 获取应用到TextBox的BindingExpression对象
            BindingExpression binding = scrollfontsize.GetBindingExpression(TextBox.TextProperty);
            // 更新ScrollBar的Value属性
            binding.UpdateSource();
        }
    }
}
