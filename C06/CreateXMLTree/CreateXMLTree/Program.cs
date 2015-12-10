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
        static void Main(string[] args)
        {
            CreateXMLTree( );
        }

        static void CreateXMLTree( )
        {
            XElement user1 = new XElement("User",
                new XAttribute("Name", "李四"),
                new XElement("Age", 22));
            XElement user2 = new XElement("User",
                new XAttribute("Name", "张三"),
                new XElement("Age", 23));
            XElement userLst = new XElement("UserList",
                "string content",
                user1,
                user2,
                new XAttribute("Count", 2),
                10);
            System.Console.WriteLine(userLst);
        }
    }
}
