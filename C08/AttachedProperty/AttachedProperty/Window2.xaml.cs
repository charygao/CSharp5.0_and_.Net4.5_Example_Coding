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

namespace AttachedProperty
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            //设置txtBookName为第0行，第0列
            Grid.SetRow(txtBookName, 0);
            Grid.SetColumn(txtBookName, 0);
            //设置txtBook为第0行，第1列
            Grid.SetRow(txtName, 0);
            Grid.SetColumn(txtName, 1);
            //设置txtCategory为第1行，第0列
            Grid.SetRow(txtCategory, 1);
            Grid.SetColumn(txtCategory, 0);
            //设置txtCategory2位于第1行第1列
            Grid.SetRow(txtCategory2, 1);
            Grid.SetColumn(txtCategory2, 1);
            //设置txtContent位于第2行第1列
            Grid.SetRow(txtContent, 2);
            Grid.SetColumn(txtContent, 0);
            //设置txtContent2位于第2行第2列
            Grid.SetRow(txtContent2, 2);
            Grid.SetColumn(txtContent2, 1);


        }
    }
}
