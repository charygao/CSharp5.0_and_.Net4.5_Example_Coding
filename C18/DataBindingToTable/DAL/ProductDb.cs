using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//需要添加如下三个命名空间
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
namespace DAL
{
   public class ProductDb
    {
       //获取数据库连接字符串
        private string connectionString =DAL.Properties.Settings.Default.DALConnectionString;
       /// <summary>
       /// 从指定的产品ID获取产品实体
       /// </summary>
       /// <param name="ID">产品ID编码</param>
       /// <returns>返回产品实体类</returns>
        public Product GetProduct(int ID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            String SqlStr="Select * from Products Where ProductID=@ProductID";
            SqlCommand cmd = new SqlCommand(SqlStr, con);
            cmd.Parameters.AddWithValue("@ProductID", ID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    // 创建一个产品对象来包装当前的记录
                    Product product = LoadProductFromReader(reader);
                    return product;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                con.Close();
            }
        }
       /// <summary>
       /// 辅助方法用于从DataReader中加载数据到数据实实体类中
       /// </summary>
       /// <param name="reader"></param>
       /// <returns></returns>
        protected Product LoadProductFromReader(DbDataReader reader)
        {
            //实体化产品对象
            Product product = new Product();
            if (reader != null && !reader.IsClosed)
            {
                //加载产品数据
                if (!reader.IsDBNull(reader.GetOrdinal("ProductID"))) 
                    product.ProductID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                if (!reader.IsDBNull(reader.GetOrdinal("ProductName"))) 
                    product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                if (!reader.IsDBNull(reader.GetOrdinal("SupplierID"))) 
                    product.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                if (!reader.IsDBNull(reader.GetOrdinal("CategoryID"))) 
                    product.CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID"));
                if (!reader.IsDBNull(reader.GetOrdinal("QuantityPerUnit"))) 
                    product.QuantityPerUnit = reader.GetString(reader.GetOrdinal("QuantityPerUnit"));
                if (!reader.IsDBNull(reader.GetOrdinal("UnitPrice"))) 
                    product.UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                if (!reader.IsDBNull(reader.GetOrdinal("UnitsInStock"))) 
                    product.UnitsInStock = reader.GetInt16(reader.GetOrdinal("UnitsInStock"));
                if (!reader.IsDBNull(reader.GetOrdinal("UnitsOnOrder"))) 
                    product.UnitsOnOrder = reader.GetInt16(reader.GetOrdinal("UnitsOnOrder"));
                if (!reader.IsDBNull(reader.GetOrdinal("ReorderLevel"))) 
                    product.ReorderLevel = reader.GetInt16(reader.GetOrdinal("ReorderLevel"));
                if (!reader.IsDBNull(reader.GetOrdinal("Discontinued"))) 
                    product.Discontinued = reader.GetBoolean(reader.GetOrdinal("Discontinued"));
            }
            return product;
        }
       /// <summary>
       /// 更新产品到数据库中
       /// </summary>
       /// <param name="product">产品对象</param>
        public void UpdateProduct(Product product)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string UpdateSQL = "Update Products SET ProductName=@ProductName,SupplierID=@SupplierID,"+
                "CategoryID=@CategoryID,QuantityPerUnit=@QuantityPerUnit,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,"+
                "UnitsOnOrder=@UnitsOnOrder,ReorderLevel=@ReorderLevel,Discontinued=@Discontinued "+
                "WHERE [ProductID]=@ProductID";
            SqlCommand cmd = new SqlCommand(UpdateSQL, con);
            //添加参数信息
            cmd.Parameters.AddWithValue("@ProductID",product.ProductID);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
            cmd.Parameters.AddWithValue("@SupplierID", product.SupplierID);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", product.QuantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", product.UnitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);
            cmd.Parameters.AddWithValue("@Discontinued", product.Discontinued);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Db Error!" + ex.Message);

            }            
            finally
            {
                con.Close();
            }
        }
    }
}
