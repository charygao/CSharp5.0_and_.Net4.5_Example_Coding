using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace BindingToObject
{
    //这个类实现了INotifyPropertyChanged
    //以支持单向和双向绑定
    public class Person : INotifyPropertyChanged
    {
        private string name;
        //当属性变更时，将触发PropertyChanged事件进行更改通知。
        public event PropertyChangedEventHandler PropertyChanged;
        public Person()
        {
        }
        public Person(string value)
        {
            this.name = value;
        }
        public string PersonName
        {
            get { return name; }
            set
            {
                name = value;
                // 当为属性赋值时，触发PropertyChanged事件
                OnPropertyChanged("PersonName");
            }
        }
        //创建OnPropertyChanged辅助方法触发事件
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
