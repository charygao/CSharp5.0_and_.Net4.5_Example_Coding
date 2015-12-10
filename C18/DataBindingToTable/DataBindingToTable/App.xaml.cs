using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DAL;

namespace DataBindingToTable
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        //获取DAL程序集中的数据访问类。
        private static ProductDb productdb = new ProductDb();
        public static ProductDb ProductDb
        {
            get { return productdb; }
        }
    }
}
