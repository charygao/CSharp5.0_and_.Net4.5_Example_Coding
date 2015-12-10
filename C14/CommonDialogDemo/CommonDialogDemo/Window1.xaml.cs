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
using System.ComponentModel;
using Microsoft.Win32; // OpenFileDialog



namespace CommonDialogDemo
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        bool needsToBeSaved;
        public Window1()
        {
            InitializeComponent();
        }
        // Closing
        void mainWindow_Closing(object sender, CancelEventArgs e)
        {
            //如果文档需要保存
            if (this.needsToBeSaved)
            {
                // 配置消息框
                string messageBoxText = "文档需要保存，单击“是”保存并退出, 单击“否”将直接退出, 或单击“取消”不退出.";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                // 显示消息框
                MessageBoxResult messageBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);

                // 处理消息框返回的结果
                switch (messageBoxResult)
                {
                    case MessageBoxResult.Yes: // 保存文档并退出
                        SaveDocument();
                        break;
                    case MessageBoxResult.No: //退出不保存文档
                        break;
                    case MessageBoxResult.Cancel: // 不退出
                        e.Cancel = true;
                        break;
                }
            }
        }
        void fileSave_Click(object sender, RoutedEventArgs e)
        {
            SaveDocument();
        }
        void filePrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument();
        }
        void fileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
   

        // 如果文档被修改，则提示需要保存
        void documentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.needsToBeSaved = true;
        }
        void fileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenDocument();
        }
        void OpenDocument()
        {
            //使用OpenFileDialog打开文档
            OpenFileDialog dlg = new OpenFileDialog();
            //配置OpenFileDialog对话框
            dlg.FileName = "Document"; // 默认文件名
            dlg.DefaultExt = ".wpf"; // 默认扩展名
            dlg.Filter = "Word Processor Files (.wpf)|*.wpf"; // 扩展名过滤器
            //打开对话框窗口
            Nullable<bool> result = dlg.ShowDialog();
            //处理打开文件的结果
            if (result == true)
            {
                //打开文件
                string filename = dlg.FileName;
            }
        }
        void SaveDocument()
        {
            //配置保存文件对话框
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Document"; //默认文件名
            dlg.DefaultExt = ".wpf"; // 默认扩展名            
            dlg.Filter = "Word Processor Files (.wpf)|*.wpf"; //扩展名过滤器
            // 显示保存文件对话框
            Nullable<bool> result = dlg.ShowDialog();
            //处理文件的保存
            if (result == true)
            {
                //保存文件
                string filename = dlg.FileName;
            }
        }
        void PrintDocument()
        {
            // 配置打印对话框
            PrintDialog dlg = new PrintDialog();
            //指定打印所有页
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;
            // 显示打印对话框
            Nullable<bool> result = dlg.ShowDialog();
            //处理打印对话框结果
            if (result == true)
            {
                //打印文档
            }
        }       
    
    }
}
