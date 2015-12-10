using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//添加如下的命名空间
using System.Windows;
namespace CreateWPFDependencyProperty
{
    //依赖属性必须派生自DependencyObject或其派生类
    public class MyBook:DependencyObject
    {
        //定义一个依赖属性
        public static readonly DependencyProperty BookNameProperty;

        static  MyBook()
        {
            BookNameProperty = DependencyProperty.Register("BookName", typeof(string),
               typeof(MyBook), 
               new PropertyMetadata("WPF图书",
                   //属性变更回调
                  new PropertyChangedCallback(BookNameChangedCallback), 
                  //强制值回调
                  new CoerceValueCallback(BookNameCoerceCallback)),
                  //属性验证回调
                  new ValidateValueCallback(BookNameValidateCallback));
        }
        //当属性值发生变化时，简单的在输出窗口中输出属性值
        private static void BookNameChangedCallback(
    DependencyObject obj,
    DependencyPropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.OldValue + " " + e.NewValue);
        }
          //定义强制值回调，使属性值限定在8个字符以内，多余的将被裁切。
          private static object BookNameCoerceCallback(
      DependencyObject obj, object o)
          {
              string s = o as string;
              if (s.Length > 8)
                  s = s.Substring(0, 8);
              return s;
          }
          //验证属性值是否为空，为空，则返回false
          private static bool BookNameValidateCallback(object value)
          {
              return value != null;
          }

          //为依赖属性定义标准属性的包装
          public string BookName
          {
              get
              {
                  return (string)GetValue(BookNameProperty);
              }
              set
              {
                  SetValue(BookNameProperty, value);
              }
          }
    }    
}
