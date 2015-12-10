using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseMethodSynax
{
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

        /// <summary>
        /// 构造函数，传入姓名，年龄，性别。
        /// </summary>
        public Student(string name, string xb, uint age)
        {
            this._Age = age;
            this._Name = name;
            this._XingBie = xb;
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

    /// <summary>
    /// 自定义的int类型比较器，实现IComparer<int>接口
    /// </summary>
    class MyComparer : IComparer<int>
    {
        /// <summary>
        /// 比较函数具体实现，对x和y的绝对值进行比较。
        /// </summary>
        public int Compare(int x, int y)
        {
            int x1 = Math.Abs(x);
            int y1 = Math.Abs(y);
            //如果|x|>|y|，返回1
            if (x1 > y1) 
                return 1;
            //如果|x|=|y|，返回0
            else if(x1 == y1) 
                return 0;
            //如果|x|<|y|，返回-1
            else 
                return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UseSetOpSimple( );
        }

        static void LamdaExpExa( )
        {
            int[] intAry = {2, 4, 5, 8, 9, 11};
            var query1 = intAry.Where(num => num%2 == 0);
            foreach (var val in query1)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
        }

        static void UseWhereLambda( )
        {
            //创建int数组intAry作为数据源
            int[] intAry = {1, 2, 3, 5, 7, 8, 10, 30, 33, 44, 45};
            //查询query1通过Where和Lambda表达式查询intAry中所有能被5整除的元素
            var query1 = intAry.Where(num => num % 5 == 0);
            //打印查询query1的元素
            System.Console.Write("query1:");
            foreach (var val in query1)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
            //查询query1通过Where和Lambda表达式查询intAry中所有值大于3倍索引的元素
            var query2 = intAry.Where((num, index) => num > index * 3);
            //打印查询query2的元素
            System.Console.Write("query2:");
            foreach (var val in query2)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
        }

        static void UseOrderBy( )
        {
            //创建int数组intAry作为数据源
            int[] intAry = { 3, -2, 5, 8, 3, 4, 2, 19, 20 };
            //查询quer1对intAry中的所有元素按照val%10从小到大进行排序
            var query1 = intAry.OrderBy(val => val%10);
            //打印查询query1的元素
            System.Console.Write("query1:");
            foreach (var val in query1)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
            //查询quer2对intAry中的所有元素按照val%10从大到小进行排序
            var query2 = intAry.OrderByDescending(val => val%10);
            //打印查询query2的元素
            System.Console.Write("query2:");
            foreach (var val in query2)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
        }

        static void UseOrderByDef( )
        {
            //创建自定义int类型比较器MyComparer对象mc
            MyComparer mc = new MyComparer( );
            //创建int数组intAry作为数据源
            int[] intAry = { 3, -2, 5, 8, -3, -4, 2, -19, 20 };
            //查询query3对intAry中所有元素使用自定义比较器从小到大排序
            var query3 = intAry.OrderBy(val => val, mc);
            //打印查询query3的元素
            System.Console.Write("query3:");
            foreach (var val in query3)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
            //查询query4对intAry中所有元素使用自定义比较器从大到小排序
            var query4 = intAry.OrderByDescending(val => val, mc);
            //打印查询query4的元素
            System.Console.Write("query4:");
            foreach (var val in query4)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
        }

        static void UseSkip( )
        {
            //创建int类型数组intAry作为数据源
            int[] intAry = { 3, -2, 5, 8, -13, -4, 12, -19, 20 };
            //查询query1跳过intAry中的前面3个元素
            var query1 = intAry.Skip(3);
            //打印查询query1的元素
            System.Console.Write("query1: ");
            foreach (var val in query1)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
            //查询query2跳过intAry中从第0个元素开始连续的绝对值小于10的元素
            var query2 = intAry.SkipWhile(num => num / 10 == 0);
            //打印查询query2的元素
            System.Console.Write("query2: ");
            foreach (var val in query2)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
        }
        static void UseTake( )
        {
            //创建int类型数组intAry作为数据源
            int[] intAry = { 3, -2, 5, 8, -13, -4, 12, -19, 20 };
            //查询query1提取intAry中的前面3个元素
            var query1 = intAry.Take(3);
            //打印查询query1的元素
            System.Console.Write("query1: ");
            foreach (var val in query1)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
            //查询query2提取intAry中从第0个元素开始连续的绝对值小于10的元素
            var query2 = intAry.TakeWhile(num => num / 10 == 0);
            //打印查询query2的元素
            System.Console.Write("query2: ");
            foreach (var val in query2)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
        }

        static void UseValueCalc( )
        {
            //创建int类型数组intAry作为数据源
            int[] intAry = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var intMax = intAry.Max( );         //intAry中的最大值
            var intMin = intAry.Min( );         //intAry中的最小值
            var intAverage = intAry.Average( ); //intAry中元素的平均值
            var intSum = intAry.Sum( );         //intAry中元素的累加和
            //打印计算结果
            System.Console.WriteLine("intAry's max = {0}, min = {1}, average = {2}, sum = {3}",
                                    intMax, intMin, intAverage, intSum);
            //创建string数组strAry作为数据源
            string[] strAry = {"Hello", "hello", "thanks", "alibaba", "street" };
            var strMax = strAry.Max( );         //strAry中的最大值
            var strMin = strAry.Min( );         //strAry中的最小值
            //打印计算结果
            System.Console.WriteLine("strAry's max = {0}, min = {1}", strMax, strMin);
        }

        static void UseValueCalc2( )
        {
            //创建string数组strAry作为数据源
            string[] strAry = { "Hello", "hel", "thanks", "alibaba", "street" };
            var strMax = strAry.Max(str => str.Length); //strAry中的元素字符串长度最大值
            var strMin = strAry.Min(str => str.Length); //strAry中的元素字符串长度最小值
            //打印计算结果
            System.Console.WriteLine("strAry's max = {0}, min = {1}", strMax, strMin);
            var strSum = strAry.Sum(str => str.Length); //strAry中的元素字符串长度累加和
            var strAverage = strAry.Average(str => str.Length);//strAry中的元素字符串长度平均值
            //打印计算结果
            System.Console.WriteLine("strAry's sum = {0}, average = {1}", strSum, strAverage);
        }

 

        static void UseDistinctSimple( )
        {
            //创建int类型数组intAry作为数据源
            int[] intAry = {1, 3, 6, 9, 1, 3, 9, 10, 2, 5, 3, 10};
            //查询query1对intAry中的元素进行消除重复操作
            var query1 = intAry.Distinct( );
            //打印查询query1的元素
            System.Console.Write("query1: ");
            foreach (var item in query1)
            {
                System.Console.Write("{0} ", item);
            }
        }
        
        /// <summary>
        /// 自定义的字符串相等比较器，实现IEqualityComparer<string>接口
        /// </summary>
        class MyStrEqualComparer : IEqualityComparer<string>
        {
            /// <summary>
            /// 实现Equals()方法
            /// </summary>
            bool IEqualityComparer<string>.Equals(string x, string y)
            {
                //如果两个字符传的第一个字符相等，则返回true
                return x.Substring(0,1) == y.Substring(0,1);
            }
            /// <summary>
            /// 实现GetHashCode()方法
            /// </summary>
            public int GetHashCode(string obj)
            {
                //将字符串的长度作为它的哈希码
                return obj.Length;
            }
        }
        static void UseDistinctComplex( )
        {
            //创建string类型数组strAry作为数据源
            string[] strAry = {"hel", "how", "hello", "tower", "his", "aim", "aha", "hints"};
            //创建自定义string相等比较器MyStrEqualComparer对象mcStr
            MyStrEqualComparer mcStr = new MyStrEqualComparer();
            //查询query2使用自定义相等比较器mcStr对strAry执行消除重复操作
            var query2 = strAry.Distinct(mcStr);
            //打印查询query2的元素
            System.Console.Write("query2: ");
            foreach (var val in query2)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
       }

        static void UseContact( )
        {
            //创建两个string数组strAry1和strAry2作为数据源
            string[] strAry1 = {"Hello,", "Nice", "to", "meet", "you!",};
            string[] strAry2 = {"Jone", "Smith", "Phil" };
            //查询query1将strAry2连接到strAry1之后
            var query1 = strAry1.Concat(strAry2);
            //打印查询query1的元素
            System.Console.Write("query1: ");
            foreach (var item in query1)
            {
                System.Console.Write("{0} ", item);
            }
            System.Console.WriteLine( );
            //查询query2将strAry1连接到strAry2之后
            var query2 = strAry2.Concat(strAry1);
            //打印查询query2的元素
            System.Console.Write("query2: ");
            foreach (var item in query2)
            {
                System.Console.Write("{0} ", item);
            }
            System.Console.WriteLine( );
        }

        static void UseSetOpSimple( )
        {
            //创建两个int类型数组intAry1和intAry2作为数据源
            int[] intAry1 = {1, 3, 5, 8, 10, 12, 33, 45, 12, 2};
            int[] intAry2 = {2, 5, 10, 6, 7, 11, 23, 25, 45, 33};
            //查询query1返回intAry1和intAry2的并集
            var query1 = intAry1.Union(intAry2);
            //打印查询query1的元素
            System.Console.Write("query1: ");
            foreach (var val in query1)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
            //查询query2返回intAry1和intAry2的交集
            var query2 = intAry1.Intersect(intAry2);
            //打印查询query2的元素
            System.Console.Write("query2: ");
            foreach (var val in query2)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
            //查询query3返回intAry1对intAry2的差集
            var query3 = intAry1.Except(intAry2);
            //打印查询query3的元素
            System.Console.Write("query3: ");
            foreach (var val in query3)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
            //查询query4返回intAry2对intAry1的差集
            var query4 = intAry2.Except(intAry1);
            //打印查询query4的元素
            System.Console.Write("query4: ");
            foreach (var val in query4)
            {
                System.Console.Write("{0} ", val);
            }
            System.Console.WriteLine( );
        }
    }
}
