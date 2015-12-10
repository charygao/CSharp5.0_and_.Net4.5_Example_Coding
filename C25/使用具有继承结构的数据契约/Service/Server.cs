using System;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace WCF.Third
{
    /// <summary>
    /// 基类
    /// </summary>
    [DataContract]
    public class BaseClass
    {
        [DataMember]
        public String Name;
        [DataMember]
        public int Age;
    }
    /// <summary>
    /// 子类
    /// </summary>
    [DataContract]
    public class SonClass:BaseClass
    {
        [DataMember]
        public String Description;
    }
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void DoSomeWork(SonClass obj);
    }
    /// <summary>
    /// 实现服务契约
    /// </summary>
    public class Service:IService
    {
        public void DoSomeWork(SonClass obj)
        {
            Console.WriteLine("姓名是：{0}", obj.Name);
            Console.WriteLine("年龄是：{0}", obj.Age.ToString());
            Console.WriteLine("备注是：{0}", obj.Description);
        }
    }
}
