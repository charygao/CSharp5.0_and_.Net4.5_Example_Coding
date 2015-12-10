using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace WCF.Third
{
    class Client
    {
        /// <summary>
        /// 入口方法
        /// </summary>
        static void Main(string[] args)
        {
            using (ClientProxy proxy = new ClientProxy())
            {
                Console.WriteLine("{0} 开始调用请求响应操作。", 
                                    DateTime.Now.ToLongTimeString());
                proxy.RequestReply();
                Console.WriteLine("{0} 结束调用请求响操作。", 
                                    DateTime.Now.ToLongTimeString());
                Console.WriteLine("{0} 开始调用单程操作。", 
                                    DateTime.Now.ToLongTimeString());
                proxy.OneWay();
                Console.WriteLine("{0} 结束调用单程操作。", 
                                    DateTime.Now.ToLongTimeString());
            }
            Console.Read();
        }
    }
    [ServiceContract]
    public interface IService
    {
        //单程操作
        [OperationContract(IsOneWay = true)]
        void OneWay();
        //请求响应操作
        [OperationContract]
        void RequestReply();
    }
    /// <summary>
    /// 客户端代理类型
    /// </summary>
    class ClientProxy : ClientBase<IService>, IService
    {
        //硬编码定义绑定
        public static readonly Binding HelloWorldBinding = new WSHttpBinding();
        //硬编码定义地址
        public static readonly EndpointAddress HelloWorldAddress = new EndpointAddress(new Uri("http://localhost:8675/Service"));
        /// <summary>
        /// 构造方法
        /// </summary>
        public ClientProxy() : base(HelloWorldBinding, HelloWorldAddress) { }
        public void OneWay()
        {
            Channel.OneWay();
        }
        public void RequestReply()
        {
            Channel.RequestReply();
        }
    }
}
