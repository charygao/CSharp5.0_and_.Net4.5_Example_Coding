using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace QeuryAttributesElement
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryAttributeElement( );
        }

        static void QueryAttributeElement( )
        {
            XElement root = XElement.Load(@"userlist.xml");
            
            //查询所有User
            var userLst =
                from ele in root.Elements("User")
                select ele;
            foreach (var item in userLst)
            {
                System.Console.WriteLine(item);
            }

            //查询所有User的姓名
            var nameLst =
                from ele in root.Elements("User")                
                select ((XAttribute)ele.Attribute("Name")).Value;
            foreach (string name in nameLst)
            {
                System.Console.Write("{0},",name);
            }
            System.Console.WriteLine( );

            //查询年龄大于20岁的User
            var ageLst =
                from ele in root.Elements("User")
                where int.Parse(ele.Attribute("Age").Value) > 20
                select new {Name=ele.Attribute("Name").Value, Age=ele.Attribute("Age").Value};
            foreach (var item in ageLst)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
