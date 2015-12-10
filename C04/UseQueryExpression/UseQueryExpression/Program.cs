using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseQueryExpression
{
    /// <summary>
    /// 学生成绩
    /// </summary>
    class LessonScore
    {
        /// <summary>
        /// 创建成绩单，传入课程名，分数
        /// </summary>
        public LessonScore(string les, float scr)
        {
            this._Lesson = les;
            this._Score = scr;
        }
        private float _Score;
        /// <summary>
        /// 课程成绩
        /// </summary>
        public float Score
        {
            get
            {
                return this._Score;
            }
        }
        public string _Lesson;
        /// <summary>
        /// 课程名称
        /// </summary>
        public string Lesson
        {
            get
            {
                return this._Lesson;
            }
        }
    public override string ToString( )
    {
        string str;
        str = string.Format("{0}---{1}分", this._Lesson, this._Score);
        return str;
    }
    }
    class Student
    {
        
        /// <summary>
        /// 学生姓名
        /// </summary>
        private string _Name;
        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        /// <summary>
        /// 学生性别,男或女
        /// </summary>
        private string _XingBie;
        public string XingBie
        {
            get
            {
                return this._XingBie;
            }
        }

        private uint _Age;
        /// <summary>
        /// 学生年龄
        /// </summary>
        public uint Age
        {
            get
            {
                return this._Age;
            }
        }

        private List<LessonScore> _Scores;
        /// <summary>
        /// 成绩单
        /// </summary>
        public List<LessonScore> Scores
        {
            get
            {
                return this._Scores;
            }
        }

        /// <summary>
        /// 构造函数，传入姓名，年龄，性别，成绩单。
        /// </summary>
        public Student(string name, string xb, uint age, List<LessonScore> scrs)
        {
            this._Age = age;
            this._Name = name;
            this._XingBie = xb;
            this._Scores = scrs;
        }

        /// <summary>
        /// 构造函数，传入姓名，年龄，性别。
        /// </summary>
        public Student(string name, string xb, uint age)
        {
            this._Age = age;
            this._Name = name;
            this._XingBie = xb;
            this._Scores = null;
        }

        /// <summary>
        /// 重写ToString(),获取学生的文本形式
        /// </summary>
        public override string ToString( )
        {
            string str;
            str = string.Format("{0}-{1}-{2}", 
                this._Name, this._Age, this._XingBie);
            return str;
        }
    }

    

    class Program
    {
        static void Main(string[] args)
        {
            UseUnionFrom2();
        }

        static void UseSimpleSelect( )
        {
            Student[] stAry = 
                {
                    new Student("张三", "男", 20),
                    new Student("欧阳权宜", "男", 22),
                    new Student("李霞红", "女", 23),
                    new Student("王码码", "男", 21),
                    new Student("王丹", "女", 18),
                };

            var query1 =            
                from val1 in stAry
                select val1;
            //打印查询query1的元素
            foreach (Student item in query1)
            {
                System.Console.WriteLine(item);
            }

            var query2 =
                from val2 in stAry
                select val2.Name;
            //打印查询query2的元素
            foreach (string item in query2)
            {
                System.Console.Write("{0},", item);
            }
            System.Console.WriteLine( );
            var query3 =
                from val3 in stAry
                select val3.Name.Length;
            //打印查询query3的元素
            foreach (int item in query3)
            {
                System.Console.Write("{0},", item);
            }
            System.Console.WriteLine( );
            
            var query4 =
                from val4 in stAry
                select new { val4.Name, val4.Age, NameLen = val4.Name.Length };
            //打印查询query4的元素
            foreach (var item in query4)
            {
                System.Console.WriteLine(item);
            }
        }

        static void UseSimpleFrom( )
        {
            int[] ary = { 1, 2, 3, 5, 7 };
            var query1 =
                from val1 in ary
                select val1;
            var query2 =
                from object val2 in ary
                select val2;
            var query3 =
                from Student val3 in ary
                select val3;
            /*
            foreach (var item in query3)
            {
                System.Console.WriteLine(item.ToString( ));
            }
            */
        }

        static void UseSimpleWhere( )
        {
            //创建int数组ary作为数据源
            int[] ary = 
                { 1, 3, 9, 54, 20, 10, 23, 12, 18, 60, 37 };
            //查询query1返回ary中所有大于15的元素
            var query1 =
                from val1 in ary
                where val1 > 15
                select val1;
            //打印query1的数据
            foreach (var item in query1)
            {
                System.Console.Write("{0}, ", item);
            }
            System.Console.WriteLine( );
            //查询query2返回ary中所有大于10且小于40的元素，演示&&的使用
            var query2 =
                from val2 in ary
                where (val2 > 10) && (val2 < 40)
                select val2;
            //打印查询query2的元素
            foreach (var item in query2)
            {
                System.Console.Write("{0}, ", item);
            }
            System.Console.WriteLine( );
            //查询query3返回ary中所有小于10或大于40的元素，演示||的使用
            var query3 =
                from val3 in ary
                where (val3 < 10) || (val3 > 40)
                select val3;
            //打印查询query3的元素
            foreach (var item in query3)
            {
                System.Console.Write("{0}, ", item);
            }
            System.Console.WriteLine( );
            //查询query4返回ary中所有大于10且小于40的元素，演示多个where子句的使用
            var query4 =
                from val4 in ary
                where val4 > 10
                where val4 < 40
                select val4;
            //打印查询query4的元素
            foreach (var item in query4)
            {
                System.Console.Write("{0}, ", item);
            }
        }

        static void UseSimpleSort( )
        {
            //创建int数组ary作为数据源
            int[] ary = { 9, 54, 20, 11, 3, 0, 23, 12, 18, 60, 37 };
            //查询query1返回ary中所有元素，并从小到大排序
            var query1 =
                from val1 in ary
                orderby val1
                select val1;
            //打印查询query1的元素
            foreach (var item in query1)
            {
                System.Console.Write("{0}, ", item);
            }
            System.Console.WriteLine( );
            //查询query2返回ary中所有元素，并从大到小排序
            var query2 =
                from val2 in ary
                orderby val2 descending
                select val2;
            //打印查询query2的元素
            foreach (var item in query2)
            {
                System.Console.Write("{0}, ", item);
            }
        }

        static void UseComplexSort( )
        {
            //创建学生信息数组stAry作为数据源
            Student[] stAry = 
                {
                    new Student("张三", "男", 20),
                    new Student("欧阳权宜", "男", 22),
                    new Student("李霞红", "女", 21),
                    new Student("王码码", "男", 22),
                    new Student("王丹", "女", 18),
                };
            //查询query3返回stAry中所有元素，主要按姓名字符数从小到大排序
            //次要按学生姓名从大到小排序
            var query3 =
                from st in stAry
                orderby st.Name.Length ascending, st.Age descending
                select st;
            //打印查询query3的元素
            foreach (var item in query3)
            {
                System.Console.WriteLine(item);
            }
        }

        static void UseSimpleGroupBy( )
        {
            //创建学生信息数组stAry作为数据源
            Student[] stAry = 
                {
                    new Student("张三", "男", 20),
                    new Student("欧阳权宜", "男", 22),
                    new Student("李霞红", "女", 21),
                    new Student("王码码", "男", 22),
                    new Student("王丹", "女", 18),
                };
            //查询query1返回stAry中所有元素，并按照学生性别分组
            var query1 = 
                from st in stAry
                group st by st.XingBie;
            //打印query1的元素
            foreach (var grp in query1)
            {
                System.Console.WriteLine(grp.Key);
                foreach (var val in grp)
                {
                    System.Console.WriteLine("\t{0}", val);
                }
            }
        }

        static void UseComplexGroupBy( )
        {
            //创建学生信息数组stAry作为数据源
            Student[] stAry = 
                {
                    new Student("张三", "男", 20),
                    new Student("欧阳权宜", "男", 22),
                    new Student("李霞红", "女", 20),
                    new Student("王码码", "男", 22),
                    new Student("王丹", "女", 18),
                };
            //查询query1返回stAry中所有元素，并按照学生年龄分组，并根据年龄从高到低排序
            var query2 =
                from st in stAry
                group st by st.Age into stGrp
                orderby stGrp.Key descending
                select stGrp;
            //打印query2的元素
            foreach (var stGrp in query2)
            {
                System.Console.WriteLine("{0}岁的学生:", stGrp.Key);
                foreach (var st in stGrp)
                {
                    System.Console.WriteLine("\t{0}", st);
                }
            }
        }

        static void UseUnionFrom( )
        {
            //创建学生信息数组stAry作为数据源
            Student[] stAry = 
                {
                    new Student("张三", "男", 20, 
                        new List<LessonScore>{ new LessonScore("英语", 80.5f),
                            new LessonScore("数学", 70.0f), new LessonScore("语文", 60.5f)}),
                    new Student("欧阳权宜", "男", 22, 
                        new List<LessonScore>{ new LessonScore("英语", 90.5f),
                            new LessonScore("数学", 80.0f), new LessonScore("语文", 50.5f)}),
                    new Student("李霞红", "女", 20, 
                        new List<LessonScore>{ new LessonScore("英语", 80.5f),
                            new LessonScore("数学", 50.5f), new LessonScore("语文", 50.5f)}),
                    new Student("王码码", "男", 22, 
                        new List<LessonScore>{ new LessonScore("英语", 50.5f),
                            new LessonScore("数学", 80.0f), new LessonScore("语文",40.5f)}),
                    new Student("王丹", "女", 18, 
                        new List<LessonScore>{ new LessonScore("英语", 80.5f),
                            new LessonScore("数学", 90.0f), new LessonScore("语文", 70.5f)}),
                };
            //查询query1采用两个from子句实现复合查询
            //第二个from子句的元素从第一个from子句的结果中再次查询
            var query1 =
                from st in stAry
                from scr in st.Scores
                where scr.Score > 80
                group new { st.Name, scr } by st.Name;
            //打印查询query1的元素
            foreach (var grp in query1)
            {
                System.Console.WriteLine(grp.Key);
                foreach (var item in grp)
                {
                    System.Console.WriteLine("\t{0}", item);
                }
            }
        }

        static void UseUnionFrom2( )
        {
            //创建两个整数数组intAry1和intAry2作为数据源
            int[] intAry1 = {5, 15, 25, 30, 33, 50};
            int[] intAry2 = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
            //查询query1从两个数据源intAry1和intAry2中获取数据
            var query1 =
                from val1 in intAry1
                from val2 in intAry2
                where val2 % val1 == 0
                group val2 by val1;
            //打印查询query1的元素
            foreach (var grp in query1)
            {
                System.Console.Write("{0}: ", grp.Key);
                foreach (var val in grp)
                {
                    System.Console.Write("{0} ", val);
                }
                System.Console.WriteLine( );
            }
        }

        static void UseInnerJoin( )
        {
            //创建两个整数数组intAry1和intAry2作为数据源
            int[] intAry1 = {5, 15, 25, 30, 33, 40};
            int[] intAry2 = {10, 20, 30, 50, 60, 70, 80};
            //查询query1使用join子句从两个数据源获取数据，演示内部联接的使用
            var query1 =
                from val1 in intAry1
                join val2 in intAry2 on val1%5 equals val2%15
                select new {VAL1=val1, VAL2=val2};
            //打印查询query1的元素
            foreach (var item in query1)
            {
                System.Console.WriteLine(item);
            }
        }

        static void UseGroupJoin( )
        {
            //创建两个整数数组intAry1和intAry2作为数据源
            int[] intAry1 = { 5, 15, 25, 30, 33, 40 };
            int[] intAry2 = { 10, 20, 30, 50, 60, 70, 80 };
            //查询query1使用join子句从两个数据源获取数据，演示分组联接的使用
            var query1 =
                from val1 in intAry1
                join val2 in intAry2 on val1 % 5 equals val2 % 15 into val2Grp
                select new { VAL1 = val1, VAL2GRP = val2Grp};
            //打印查询query1的元素
            foreach (var obj in query1)
            {
                System.Console.Write("{0}: ", obj.VAL1);
                foreach (var val in obj.VAL2GRP)
                {
                    System.Console.Write("{0} ", val);
                }
                System.Console.WriteLine( );
            }
        }

        static void UseLeftJoin( )
        {
            //创建两个整数数组intAry1和intAry2作为数据源
            int[] intAry1 = { 5, 15, 23, 30, 33, 40 };
            int[] intAry2 = { 10, 20, 30, 50, 60, 70, 80 };
            //查询query1使用join子句从两个数据源获取数据，演示左联接的使用
            var query1 =
                from val1 in intAry1
                join val2 in intAry2 on val1 % 5 equals val2 % 15 into val2Grp
                from grp in val2Grp.DefaultIfEmpty()
                select new { VAL1 = val1, VAL2GRP = grp };
            //打印查询query1的元素
            foreach (var obj in query1)
            {
                System.Console.WriteLine("{0}", obj);
            } 
        }
    }
}
