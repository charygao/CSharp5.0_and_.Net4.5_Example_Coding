using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UseCopyToTable
{
    class Program
    {
        static void Main(string[] args)
        {
            UseCopyToDTSimple( );
            UseSetField( );
        }

        static DataSet BuildDataSet( )
        {
            //创建Students数据集
            DataSet ds = new DataSet("Students");
            //创建Students数据表，并添加到数据集
            //Students数据表包含学生信息
            DataTable dtStu = new DataTable("Students");
            ds.Tables.Add(dtStu);
            //添加学生信息记录的列信息
            dtStu.Columns.AddRange(new DataColumn[]{
                new DataColumn("Name", Type.GetType("System.String")),
                new DataColumn("XingBie", Type.GetType("System.String")),
                new DataColumn("Age", Type.GetType("System.Int32")),
                new DataColumn("ScoreID", Type.GetType("System.Int32")),
            });
            //添加学生信息的行信息
            dtStu.Rows.Add("张三", "男", 20, 1);
            dtStu.Rows.Add("李四", "男", 19, 2);
            dtStu.Rows.Add("王霞", "女", 21, 3);
            dtStu.Rows.Add("赵敏", "女", 22, 4);
            dtStu.Rows.Add("吴安", "男", 18, 5);
            //创建Scores数据表，并添加到数据集
            //Scores数据表包含学生成绩记录
            DataTable dtScore = new DataTable("Scores");
            ds.Tables.Add(dtScore);
            //添加成绩记录的列信息
            dtScore.Columns.AddRange(new DataColumn[]{
                new DataColumn("ScoreID", Type.GetType("System.Int32")),
                new DataColumn("Math", Type.GetType("System.Int32")),
                new DataColumn("Chinese", Type.GetType("System.Int32")),
                new DataColumn("English", Type.GetType("System.Int32")),
            });
            //添加学生成绩记录
            dtScore.Rows.Add(1, 80, 75, 78);
            dtScore.Rows.Add(3, 88, 80, 60);
            dtScore.Rows.Add(4, 75, 90, 80);
            dtScore.Rows.Add(5, 59, 80, 75);
            //返回数据集
            return ds;
        }

        static void UseCopyToDTSimple( )
        {
            //获取数据集和要进行查询的数据表
            DataSet ds = BuildDataSet( );
            DataTable dtStu = ds.Tables["Students"];
            DataTable dtScore = ds.Tables["Scores"];
            //查询query1年龄大于20且具有成绩的学生
            var query1 =
                from stu in dtStu.AsEnumerable( )
                from score in dtScore.AsEnumerable( )
                where stu.Field<int>("ScoreID") == score.Field<int>("ScoreID")
                where (int)stu["Age"] > 20
                select stu;
            //通过CopyToDataTable()方法创建新的副本
            DataTable newDt = query1.CopyToDataTable<DataRow>( );
            //打印副本的信息
            System.Console.WriteLine("学生列表：");
            foreach (var item in newDt.AsEnumerable())
            {
                System.Console.WriteLine("姓名:{0}, 性别:{1}， 年龄:{2}",
                    item["Name"], item["XingBie"], item["Age"]);
            }
        }

        static void UseSetField( )
        {
            //获取数据集和要进行查询的数据表
            DataSet ds = BuildDataSet( );
            DataTable dtStu = ds.Tables["Students"];
            //将所有学生的年龄都增加2岁
            foreach (var row in dtStu.AsEnumerable())
            {
                int age = row.Field<int>("Age");
                row.SetField<int>("Age", age + 2);
            }
            //打印新的学生信息
            System.Console.WriteLine("学生列表：");
            foreach (var item in dtStu.AsEnumerable( ))
            {
                System.Console.WriteLine("姓名:{0}, 性别:{1}， 年龄:{2}",
                    item["Name"], item["XingBie"], item["Age"]);
            }
        }
    }
}
