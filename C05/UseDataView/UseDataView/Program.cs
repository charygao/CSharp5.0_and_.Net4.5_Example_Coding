using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UseDataView
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDataVeiw( );
            UseDataView( );
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
            });
            //添加学生信息的行信息
            dtStu.Rows.Add("张三", "男", 20);
            dtStu.Rows.Add("李四", "男", 19);
            dtStu.Rows.Add("王霞", "女", 21);
            dtStu.Rows.Add("赵敏", "女", 22);
            dtStu.Rows.Add("吴安", "男", 18);
            dtStu.Rows.Add("杨花", "女", 23);
            //返回数据集
            return ds;
        }

        static void CreateDataVeiw( )
        {
            //获取数据源
            DataSet ds = BuildDataSet( );
            DataTable dt = ds.Tables["Students"];
            //用DataTable创建DataView
            DataView dvDt = dt.AsDataView( );
            //用LINQ查询创建DataView
            EnumerableRowCollection<DataRow> query1 =
                from stu in dt.AsEnumerable( )
                select stu;
            DataView dvNml = query1.AsDataView( );
            //用LINQ查询创建具有过滤信息的DataView
            EnumerableRowCollection<DataRow> query2 =
                from stu in dt.AsEnumerable( )
                where stu.Field<string>("Name").StartsWith("杨")
                select stu;
            DataView dvFilter = query2.AsDataView( );
            //用LINQ查询创建具有排序信息的DataView
            EnumerableRowCollection<DataRow> query3 =
                from stu in dt.AsEnumerable( )
                orderby stu.Field<int>("Age")
                select stu;
            DataView dvSort = query3.AsDataView( );
        }

        static void UseDataView( )
        {
            //获取数据源
            DataSet ds = BuildDataSet( );
            DataTable dt = ds.Tables["Students"];
            //用DataTable创建DataView
            DataView dvDt = dt.AsDataView( );
            //通过RowFilter属性设置DataView过滤信息,只需要年龄大于20岁的学生记录
            dvDt.RowFilter = "Age > 20";
            //设置RowFilter为null或空字符串，清除过滤信息，二选一
            dvDt.RowFilter = string.Empty;
            dvDt.RowFilter = null;
            //通过Sort属性设置DataView过滤信息
            dvDt.Sort = "Age asc, Name desc";
            //设置RowFilter为null或空字符串，清除过滤信息，二选一
            dvDt.Sort = string.Empty;
            dvDt.Sort = null;
        }
    }
}
