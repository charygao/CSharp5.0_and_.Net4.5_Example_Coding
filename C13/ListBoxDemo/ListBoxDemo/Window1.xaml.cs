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

namespace ListBoxDemo
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
            //使用SelectedItem获取当前选择的ListBoxItem
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            string str= " 当前选择了 " + lbi.Content.ToString() + ".";
            MessageBox.Show(str);
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            StackPanel stackpanel = lbi.Content as StackPanel;
            string str = " 当前选择了 " + ((TextBlock)stackpanel.Children[1]).Text +".";
            MessageBox.Show(str);
        }

        public void GetListBoxItemByIndex(int index)
        {
            ListBoxItem lbi = (ListBoxItem)(lbl1.ItemContainerGenerator.ContainerFromIndex(index));
            string str = string.Format("指定索引位置{0}的ListBoxItem的内容为：{1} " ,index,lbi.Content.ToString());
            MessageBox.Show(str);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetListBoxItemByIndex(1);
        }
    }
}
