using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace CreateSubElement
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateSubElement( );
        }

        static void CreateSubElement( )
        {
            //直接在构造函数中创建XML文档
            XElement userLst1 = new XElement("UserList",
                new XElement("User",
                    new XElement("Name", "张三"),
                    new XElement("Age", 21)),
                new XElement("User",
                    new XElement("Name", "李四"),
                    new XElement("Age", 22)));

            //创建用户“张三”
            XElement user1 = new XElement("User",
                new XElement("Name", "张三"),
                new XElement("Age", 21));
            
            //创建用户“李四”
            XElement user2 = new XElement("User",
                new XElement("Name", "李四"),
                new XElement("Age", 22));
            
            //创建用户列表第一种方法
            XElement userLst2 = new XElement("UserList",
                user1,
                user2);

            //创建用户列表第二种方法
            object[] eleAry ={user1, user2};
            XElement userLst3 = new XElement("UserList", eleAry);
            
            //打印结果，演示效果,userLst1,userLst2,userLst3 的XML文本相同
            System.Console.WriteLine("the user list is :\n" + userLst1);
        }
    }
}
