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
//必须添加此命名空间
using System.IO;
namespace SingleInstanceWithCommunication
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
        //加载文本文件，设置文本文件的内容为TextBox的Text属性
        public void LoadFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string txt = File.ReadAllText(fileName);
                    txtcontent.Text = txt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载文档失败！失败消息是：" + ex.Message);
            }
        }
    }
}
