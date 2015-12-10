using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QueryMultiTable
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryStuScores( );
            QueryNoneScoreStu( );
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

        static void QueryStuScores( )
        {
            //获取数据集和要进行查询的数据表
            DataSet ds = BuildDataSet( );
            DataTable dtStu = ds.Tables["Students"];
            DataTable dtScore = ds.Tables["Scores"];
            //查询query1查询所有学生的成绩
            var query1 =
                from stu in dtStu.AsEnumerable( )
                from score in dtScore.AsEnumerable( )
                where stu.Field<int>("ScoreID") == score.Field<int>("ScoreID")
                select new
                {
                    Name = stu.Field<string>("Name"),
                    MathS = score.Field<int>("Math"),
                    Chinese = score.Field<int>("Chinese"),
                    English = score.Field<int>("English")
                };
            //打印查询query1的结果
            System.Console.WriteLine("Query1-所有学生成绩：");
            foreach (var item in query1)
            {
                System.Console.WriteLine("姓名:{0}, 数学:{1}, 语文:{2}, 英语:{3}",
                    item.Name, item.MathS, item.Chinese, item.English);
            }
        }

        static void QueryNoneScoreStu( )
        {
            //获取数据集和要进行查询的数据表
            DataSet ds = BuildDataSet( );
            DataTable dtStu = ds.Tables["Students"];
            DataTable dtScore = ds.Tables["Scores"];
            //查询scoreIDs查询所有有成绩的学生的成绩编号
            var scoreIDs =
                from score in dtScore.AsEnumerable( )
                select score.Field<int>("ScoreID");
            //查询query2查询所有成绩号不在查询scoreIDs中学生信息
            var query2 =
                from stu in dtStu.AsEnumerable( )
                where !scoreIDs.Contains<int>(stu.Field<int>("ScoreID"))
                select stu;
            //打印查询query2的结果
            System.Console.WriteLine("Query2-没有成绩的学生：");
            foreach (var item in query2)
            {
                System.Console.WriteLine("姓名:{0}, 性别:{1}, 年龄:{2}",
                    item.Field<string>("Name"), item.Field<string>("XingBie"), item.Field<int>("Age"));
            }

            //查询scrStu查询所有具有成绩信息的学生
            var scrStu =
                from stu in dtStu.AsEnumerable( )
                from score in dtScore.AsEnumerable( )
                where stu.Field<int>("ScoreID") == score.Field<int>("ScoreID")
                select stu;
            //查询query3是从所有学生记录中剔除具有成绩的学生。
            var query3 = dtStu.AsEnumerable( ).Except(scrStu);
            //打印查询query3的结果
            System.Console.WriteLine("Query3-没有成绩的学生：");
            foreach (var item in query3)
            {
                System.Console.WriteLine("姓名:{0}, 性别:{1}, 年龄:{2}",
                    item.Field<string>("Name"), item.Field<string>("XingBie"), item.Field<int>("Age"));
            }
        }

    }
}
