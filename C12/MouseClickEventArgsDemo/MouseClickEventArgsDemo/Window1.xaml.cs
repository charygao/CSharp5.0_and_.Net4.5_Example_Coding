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

namespace MouseClickEventArgsDemo
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
        //获取按键状态
        private void MouseClickHandler(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                stateLabel.Text = "鼠标按下";
            }
            if (e.ButtonState == MouseButtonState.Released)
            {
                stateLabel.Text = "鼠标放开";
            }
        }
        private void MouseButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            StackPanel src = e.Source as StackPanel;
            //获取按钮
            if (src != null)
            {
                switch (e.ChangedButton)
                {
                    case MouseButton.Left:
                        src.Background = Brushes.Green;
                        changedbuttonlabel.Text = "按键为：MouseButton.Left";
                        break;
                    case MouseButton.Middle:
                        src.Background = Brushes.Red;
                        changedbuttonlabel.Text = "按键为：MouseButton.Middle";
                        break;
                    case MouseButton.Right:
                        src.Background = Brushes.Yellow;
                        changedbuttonlabel.Text = "按键为：MouseButton.Right";
                        break;
                    case MouseButton.XButton1:
                        src.Background = Brushes.Brown;
                        changedbuttonlabel.Text = "按键为：MouseButton.XButton1";
                        break;
                    case MouseButton.XButton2:
                        src.Background = Brushes.Purple;
                        changedbuttonlabel.Text = "按键为：MouseButton.XButton2";
                        break;
                    default:
                        break;
                }
            }
        }
        //按键计数事件处理代码
        private void OnMouseDownClickCount(object sender, MouseButtonEventArgs e)
        {
            //检查按钮次数
            if (e.ClickCount == 1)
            {
                //单击
                clickcountLabel.Text = "Single Click";
            }
            if (e.ClickCount == 2)
            {
                //双击
                clickcountLabel.Text = "Double Click";
            }
            if (e.ClickCount > 3)
            {
                //三击
                clickcountLabel.Text = "Triple Click";
            }
        }


    }
}
