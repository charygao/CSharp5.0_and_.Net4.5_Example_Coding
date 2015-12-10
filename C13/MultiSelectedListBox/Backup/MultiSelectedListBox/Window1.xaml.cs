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

namespace MultiSelectedListBox
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
        //获取多选的ListBox项
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbl.SelectedItem != null)
            {
               txt.Text+= "共有" + (lbl.SelectedItems.Count.ToString()) + "个项被选择"+Environment.NewLine;               
               StringBuilder sb = new StringBuilder();
               foreach (ListBoxItem lbls in lbl.SelectedItems)
               {
                   sb.Append(lbls.Content.ToString()+Environment.NewLine);
               }
               txt.Text += sb.ToString();
            }
        }
    }
}
