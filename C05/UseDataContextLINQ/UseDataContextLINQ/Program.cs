using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AllStudents("增加前-");
            ModifyStudentsAge( );
            AllStudents("增加后-");
        }
        static void AllStudents(string hint)
        {
            //获取StudentsDataContext对象
            StudentsDataContext dc = new StudentsDataContext( );
            //查询query1查询数据表中所有学生信息，并按照年龄从小到大排序
            IEnumerable<Students> query1 =
                from stu in dc.Students
                orderby stu.Age
                select stu;
            //打印查询query1的信息
            System.Console.WriteLine(hint + "所有学生信息:");
            foreach (Students item in query1)
            {
                System.Console.WriteLine("{0}:{1},{2},", item.Name, item.XingBie, item.Age);
            }
        }

        static void AllStudentsScore( )
        {
            //获取StudentsDataContext对象
            StudentsDataContext dc = new StudentsDataContext( );
            //查询query2查询数据表中所有学生信息，并按照年龄从小到大排序
            IEnumerable<Students> query2 =
                from stu in dc.Students
                orderby stu.Age
                select stu;
            //打印查询query2的信息
            System.Console.WriteLine("所有学生成绩:");
            foreach (Students item in query2)
            {
                System.Console.WriteLine("{0}:数学-{1},语文-{2},英语-{3}",
                                        item.Name, item.Scores.Math, item.Scores.Chinese, item.Scores.English);
            }
        }

        static void ModifyStudentsAge( )
        {
            //获取StudentsDataContext对象
            StudentsDataContext dc = new StudentsDataContext( );
            //遍历所有学生信息
            foreach (Students stu in dc.Students)
            {
                //每个学生的年龄加1岁
                stu.Age = stu.Age + 1;
            }
            //提交数据库更改
            dc.SubmitChanges( );
        }
    }
}
