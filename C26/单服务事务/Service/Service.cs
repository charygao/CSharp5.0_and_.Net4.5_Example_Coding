using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Transactions;
namespace WCF.Fourth
{
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void SuccessOperation();
        [OperationContract]
        void FailOperation();
        [OperationContract]
        void Assert();
    }
    /// <summary>
    /// 设置实例管理
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class Service : IService 
    {
        private BackAccount A;
        private BackAccount B;
        public Service()
        {
            Console.WriteLine("服务实例被构造");
            A = new BackAccount("A", 100);
            B = new BackAccount("B", 200);
        }
        /// <summary>
        /// 这里检验两个帐号的金额是否保持一致性
        /// </summary>
        public void Assert()
        {
            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine("A和B帐户的和为{0}", A.Amount + B.Amount);
        }
        /// <summary>
        /// 使用事务
        /// </summary>
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SuccessOperation()
        {
            //注册A和B为易失型事务操作
            Transaction.Current.EnlistVolatile(A, EnlistmentOptions.None);
            Transaction.Current.EnlistVolatile(B, EnlistmentOptions.None);
            A.Add(-50);
            B.Add(50);
        }
        /// <summary>
        /// 使用事务
        /// </summary>
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void FailOperation()
        {
            //注册A和B为易失型事务操作
            Transaction.Current.EnlistVolatile(A, EnlistmentOptions.None);
            Transaction.Current.EnlistVolatile(B, EnlistmentOptions.None);
            A.Add(-50);
            //这里模拟产生异常
            throw new FaultException();
            B.Add(50);
        }
    }
    /// <summary>
    /// 帐号类型，这是一个易失型事务资源
    /// </summary>
    [DataContract]
    public class BackAccount : IEnlistmentNotification 
    {
        [DataMember]
        public String Name;
        [DataMember]
        public double Amount;
        private double _newAmount;
        public BackAccount(String name, double amount)
        {
            Name = name;
            Amount = amount;
        }
        public override string ToString()
        {
            return Name + "的账户：" + Amount.ToString();
        }
        public void Adjust(double newAmount)
        {
            _newAmount = newAmount;
        }
        public void Add(double amount)
        {
            double newAmount = Amount + amount;
            Adjust(newAmount);
        }
        /// <summary>
        /// 提交操作
        /// </summary>
        public void Commit(Enlistment enlistment)
        {
            Amount = _newAmount;
            enlistment.Done();
            Console.WriteLine("{0}已提交", Name);
        }
        public void InDoubt(Enlistment enlistment)
        {
            throw new Exception();
        }
        public void Prepare(PreparingEnlistment enlistment)
        {
            enlistment.Prepared();
        }
        /// <summary>
        /// 回滚操作
        /// </summary>
        public void Rollback(Enlistment enlistment)
        {
            enlistment.Done();
            Console.WriteLine("{0}已回滚", Name);
        }
    }
}
