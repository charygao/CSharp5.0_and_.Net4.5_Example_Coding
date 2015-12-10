using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
namespace WCF.Third
{
    /// <summary>
    /// 入口方法
    /// </summary>
    public class MainClass
    {
        static void Main(string[] args)
        {
            using (Proxy proxy = new Proxy(new WSHttpBinding(), new EndpointAddress("http://localhost:8675/Service")))
            {
                Data data = new Data();
                data.A = "StringA";
                proxy.CollectData(data);
            }
            Console.Read();
        }
    }

    /// <summary>
    /// 服务B的数据契约定义
    /// 相对于服务B来说，缺失了B和C的定义
    /// </summary>
    [DataContract]
    public class Data
    {
        [DataMember]
        public String A;
    }
    /// <summary>
    /// 代理类型
    /// </summary>
    public class Proxy : ClientBase<IService>, IService
    {
        public Proxy(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }
        public void CollectData(Data data)
        {
            Channel.CollectData(data);
        }
    }
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void CollectData(Data data);
    }
}
