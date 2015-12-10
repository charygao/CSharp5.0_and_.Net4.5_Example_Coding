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

namespace AddAndRemoveEntry
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page, IProvideCustomContentState
    {
        public Page1()
        {
            InitializeComponent();
        }
        void removeBackEntryButton_Click(object sender, RoutedEventArgs e)
        {
            //如果在返回导航历史中有记录，则移除
            if (this.NavigationService.CanGoBack)
            {
                JournalEntry entry = this.NavigationService.RemoveBackEntry();
                UserCustomContentState state = (UserCustomContentState)entry.CustomContentState;
                this.logListBox.Items.Insert(0, "RemoveBackEntry: " + state.JournalEntryName);
            }
        }
        internal void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //如果项被选择，仅添加一个自定义状态到导航历史中
            if (e.RemovedItems.Count == 0) return;
            //当选择改变时，会引发SelectionChanged事件，先在日志ListBox中添加一项。
            User previousUser = e.RemovedItems[0] as User;
            this.logListBox.Items.Insert(0, "AddBackEntry: " + previousUser.Name);
            // 创建UserCustomContentState类的实例，调用AddBackEntry方法添加到导航历史中
            UserCustomContentState userPageState = new UserCustomContentState(previousUser);
            this.NavigationService.AddBackEntry(userPageState);
        }
        #region IProvideCustomContentState 成员
        public CustomContentState GetContentState()
        {
            //一旦状态被重放，它不能被再次重放，因此，当导航到远离自定义内容状态的历史条目时，
            //需要重新创建，并且添加到导航历史中
            this.logListBox.Items.Insert(0, "GetContentState: " + currentUser.Name);
            return new UserCustomContentState(currentUser);
        }
        #endregion
    }
}
