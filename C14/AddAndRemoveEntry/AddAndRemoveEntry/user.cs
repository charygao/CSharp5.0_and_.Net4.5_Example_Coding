using System;
using System.Collections.Generic;
using System.Text;

namespace AddAndRemoveEntry
{
    /// <summary>
    /// һ���򵥵��û���
    /// </summary>
    public class User
    {
        private string name;
        public User() { }
        public User(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
