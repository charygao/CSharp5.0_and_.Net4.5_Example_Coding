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

namespace BindingToObject
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            BindingToFontFamily btff = new BindingToFontFamily();
            btff.Owner = this;
            btff.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            BindingToPerson btp = new BindingToPerson();
            btp.Owner = this;
            btp.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            BindingContext bct = new BindingContext();
            bct.Owner = this;
            bct.Show();
        }
    }
}
