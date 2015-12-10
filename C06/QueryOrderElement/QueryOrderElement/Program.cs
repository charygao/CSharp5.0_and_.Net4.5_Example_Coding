using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace QueryOrderElement
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderbyElement( );
        }

        static void OrderbyElement( )
        {
            XElement root = XElement.Load(@"UserList.xml");

            //按照年龄从大到小排序
            var query1 =
                from ele in root.Elements("User")
                orderby ele.Attribute("Age").Value descending
                select new {name=ele.Attribute("Name").Value, age=ele.Attribute("Age").Value};
            System.Console.WriteLine("query1 is:");
            foreach (var item in query1)
            {
                System.Console.WriteLine(item);
            }

            //按照年龄从小到大排序，且年龄大于20岁
            var query2 =
                from ele in root.Elements("User")
                where int.Parse(ele.Attribute("Age").Value) > 20
                orderby ele.Attribute("Age").Value
                select new { name = ele.Attribute("Name").Value, age = ele.Attribute("Age").Value };
            System.Console.WriteLine("query2 is:");
            foreach (var item in query2)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
