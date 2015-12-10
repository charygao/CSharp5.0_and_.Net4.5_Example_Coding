using System;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace WCF.Third
{
    /// <summary>
    /// 服务B的数据契约定义
    /// </summary>
    [DataContract]
    public class Data
    {
        [DataMember]
        public String A;
        [DataMember]
        public String B;
        [DataMember]
        public int C;
    }
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void CollectData(Data data);
    }
    /// <summary>
    /// 服务的实现
    /// </summary>
    public class Service : IService
    {
        public void CollectData(Data data)
        {
            Console.WriteLine("A is {0}:", data.A);
            Console.WriteLine("B is {0}:", data.B == null ? "null" : data.B);
            Console.WriteLine("C is {0}:", data.C);
        }
    }
}
