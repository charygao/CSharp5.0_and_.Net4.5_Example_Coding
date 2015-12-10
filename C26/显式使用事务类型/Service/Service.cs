using System;
using System.ServiceModel;
using System.Data;
using System.Data.SqlClient;
namespace WCF.Fourth
{
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void Operate();
    }
    /// <summary>
    /// 服务契约实现
    /// </summary>
    public class Service : IService
    {
        public void Operate()
        {
            IDbConnection connection;
            IDbTransaction transaction;
            String conString = "....."; //演示起见，省略连接字符串
            try
            {
                connection = new SqlConnection(conString);
                //这里开始事务
                transaction = connection.BeginTransaction();
                //这里省略和数据库有关的操作
                //。。。。
                //。。。。
                //事务成功执行，这里提交事务
                transaction.Commit();
            }
            catch
            {
                //事务执行失败，进行回滚
                if (transaction != null)
                    transaction.Rollback();
            }
            finally
            {
                //执行释放
                if (connection != null)
                    connection.Dispose();
                if (transaction != null)
                    transaction.Dispose();
            }
        }
    }
}
