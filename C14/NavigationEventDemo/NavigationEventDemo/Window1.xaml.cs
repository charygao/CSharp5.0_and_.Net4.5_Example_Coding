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

namespace NavigationEventDemo
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
        NavigationService NavigationService
        {
            //获取当前NavigationService的实例
            get { return NavigationService.GetNavigationService((DependencyObject)this.browserFrame.Content); }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //在Load事件中关联事件处理器
            this.NavigationService.Navigating += NavigationService_Navigating;
            this.NavigationService.Navigated += NavigationService_Navigated;
            this.NavigationService.NavigationProgress += NavigationService_NavigationProgress;
            this.NavigationService.NavigationStopped += NavigationService_NavigationStopped;
            this.NavigationService.NavigationFailed += NavigationService_NavigationFailed;
            this.NavigationService.LoadCompleted += NavigationService_LoadCompleted;
            this.NavigationService.FragmentNavigation += NavigationService_FragmentNavigation;
            //根据NavigationService的状态来改变按钮
            this.backButton.IsEnabled = this.NavigationService.CanGoBack;
            this.forwardButton.IsEnabled = this.NavigationService.CanGoForward;
        }
        void goButton_Click(object sender, RoutedEventArgs e)
        {
            //清除事件状态列表框
            this.navigatingEventsListBox.Items.Clear();
            Uri uri = new Uri(this.addressTextBox.Text, UriKind.RelativeOrAbsolute);
            this.NavigationService.Navigate(uri);
        }
        void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoForward();
        }
        void stopButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.StopLoading();
        }
        void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            //清除事件信息
            this.navigatingEventsListBox.Items.Clear();
            //刷新
            this.NavigationService.Refresh();
        }
        #region 导航事件
        void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            Log("Navigating: [" + e.Uri + "]");
        }
        void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            Log("Navigated: [" + e.Uri + "]");
        }
        void NavigationService_NavigationProgress(object sender, NavigationProgressEventArgs e)
        {
            Log("Progress: " + e.BytesRead.ToString() + " of " + e.MaxBytes.ToString() + " [" + e.Uri + "]");
        }
        void NavigationService_NavigationStopped(object sender, NavigationEventArgs e)
        {
            Log("Navigation Stopped: [" + e.Uri + "]");
        }
        void NavigationService_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            Log("Navigation Failed: [" + e.Uri + " - " + e.Exception.Message + "]");
        }
        void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            Log("Load Completed: [" + e.Uri + "]");
            //重置按钮的状态
            this.backButton.IsEnabled = this.NavigationService.CanGoBack;
            this.forwardButton.IsEnabled = this.NavigationService.CanGoForward;
        }
        void NavigationService_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
        {
            Log("Fragment Navigation: [" + e.Fragment + "]");
        }
        #endregion
        //将导航事件信息记录在ListBox中
        void Log(string item)
        {
            this.navigatingEventsListBox.Items.Add(item);
            this.navigatingEventsListBox.SelectedIndex = this.navigatingEventsListBox.Items.Count - 1;
            this.navigatingEventsListBox.Focus();
        }

        private void removeBackEntry_Click(object sender, RoutedEventArgs e)
        {
            //遍历移除导航历史回退记录
            while (this.NavigationService.CanGoBack)
            {
                this.NavigationService.RemoveBackEntry();
            }
        }

        private void removeBackEntry2_Click(object sender, RoutedEventArgs e)
        {
            string pageName;
            while (pageName != "Page1.xaml")
            {
                JournalEntry entry = nav.RemoveBackEntry();
                //使用Source属性获取被移除的Uri
                pageName = System.IO.Path.GetFileName(entry.Source.ToString());
            }
        }
    }
}
