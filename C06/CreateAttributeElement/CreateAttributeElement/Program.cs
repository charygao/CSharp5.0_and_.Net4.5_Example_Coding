using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CreateAttributeElement
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
            CreateXMLAttributeEle( );
        }

        static void CreateXMLAttributeEle( )
        {
            //创建类型为string的属性，演示XAttribute(XName, object)的使用
            XAttribute atr1 = new XAttribute("String", "str");
            System.Console.WriteLine("atr1 is : " + atr1);

            //创建类型为string的属性，演示XAttribute(XAttribute)的使用
            XAttribute atr2 = new XAttribute(atr1);
            System.Console.WriteLine("atr2 is : " + atr2);

            //创建类型为int的属性，演示XAttribute(XName, object)的使用
            XAttribute atr3 = new XAttribute("Integer", 10);
            System.Console.WriteLine("atr3 is : " + atr3);

            //创建类型为DateTime的属性，演示XAttribute(XName, object)的使用
            XAttribute atr4 = new XAttribute("DateTime", DateTime.Now);
            System.Console.WriteLine("atr4 is : " + atr4);

            //创建类型为匿名类型的属性，演示XAttribute(XName, object)的使用
            XAttribute atr5 = new XAttribute("AnoymouseClass", new {x = 1.2, y = 3.3});
            System.Console.WriteLine("atr5 is : " + atr5);

            //创建类型为自定义类UserClass的属性，演示XAttribute(XName, object)的使用
            XAttribute atr6 = new XAttribute("UserClass", new UserClass(30, "Smith"));
            System.Console.WriteLine("atr6 is : " + atr6);

            //传入1个XAttribute参数，演示XElement(XName, object[])的使用
            XElement ele1 = new XElement("AtrEle", atr1);
            System.Console.WriteLine("ele1 is: \n" + ele1);

            //传入多个并列的XAttribute参数，演示XElement(XName, object[])的使用
            XElement ele2 = new XElement("AtrEle", atr1, atr3);
            System.Console.WriteLine("ele2 is: \n" + ele2);

            //传入1个XAttribute数组，演示XElement(XName, object[])的使用
            XAttribute[] atrAry = {atr3, atr6};
            XElement ele3 = new XElement("AtrEle", atrAry);
            System.Console.WriteLine("ele3 is: \n" + ele3);
        }
    }
}
