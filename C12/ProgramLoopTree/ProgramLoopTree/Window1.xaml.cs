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
//为了调用Debug.WriteLine，需要添加此命名空间
using System.Diagnostics;
namespace ProgramLoopTree
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Debug.WriteLine("逻辑树结构如下所示：");
            EnumLogical(0,this);
        }
        //由于视觉树需要在布局完成后才能呈现，因此放在OnContentRendered重载方法中。
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            Debug.WriteLine("视觉树结构如下所示：");
            EnumVisual(0,this);
        }
        //遍历视觉树
         public void EnumVisual(int Ident,Visual myVisual)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
            {
                //接收特定索引的子元素
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);
                //在输出窗口中输出子元素
                Debug.WriteLine(new string(' ',Ident)+childVisual);
                //递归遍历
                EnumVisual(Ident+1,childVisual);
            }
        }
        //遍历逻辑树
         public void EnumLogical(int Ident,object myLogical)
        {
             //对象必须是派生自DependencyObject的对象
            if(!(myLogical is DependencyObject))
            {
                return;
            }
            foreach (object childLogical in LogicalTreeHelper.GetChildren(myLogical as DependencyObject))
            {
                //在调试窗口中输出子元素
                Debug.WriteLine(new string(' ',Ident)+childLogical);
                //递归遍历逻辑树
                EnumLogical(Ident+1,childLogical);
            }
        }

    }
}
