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

namespace CustomRoutedEvent
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 属性添加到要使用该属性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomRoutedEvent"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 属性添加到要使用该属性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomRoutedEvent;assembly=CustomRoutedEvent"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:MyButton/>
    ///
    /// </summary>
    public class MyButton : Button
    {
        //定义路由事件
        public static readonly RoutedEvent HitEvent;
        static MyButton()
        {
            //使用EventManager注册依赖事件
            HitEvent = EventManager.RegisterRoutedEvent(
        "Hit", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyButton));
        }
        //为路由事件添加标准.NET封装
        public event RoutedEventHandler Hit
        {
            add { AddHandler(HitEvent, value); }
            remove { RemoveHandler(HitEvent, value); }
        }
        // 下面的方法用于触发路由事件
        void RaiseHitEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(MyButton.HitEvent);
            RaiseEvent(newEventArgs);
        }
        //重载MyButton的OnClick方法
        protected override void OnClick()
        {
            base.OnClick();
            RaiseHitEvent();
        }


    }
}
