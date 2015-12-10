using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace QueryInContent
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryInContent( );
        }

        static void QueryInContent( )
        {
            XElement root = XElement.Load(@"UserList.xml");

            //获取所有在后的兄弟元素节点数量大于2的元素
            var query1 =
                from ele in root.Elements("User")
                where ele.ElementsAfterSelf("User").Count() > 2
                select ele;
            System.Console.WriteLine("query1 is:");
            foreach (var item in query1)
            {
                System.Console.WriteLine(item);
            }

            //获取所有在前的兄弟元素节点数量大于2的元素
            var query2 =
                from ele in root.Elements("User")
                where ele.ElementsBeforeSelf("User").Count( ) > 2
                select ele;
            System.Console.WriteLine("query2 is:");
            foreach (var item in query2)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
