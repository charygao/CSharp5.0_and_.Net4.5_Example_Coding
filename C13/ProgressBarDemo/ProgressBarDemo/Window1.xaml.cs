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
using System.Windows.Media.Animation;

namespace ProgressBarDemo
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

        private void StartProgress2()
        {
            //定义动画时长
            Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));
            //定义属性动画
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
            doubleanimation.RepeatBehavior = new RepeatBehavior(5);
            //开始属性动画
            prog1.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartProgress2();
        }
    }
}
