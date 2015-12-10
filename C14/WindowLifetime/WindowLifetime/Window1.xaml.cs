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

namespace WindowLifetime
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.LocationChanged += new EventHandler(Window1_LocationChanged);
            this.Activated += new EventHandler(Window1_Activated);
            this.Deactivated += new EventHandler(Window1_Deactivated);
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
            this.ContentRendered += new EventHandler(Window1_ContentRendered);
            this.Closing += new System.ComponentModel.CancelEventHandler(Window1_Closing);
            this.Closed += new EventHandler(Window1_Closed);
            this.Unloaded += new RoutedEventHandler(Window1_Unloaded);
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            txt.Text += "Initialized事件被触发！\n";
        }
        void Window1_Unloaded(object sender, RoutedEventArgs e)
        {
            txt.Text += "Unloaded事件被触发！\n"; 
        }
        void Window1_Closed(object sender, EventArgs e)
        {
            txt.Text += "Closed事件被触发！\n"; 
        }
        void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("是否要关闭此窗口！","确定要关闭吗",MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                txt.Text += "Closing事件被触发！\n";
                e.Cancel = true;
            }
        }
        void Window1_ContentRendered(object sender, EventArgs e)
        {
            txt.Text += "ContentRendered事件被触发！\n";
        }
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            txt.Text += "Loaded事件被触发！\n";
        }
        void Window1_Deactivated(object sender, EventArgs e)
        {
            txt.Text += "Deactivated事件被触发！\n";
        }
        void Window1_Activated(object sender, EventArgs e)
        {
            txt.Text += "Actived事件被触发！\n";
        }
        void Window1_LocationChanged(object sender, EventArgs e)
        {
            txt.Text += "LocationChanged事件被触发！\n";
        }
    }
}
