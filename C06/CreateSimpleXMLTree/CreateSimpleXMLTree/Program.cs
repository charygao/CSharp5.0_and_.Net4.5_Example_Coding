using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CreateXMLTree
{
    class Program
    {
        /// <summary>
        /// 创建一个类UserClass，重写它的ToString()方法
        /// </summary>
        public class UserClass
        {
            /// <summary>
            /// 构造函数，接收姓名和年龄两个参数
            /// </summary>
            /// <param name="age">年龄</param>
            /// <param name="name">姓名</param>
            public UserClass(int age, string name)
            {
                this._Age = age;
                this._Name = name;
            }

            private string _Name;
            private int _Age;

            /// <summary>
            /// 重写ToString()方法，返回特定格式的文本
            /// </summary>
            public override string ToString( )
            {
                return string.Format("{0}'s age is {1}", this._Name, this._Age);
            }
        }

        static void Main(string[] args)
        {
            CreateSimpleElement( );
        }

        static void CreateSimpleElement( )
        {
            //创建简单的XML元素，演示XElement(XName)的使用
            XElement ele1 = new XElement("User");
            System.Console.WriteLine("ele1 is :\n" + ele1);
            
            //创建简单的XML元素，演示XElement(XElement)的使用
            XElement ele2 = new XElement(ele1);
            System.Console.WriteLine("ele2 is :\n" + ele2);
            
            //创建带有内容的XML元素，演示XElement(XName, object)的使用
            XElement ele3 = new XElement("String", "this is a string");
            System.Console.WriteLine("ele3 is :\n" + ele3);
            
            //创建带有内容的XML元素，演示XElement(XElement)的使用
            XElement ele4 = new XElement(ele3);
            System.Console.WriteLine("ele4 is :\n" + ele4);

            //创建元素内容类型为float的XML元素，演示XElement(XName, object)的使用
            XElement ele5 = new XElement("Float", 5.1234f);
            System.Console.WriteLine("ele5 is :\n" + ele5);

            //创建元素内容类型为DateTime的XML元素，演示XElement(XName, object)的使用
            XElement ele6 = new XElement("Datetime", DateTime.Now);
            System.Console.WriteLine("ele6 is :\n" + ele6);

            //创建元素内容类型为匿名类的XML元素，演示XElement(XName, object)的使用
            XElement ele7 = new XElement("AnoymousClass", new {x = 1.1, y = 3.2});
            System.Console.WriteLine("ele7 is :\n" + ele7);

            //创建元素内容类型为自定义类UserClass的XML元素，演示XElement(XName, object)的使用
            XElement ele8 = new XElement("UserClass", new UserClass(20, "Jone"));
            System.Console.WriteLine("ele8 is :\n" + ele8);
        }
    }
}
