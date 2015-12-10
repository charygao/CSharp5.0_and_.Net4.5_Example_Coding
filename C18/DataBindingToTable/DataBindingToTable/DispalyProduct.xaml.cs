using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DAL;
namespace DataBindingToTable
{
    /// <summary>
    /// DispalyProduct.xaml 的交互逻辑
    /// </summary>
    public partial class DispalyProduct : Window
    {
        public DispalyProduct()
        {
            InitializeComponent();
        }

        private void cmdGetProduct_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            //获取文本框中用户输入的产品编码
            if (Int32.TryParse(txtID.Text, out ID))
            {
                try
                {
                    //为Grid指定DataContext属性，使其绑定到Product对象上。
                    gridProductDetails.DataContext = App.ProductDb.GetProduct(ID);
                }
                catch
                {
                    MessageBox.Show("Error contacting database.");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID.");
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            //获取当前数据绑定上下文的Product对象
            Product product = (Product)gridProductDetails.DataContext;
            try
            {
                //调用数据访问层的UpdateProduct方法更新回数据库
                App.ProductDb.UpdateProduct(product);
            }
            catch
            {
                MessageBox.Show("Error contacting database.");
            }
        }
    }
}
