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

namespace ShowingaWindow
{
    /// <summary>
    /// ShowingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ShowingWindow : Window
    {
        public ShowingWindow()
        {
            InitializeComponent();
            //窗口启动时，将窗口显示在屏幕中央
            //double screeHeight = SystemParameters.FullPrimaryScreenHeight;
            //double screeWidth = SystemParameters.FullPrimaryScreenWidth;
            //this.Top = (screeHeight - this.Height) / 2;
            //this.Left = (screeWidth - this.Width) / 2;

            //double workHeight = SystemParameters.WorkArea.Height;
            //double workWidth = SystemParameters.WorkArea.Width;
            //this.Top = (workHeight - this.Height) / 2;
            //this.Left = (workWidth - this.Width) / 2;

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;            
        }
    }
}
