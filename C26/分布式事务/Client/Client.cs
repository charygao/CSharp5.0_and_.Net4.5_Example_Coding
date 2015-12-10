using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Transactions;
using System.ServiceModel.Channels;
namespace WCF.Fourth
{
    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                TransactionInit init = new TransactionInit();
                //访问服务操作，并且查看账户是否一致
                using (ServiceClient proxy = new ServiceClient())
                {
                    init.TestCommitTransaction(proxy);
                    proxy.Assert(init.A);
                    init.TestRoolbackTransaction(proxy);
                    proxy.Assert(init.A);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }
    }
    /// <summary>
    /// 事务测试类型
    /// </summary>
    public class TransactionInit
    {
        public BankAccount A = new BankAccount("A", 100);
        /// <summary>
        /// 事务成功提交
        /// </summary>
        public void TestCommitTransaction(ServiceClient proxy)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                Transaction.Current.EnlistVolatile(A, EnlistmentOptions.None);
                Console.WriteLine("当前事务：{0}", Transaction.Current.TransactionInformation.LocalIdentifier);
                proxy.Add(-50);
                A.Add(50);
                ts.Complete();
            }
        }
        /// <summary>
        /// 事务回滚
        /// </summary>
        public void TestRoolbackTransaction(ServiceClient proxy)
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                Transaction.Current.EnlistVolatile(A, EnlistmentOptions.None);
                Console.WriteLine("当前事务：{0}", Transaction.Current.TransactionInformation.LocalIdentifier);
                proxy.Add(-50);
                //这里模拟产生异常而没有调用Complete，所有事务将回滚
            }
        }
    }
}
