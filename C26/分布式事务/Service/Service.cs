using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Transactions;
namespace WCF.Fourth
{
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IService
    {
        //修改帐号操作
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void Add(double amount);
        //验证操作
        [OperationContract]
        void Assert(BankAccount A);
    }
    /// <summary>
    /// 设置实例管理
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class Service : IService 
    {
        private BankAccount B;
        public Service()
        {
            Console.WriteLine("服务实例被构造");
            B = new BankAccount("B", 200);
        }
        /// <summary>
        /// 这里检验两个帐号的金额是否保持一致性
        /// </summary>
        public void Assert(BankAccount A)
        {
            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine("A和B帐户的和为{0}", A.Amount + B.Amount);
        }
        /// <summary>
        /// 使用事务
        /// </summary>
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete=true)]
        public void Add(double amount)
        {
            //注册B为易失型事务操作
            Transaction.Current.EnlistVolatile(B, EnlistmentOptions.None);
            Console.WriteLine("当前事务：{0}", Transaction.Current.TransactionInformation.DistributedIdentifier);
            B.Add(amount);
        }
    }
    /// <summary>
    /// 帐号类型，这是一个易失型事务资源
    /// </summary>
    [DataContract]
    public class BankAccount : IEnlistmentNotification 
    {
        [DataMember]
        public String Name;
        [DataMember]
        public double Amount;
        private double _newAmount;
        public BankAccount(String name, double amount)
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
