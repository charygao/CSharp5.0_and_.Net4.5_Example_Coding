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

namespace InkCanvasDemo
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (inkCanvas == null)
            {
                return;
            }
            string ItemText = ((ComboBoxItem)cb1.SelectedItem).Content.ToString();
            inkCanvas.EditingMode = ParseEnum<InkCanvasEditingMode>(ItemText); 
        }
        //一个用于将字符串转换为枚举值的泛型方法
        public T ParseEnum<T>(string text)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(typeof(T).ToString() + " 不是一个枚举值");
            }
            T t = (T)Enum.Parse(typeof(T), text, true);
            return t;
        }

    }
}
