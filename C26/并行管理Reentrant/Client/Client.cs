using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Threading;
using System.ServiceModel.Channels;
namespace WCF.Fourth
{
    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                using (ClientProxy proxy = new ClientProxy(new InstanceContext(new CallbackClient()),
                            new NetNamedPipeBinding(),
                            new EndpointAddress("net.pipe://localhost/Service")))
                {
                    //多次异步访问服务操作
                    proxy.BeginOperate(CallbackOperation, null);
                    proxy.BeginOperate(CallbackOperation, null);
                    proxy.BeginOperate(CallbackOperation, null);
                    Console.Read();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
        }
        /// <summary>
        /// 异步操作返回执行的方法
        /// </summary>
        static void CallbackOperation(IAsyncResult ar)
        {
            ar.AsyncWaitHandle.Close();
            Console.WriteLine("操作返回");
        }
    }
    /// <summary>
    /// 回调契约的实现
    /// </summary>
    class CallbackClient : ICallback
    {
        public void Callback()
        {
            Console.WriteLine("{0}进入回调方法",DateTime.Now.ToString());
            Thread.Sleep(1000 * 3);
            Console.WriteLine("{0}退出回调方法", DateTime.Now.ToString());
        }
    }
    /// <summary>
    /// 回调契约
    /// </summary>
    public interface ICallback
    {
        [OperationContract]
        void Callback();
    }
    /// <summary>
    /// 服务契约，添加了异步操作方法
    /// </summary>
    [ServiceContractAttribute(CallbackContract = typeof(ICallback))]
    public interface IService
    {
        [OperationContractAttribute]
        void Operate();
        [OperationContractAttribute(AsyncPattern = true)]
        System.IAsyncResult BeginOperate(System.AsyncCallback callback, object asyncState);
        void EndOperate(System.IAsyncResult result);
    }
    /// <summary>
    /// 客户端代理的实现
    /// </summary>
    public class ClientProxy : DuplexClientBase<IService>, IService
    {
        public ClientProxy(InstanceContext context, Binding binding, EndpointAddress remoteAddress) :
            base(context, binding, remoteAddress) { }
        public void Operate()
        {
            Channel.Operate();
        }
        public System.IAsyncResult BeginOperate(System.AsyncCallback callback, object asyncState)
        {
            return base.Channel.BeginOperate(callback, asyncState);
        }
        public void EndOperate(System.IAsyncResult result)
        {
            base.Channel.EndOperate(result);
        }
    }
}
