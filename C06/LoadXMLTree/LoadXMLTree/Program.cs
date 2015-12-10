using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace LoadXMLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoveBySelf();
        }

        static void LoadXMLTree( )
        {
            //创建一段简单的XML数据
            string xmlData = 
                      @"<ItemList>
                          <Item1 />
                          <Item3 />
                          <Item5 />
                        </ItemList>";
            //通过File.WriteAllText()方法将XML数据写入到临时文件tmpData.xml中
            File.WriteAllText("tmpData.xml", xmlData);
            //通过XElment.Load()方法从文件加载xml数据，并同时加载行和空白信息
            XElement ele = XElement.Load("tmpData.xml", LoadOptions.SetLineInfo);
            //在item1和item3之后添加两个新的子元素
            ele.Element("Item1").AddAfterSelf(new XElement("Item2"));
            ele.Element("Item3").AddAfterSelf(new XElement("Item4"));
            //依次打印ele中的所有元素，并判断是否具有行号信息，有则打印
            foreach (XElement item in ele.DescendantsAndSelf())
            {
                //将XElement强制转换成IXmlLineInfo类，从而获取是否包含行号信息
                if (((IXmlLineInfo) item).HasLineInfo( ))
                    System.Console.Write("Line {0} :\t", ((IXmlLineInfo) item).LineNumber);
                else
                    System.Console.Write("Line XX :\t");
                System.Console.Write(item.Name);
                System.Console.WriteLine( );
            }
        }

        static void AddElement( )
        {
            //创建一段简单的XML数据
            string xmlData =
                      @"<Root>
                            <ItemList1>
                              <Item11 />
                              <Item12 />
                            </ItemList1>
                        </Root>";
            //通过File.WriteAllText()方法将XML数据写入到临时文件tmpData.xml中
            File.WriteAllText("tmpData.xml", xmlData);
            //通过XElment.Load()方法从文件加载xml数据，并同时加载行和空白信息
            XElement root = XElement.Load("tmpData.xml", LoadOptions.SetLineInfo);
            //获取ele1作为要添加的源元素
            XElement ele1 = root.Element("ItemList1");
            //创建ele0作为添加ele1之前的元素
            XElement ele0 = new XElement("ItemList0");
            ele0.Add(new XElement("Item02"));
            ele0.AddFirst(new XElement("Item01"));
            ele0.Add(new XElement("Item03"), new XElement("Item04"));            
            ele1.AddBeforeSelf(ele0);
            //创建ele4，并用LINQ查询填充，然后添加到ele1之后
            XElement ele4 = new XElement("ItemList4");
            IEnumerable<XElement> eleList =
                from e in ele1.Elements( )
                select e;
            ele4.AddFirst(eleList);
            ele1.AddAfterSelf(ele4);            
            //添加ItemList2和ItemList3到ele1之后
            ele1.AddAfterSelf(new XElement("ItemList2"), new XElement("ItemList3"));
            System.Console.WriteLine(root);
        }

        static void RemoveAll( )
        {
            //创建XElement对象，
            XElement ele = new XElement("Student",
                new XAttribute("Age", 20),
                new XAttribute("Name", "张三"),
                new XElement("数学", 80),
                new XElement("语文", 90));
            //打印原XML数据
            System.Console.WriteLine("原数据:");
            System.Console.WriteLine(ele);
            //移除所有属性，并打印新的XML数据
            ele.RemoveAttributes( );
            System.Console.WriteLine("调用RemoveAttributes()之后:");
            System.Console.WriteLine(ele);

            //再次创建XElement对象，
            ele = new XElement("Student",
                new XAttribute("Age", 20),
                new XAttribute("Name", "张三"),
                new XElement("数学", 80),
                new XElement("语文", 90));
            //移除所有子元素和属性，并打印新的XML数据
            ele.RemoveAll( );
            System.Console.WriteLine("调用RemoveAll()之后:");
            System.Console.WriteLine(ele);
        }

        static void RemovePart( )
        {
            //创建基本原始的数据元素，
            //通过SetAttributeValue()和SetElementValue()添加属性和子元素
            XElement ele = new XElement("Student");
            ele.SetAttributeValue("Name", "李四");
            ele.SetAttributeValue("Class", "四班");
            ele.SetAttributeValue("Age", 20);
            ele.SetElementValue("数学", 80);
            ele.SetElementValue("语文", 85);
            //打印原始数据
            System.Console.WriteLine("移除数据之前：");
            System.Console.WriteLine(ele);
            //通过SetAttributeValue()和SetElementValue()修改和移除属性或子元素
            ele.SetAttributeValue("Class", "五班");
            ele.SetAttributeValue("Age", null);
            ele.SetElementValue("数学", 88);
            ele.SetElementValue("语文", null);
            //打印修改后的数据
            System.Console.WriteLine("移除部分数据之后：");
            System.Console.WriteLine(ele);
        }

        static void RemoveBySelf( )
        {
            //创建基本原始的数据元素，
            //通过SetAttributeValue()和SetElementValue()添加属性和子元素
            XElement ele = new XElement("Student");
            ele.SetAttributeValue("Name", "李四");
            ele.SetAttributeValue("Class", "四班");
            ele.SetAttributeValue("Age", 20);
            ele.SetElementValue("数学", 70);
            ele.SetElementValue("语文", 85);
            ele.SetElementValue("英语", 60);
            ele.SetElementValue("地理", 90);
            //打印原始数据
            System.Console.WriteLine("移除数据之前：");
            System.Console.WriteLine(ele);
            //创建查询eleList，返回大于80分的成绩元素，并移除,打印新数据
            IEnumerable<XElement> eleList =
                from e in ele.Elements( )
                where int.Parse(e.Value) > 80
                select e;
            eleList.Remove( );
            System.Console.WriteLine("移除大于80分的成绩后：");
            System.Console.WriteLine(ele);
            //获取名称为数学的子元素，并移除，打印新数据
            XElement eleMath = ele.Element("数学");
            eleMath.Remove( );
            System.Console.WriteLine("再移除数学成绩后：");
            System.Console.WriteLine(ele);
            //创建查询atrList，返回Class和Age属性，并移除,打印新数据
            IEnumerable<XAttribute> atrList =
                from atr in ele.Attributes( )
                where (atr.Name == "Class") || (atr.Name == "Age")
                select atr;
            atrList.Remove( );
            System.Console.WriteLine("再移除Class和Age属性后：");
            System.Console.WriteLine(ele);
        }
    }
}
