using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows;

namespace AddAndRemoveEntry
{
    [Serializable]
    // �����װ��ǰ�û�ѡ����û�����
    class UserCustomContentState : CustomContentState
    {
        private User user;
        //�ڹ��캯�������õ�ǰ�û�
        public UserCustomContentState(User user)
        {
            this.user = user;
        }
        //Ϊ�Զ��������״̬����һ����ʾ�ڵ�����ʷ�е�����
        //����ϵͳ����ȡ�����Ե�������Ϊ������ʷ��¼������
        public override string JournalEntryName
        {
            get
            {
                return this.user.Name;
            }
        }
        //���븲�Ǹ÷��������ڻָ�����Ҫ��״̬��
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
