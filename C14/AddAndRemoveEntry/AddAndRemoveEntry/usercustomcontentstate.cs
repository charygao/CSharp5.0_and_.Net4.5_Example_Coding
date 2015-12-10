using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows;

namespace AddAndRemoveEntry
{
    [Serializable]
    // 该类封装当前用户选择的用户数据
    class UserCustomContentState : CustomContentState
    {
        private User user;
        //在构造函数中设置当前用户
        public UserCustomContentState(User user)
        {
            this.user = user;
        }
        //为自定义的内容状态定义一个显示在导航历史中的名字
        //导航系统将获取此属性的名称作为导航历史记录的名字
        public override string JournalEntryName
        {
            get
            {
                return this.user.Name;
            }
        }
        //必须覆盖该方法，用于恢复所需要的状态，
        public override void Replay(NavigationService navigationService, NavigationMode mode)
        {
            Page1 page = (Page1)navigationService.Content;
            ListBox userListBox = page.userListBox;

            page.userListBox.SelectionChanged -= page.userListBox_SelectionChanged;
            page.userListBox.SelectedItem = this.user;
            page.userListBox.SelectionChanged += page.userListBox_SelectionChanged;
        }
    }
}
