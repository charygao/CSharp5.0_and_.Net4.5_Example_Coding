using System;
using System.Collections.ObjectModel;

namespace AddAndRemoveEntry
{
    /// <summary>
    /// User�ļ����࣬����˶��User���ʵ��
    /// </summary>
    public class Users : ObservableCollection<User>
    {
        public Users()
        {
            this.Add(new User("����"));
            this.Add(new User("����"));
            this.Add(new User("����"));
            this.Add(new User("����"));
            this.Add(new User("����"));
            this.Add(new User("�¾�"));
            this.Add(new User("��ʮ"));
        }
    }
}
