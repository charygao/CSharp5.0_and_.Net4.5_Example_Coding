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

namespace GridDemo
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
            Window1 win = new Window1();
            win.Owner = this;
            win.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            GridDialogBox grddlg = new GridDialogBox();
            grddlg.Owner = this;
            grddlg.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            GridSplitterDemo grdSplitter = new GridSplitterDemo();
            grdSplitter.Owner = this;
            grdSplitter.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            GridSplitterDemo2 grdSplitter2 = new GridSplitterDemo2();
            grdSplitter2.Owner = this;
            grdSplitter2.Show();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ProgramGrid pgrd = new ProgramGrid();
            pgrd.Owner = this;
            pgrd.Show();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            SpanningGrid spangrid = new SpanningGrid();
            spangrid.Owner = this;
            spangrid.Show();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            IsSharedSizeScopeDemo ssd = new IsSharedSizeScopeDemo();
            ssd.Owner = this;
            ssd.Show();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            SharedSizeGroupWithSplitter ssgs = new SharedSizeGroupWithSplitter();
            ssgs.Owner = this;
            ssgs.Show();
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            UniformGrid ufg = new UniformGrid();
            ufg.Owner = this;
            ufg.Show();
        }
    }
}
