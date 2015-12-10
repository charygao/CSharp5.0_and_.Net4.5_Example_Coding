using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace QueryOneTable
{
    class Program
    {
        static void Main(string[] args)
        {
            UseSelect( );
            UseOrderByWhere( );
        }

        //随机创建一个包含数据的DataSet
        static DataSet BuildOneDTDataSet( )
        {
            //可选姓名和可选年龄，用于创建数据
            string[] nameSet = {"王霞","张三","李四","李花","王五", "陆六","夏七","吴八" };
            string[] xbSet = { "女", "男", "男", "女", "男", "男", "男", "男" };
            int[] ageSet = {18, 20, 21, 22, 19, 20, 25, 24};
            //创建名为PeopleDS的DataSet对象
            DataSet ds = new DataSet("PeopleDS");
            //创建名为PeopleDT的DataTable对象
            DataTable dt = new DataTable("PeopleDT");
            ds.Tables.Add(dt);
            //创建DataTable的字段
            dt.Columns.AddRange( 
                new DataColumn[]
                {
                    new DataColumn("Name", Type.GetType("System.String")),
                    new DataColumn("XingBie", Type.GetType("System.String")),
                    new DataColumn("Age", Type.GetType("System.Int32")),
                });
            //填充数据
            for (int i = 0; i < nameSet.Length; i++)
            {   
                //创建数据行的数据
                DataRow row = dt.NewRow( );
                row["Name"] = nameSet[i];
                row["Age"] = ageSet[i];
                row["XingBie"] = xbSet[i];
                //添加到数据表中
                dt.Rows.Add(row);
            }
            //返回DataSet
            return ds;
        }

        static void UseSelect( )
        {
            //获取数据集和数据表
            DataSet ds = BuildOneDTDataSet( );
            DataTable dt = ds.Tables["PeopleDT"];
            //查询query1表示查询DataTable中所有记录，演示AsEnumerable()的使用
            var query1 =
                from pl in dt.AsEnumerable( )
                select pl;
            //打印查询query1的结果
            System.Console.WriteLine("Query1:");
            foreach (var item in query1)
            {
                //演示Field<T>方法的使用
                System.Console.WriteLine("姓名:{0}，性别:{1}，年龄:{2}",
                    item.Field<string>("Name"), item.Field<string>("XingBie"), item.Field<int>("Age"));
            }
            //查询query2表示查询DataTable中所有人的姓名，演示AsEnumerable()和Field<T>的使用
            var query2 =
                from pl in dt.AsEnumerable( )
                select pl.Field<string>("Name");
            //打印查询query1的结果
            System.Console.WriteLine("Query2:");
            foreach (var item in query2)
            {
                System.Console.Write("{0} ", item);
            }
            System.Console.WriteLine( );
        }

        static void UseOrderByWhere( )
        {
            //获取数据集和数据表
            DataSet ds = BuildOneDTDataSet( );
            DataTable dt = ds.Tables["PeopleDT"];
            //查询query3查询数据表中所有年龄大于22的人，并且按照年龄从低到高排序
            var query3 =
                from pl in dt.AsEnumerable( )
                orderby pl.Field<int>("Age")
                where pl.Field<int>("Age") > 22
                select pl;
            //打印查询query3的结果
            System.Console.WriteLine("Query3:"); 
            foreach (var item in query3)
            {
                System.Console.WriteLine("姓名:{0}，性别:{1}，年龄:{2}",
                    item.Field<string>("Name"), item.Field<string>("XingBie"), item.Field<int>("Age"));
            }
            //查询query4查询数据表中所有年龄大于20小于25的人，并且按照年龄从高到低排序
            var query4 =
                from pl in dt.AsEnumerable( )
                orderby pl.Field<int>("Age") descending
                where pl.Field<int>("Age") > 20
                where pl.Field<int>("Age") < 25
                select pl;
            //打印查询query4的结果
            System.Console.WriteLine("Query4:");
            foreach (var item in query4)
            {
                System.Console.WriteLine("姓名:{0}，性别:{1}，年龄:{2}",
                    item.Field<string>("Name"), item.Field<string>("XingBie"), item.Field<int>("Age"));
            }
        }

    }
}
