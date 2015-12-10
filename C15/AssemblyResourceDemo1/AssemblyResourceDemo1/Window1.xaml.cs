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
//添加如下的命名空间
using System.Windows.Resources;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.IO;

namespace AssemblyResourceDemo1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            Uri absoluteUri = new Uri("pack://application:,,,/OpenPH.bmp", UriKind.Absolute);
            img1.Source = new BitmapImage(absoluteUri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Resources.StreamResourceInfo sri = Application.GetResourceStream(new Uri("OpenPH.bmp", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //获取当前程序集
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            //指定资源名称
            string resourceName = assembly.GetName().Name + ".g";
            //实例化ResourceManager对象
            ResourceManager rm = new ResourceManager(resourceName, assembly);
            //获取并返回程序集资源
            using (ResourceSet set = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                UnmanagedMemoryStream ums = (UnmanagedMemoryStream)set.GetObject("OpenHH.bmp", true);
            }
        }
        //下面的代码获取当前程序集中的程序集列表，并在消息框中显示其资源名称
        private void btnGetResouceList_Click(object sender, RoutedEventArgs e)
        {
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            string resourceName = assembly.GetName().Name + ".g";
            ResourceManager rm = new ResourceManager(resourceName, assembly);
            using (ResourceSet set =
            rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                foreach (System.Collections.DictionaryEntry res in set)
                {
                    MessageBox.Show(res.Key.ToString());
                }
            }
        }
    }
}
