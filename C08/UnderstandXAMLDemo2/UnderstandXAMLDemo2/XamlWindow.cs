using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//添加如下的命名空间
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
namespace UnderstandXAMLDemo2
{
    /// <summary>
    /// 编程实现XAML代码中实现的用户界面
    /// </summary>
    public class XamlWindow:Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new XamlWindow());
        }
        /// <summary>
        /// XamlWindow类的构造函数
        /// </summary>
        public XamlWindow()
        {
            Height = 200;
            Width = 500;
            //实例化一个Grid对象，并设置为Window的内容
            Grid grd = new Grid();
            grd.Background = Brushes.Beige;
            //设置窗口的内容为Grid
            Content = grd;
            //为Grid对象初始化行和列信息
            ColumnDefinition coldef = new ColumnDefinition();
            coldef.Width = new GridLength(100);
            grd.ColumnDefinitions.Add(coldef);
            for (int i = 0; i <= 1; i++)
            {
                grd.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i <= 2; i++)
            {
                grd.RowDefinitions.Add(new RowDefinition());
            }

            //实例化文本块对象，并插入到Grid的Children控件集合中
            TextBlock txtblock = new TextBlock(new Run("书名:"));
            txtblock.HorizontalAlignment = HorizontalAlignment.Right;
            grd.Children.Add(txtblock);
            Grid.SetColumn(txtblock, 0);
            Grid.SetRow(txtblock, 0);

            txtblock = new TextBlock(new Run("学习Windows Presentation Foundation"));
            grd.Children.Add(txtblock);
            Grid.SetColumn(txtblock, 1);
            Grid.SetRow(txtblock, 0);

            txtblock = new TextBlock(new Run("类型:"));
            txtblock.HorizontalAlignment = HorizontalAlignment.Right;
            grd.Children.Add(txtblock);
            Grid.SetColumn(txtblock, 0);
            Grid.SetRow(txtblock, 1);

            txtblock = new TextBlock(new Run(".NET Framework 4.5 中文原创书籍"));
            grd.Children.Add(txtblock);
            Grid.SetColumn(txtblock, 1);
            Grid.SetRow(txtblock, 1);

            txtblock = new TextBlock(new Run("内容简介:"));
            txtblock.HorizontalAlignment = HorizontalAlignment.Right;
            grd.Children.Add(txtblock);
            Grid.SetColumn(txtblock, 0);
            Grid.SetRow(txtblock, 2);

            txtblock = new TextBlock(new Run("从基础到应用，全面覆盖WPF应用"));
            grd.Children.Add(txtblock);
            Grid.SetColumn(txtblock, 1);
            Grid.SetRow(txtblock, 2);
        }
    }
}
