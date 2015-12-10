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

namespace RegisterAttached
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
        //注册附加属性
        public static readonly DependencyProperty IsPopupProperty = DependencyProperty.RegisterAttached(
          "IsPopup",
          typeof(Boolean),
          typeof(Window1),
          new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

        public static void SetIsPopup(UIElement element, Boolean value)
        {
            element.SetValue(IsPopupProperty, value);
        }
        public static Boolean GetIsPopup(UIElement element)
        {
            return (Boolean)element.GetValue(IsPopupProperty);
        }

    }
}
