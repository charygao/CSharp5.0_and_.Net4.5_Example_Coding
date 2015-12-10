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

namespace DragandDropLabel
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
        //当鼠标左键按下时，开启拖放操作
        private void lbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label lbl = (Label)sender;
            //DoDragDrop需要指定拖放源对象，拖放的内容和拖放的效果
            DragDrop.DoDragDrop(lbl, lbl.Content, DragDropEffects.Copy);
        }
        //当拖放源进入目标之后，检查数据对象格式是否为Text，然后指定相应的拖放行为
        private void txt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }
        //在放置拖放源时，为TextBox赋值。
        private void txt_Drop(object sender, DragEventArgs e)
        {
            txt.Text += e.Data.GetData(DataFormats.Text);
        }
    }
}
