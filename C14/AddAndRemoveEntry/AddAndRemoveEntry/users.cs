using System;
using System.Collections.ObjectModel;

namespace AddAndRemoveEntry
{
    /// <summary>
    /// User的集合类，添加了多个User类的实例
    /// </summary>
    public class Users : ObservableCollection<User>
    {
        public Users()
        {
            this.Add(new User("张三"));
            this.Add(new User("李四"));
            this.Add(new User("王五"));
            this.Add(new User("赵六"));
            this.Add(new User("刘八"));
            this.Add(new User("陈九"));
            this.Add(new User("伍十"));
        }
    }
}
