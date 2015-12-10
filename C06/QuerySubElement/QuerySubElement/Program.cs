using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace QuerySubElement
{
    class Program
    {
        static void Main(string[] args)
        {
            QuerySubElement( );
        }

        static void QuerySubElement( )
        {
            XElement root = XElement.Load(@"UserList.xml");

            //查询所有用户的性别，并打印
            var query1 =
                from ele in root.Elements("User")
                from ele2 in ele.Elements( )
                where ele2.Name.LocalName == "Sex"
                select new {name = ele.Attribute("Name").Value, sex = ele2.Value };
            foreach (var item in query1)
            {
                System.Console.WriteLine(item);
            }

            //查询所有用户中，性别为女性（Female）的用户，并打印
            var query2 =
                from ele in root.Elements("User")
                where ele.Element("Sex").Value == "Female"
                select ele;
            foreach (var item in query2)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
