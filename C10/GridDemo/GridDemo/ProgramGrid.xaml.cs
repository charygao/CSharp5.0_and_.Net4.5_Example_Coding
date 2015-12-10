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
    /// ProgramGrid.xaml 的交互逻辑
    /// </summary>
    public partial class ProgramGrid : Window
    {
        public ProgramGrid()
        {
            InitializeComponent();
            //调用CreateGrid编程创建Grid
            this.Content = CreateGrid();
        }
        public Grid CreateGrid()
        {
            //首先实例化一个Grid对象
            Grid grd = new Grid();
            //定义第一行
            RowDefinition row1 = new RowDefinition();
            //行的Height和列的Width都是GridLength类型的对象。该对象有三个重载的构造函数，分别对应到Grid控件的尺寸模式
            //这里使用GridUnitType.Start来指定尺寸单位，Start在XAML中就是一个*号。
            row1.Height = new GridLength(1, GridUnitType.Star);
            grd.RowDefinitions.Add(row1);
            //定义第二行
            RowDefinition row2 = new RowDefinition();
            //这里使用GridLength的静态方法来指定自动内容适应。
            row2.Height = GridLength.Auto;
            grd.RowDefinitions.Add(row2);
            //创建TextBox对象
            TextBox txt = new TextBox();
            txt.Text = "这是一个对话框窗口，RowDefinition的Height属性被设置为*，那么TextBox将占用剩余的空间。";
            txt.TextWrapping = TextWrapping.Wrap;



            //使用Grid控件的附加属性设置TextBox控件在Grid中的位置
            //Grid.SetRow(txt, 0);
            //Grid.SetColumn(txt, 0);
            grd.Children.Add(txt);
            //创建StackPanel对象
            StackPanel stk = new StackPanel();
            stk.Orientation = Orientation.Horizontal;
            stk.HorizontalAlignment = HorizontalAlignment.Right;
            //使用附加属性指定该控件位于Grid的第二行
            Grid.SetColumn(stk, 0);
            Grid.SetRow(stk, 1);
            grd.Children.Add(stk);
            //创建确定按钮并添加到StackPanel控件中
            Button btn = new Button();
            btn.Margin = new Thickness(10, 10, 2, 10);
            btn.Content = "确定";
            btn.Padding = new Thickness(3);
            stk.Children.Add(btn);
            //创建取消按钮并添加到StackPanel控件中
            Button btn1 = new Button();
            btn1.Margin = new Thickness(2, 10, 10, 10);
            btn1.Content = "取消";
            btn1.Padding = new Thickness(3);
            stk.Children.Add(btn1);
            //返回新创建的Grid对象。
            return grd;
        }
    }
}
