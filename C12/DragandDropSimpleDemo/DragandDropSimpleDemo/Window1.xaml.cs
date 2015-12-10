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
using System.IO;

namespace DragandDropSimpleDemo
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //如果选中了换行，则将TextBox的TextWrapping设为Warp。
            if ((bool)cbWrap.IsChecked)
                tbDisplayFileContents.TextWrapping = TextWrapping.Wrap;
            else
                tbDisplayFileContents.TextWrapping = TextWrapping.NoWrap;

        }
        //清除文本框的内容
        private void clickClear(object sender, RoutedEventArgs args) 
        { 
            tbDisplayFileContents.Clear(); 
        
        }
        //单击 复选框时，设置换行
        private void clickWrap(object sender, RoutedEventArgs args)
        {
            if ((bool)cbWrap.IsChecked)
                tbDisplayFileContents.TextWrapping = TextWrapping.Wrap;
            else
                tbDisplayFileContents.TextWrapping = TextWrapping.NoWrap;
        }
        //当文件拖放到TextBox上时，检查是否为单个文件。
        private void ehDragOver(object sender, DragEventArgs args)
        {
            //如果是单个文件，设置DragDropEffects为Copy，否则为None
            if (IsSingleFile(args) != null) 
                args.Effects = DragDropEffects.Copy;
            else args.Effects = DragDropEffects.None;
            // 确保不再调用DragOver事件
            args.Handled = true;
        }

        private void ehDrop(object sender, DragEventArgs args)
        {
            // 确保不再调用Drop事件
            args.Handled = true;
            //获取文件名
            string fileName = IsSingleFile(args);
            if (fileName == null) return;
            //读取文件，并赋给TextBox控件
            StreamReader fileToLoad = new StreamReader(fileName,Encoding.Default);
            tbDisplayFileContents.Text = fileToLoad.ReadToEnd();
            fileToLoad.Close();
            //设置标题为文件名
            this.Title = "加载文件: " + fileName;
        }

        //如果args中包含单个文件，则返回文件名，否则返回一个null值。
        private string IsSingleFile(DragEventArgs args)
        {
            // 检查文件格式。
            if (args.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                string[] fileNames = args.Data.GetData(DataFormats.FileDrop, true) as string[];
                // 检查是否为单个文件
                if (fileNames.Length == 1)
                {
                    // 检查是否是文件，如果是目录则返回空
                    if (File.Exists(fileNames[0]))
                    {
                        //返回文件名
                        return fileNames[0];
                    }
                }
            }
            return null;
        }

    }
}
