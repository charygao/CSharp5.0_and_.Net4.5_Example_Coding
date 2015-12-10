using System;
using System.ServiceModel;
using System.Threading;
using System.ServiceModel.Channels;
namespace WCF.Third
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                //得到回调实例
                Client client = new Client();
                //创建代理
                using (HeartbeatProxy proxy = new HeartbeatProxy(new InstanceContext(client), 
                    new NetNamedPipeBinding(), 
                    new EndpointAddress("net.pipe://localhost/HeartbeatService")))
                {
                    //循环发送心跳
                    while(true)
                    {
                        proxy.Heartbeat();
                        Thread.Sleep(client.Interval);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.Read();
            }
        }
    }
    /// <summary>
    /// 回调契约的实现
    /// </summary>
    public class Client:IHeartbeatCallback
    {
        private TimeSpan _interval = TimeSpan.FromSeconds(2);
        public TimeSpan Interval
        {
            get
            {
                return _interval;
            }
        }
        //更新心跳频率
        public void UpdateInterval(int seconds)
        {
            lock (this)
            {
                _interval = TimeSpan.FromSeconds(seconds);
            }
        }
    }
    /// <summary>
    /// 回调契约
    /// </summary>
    public interface IHeartbeatCallback
    {
        [OperationContract(IsOneWay=true)]
        void UpdateInterval(int seconds);
    }
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IHeartbeatCallback))]
    public interface IHeartbeatService
    {
        [OperationContract]
        void Heartbeat();
    }
    /// <summary>
    /// 客户端代理的实现
    /// </summary>
    public class HeartbeatProxy : DuplexClientBase<IHeartbeatService>, IHeartbeatService
    {
        public HeartbeatProxy(InstanceContext context, Binding binding, EndpointAddress remoteAddress) :
            base(context, binding, remoteAddress) { }
        public void Heartbeat()
        {
            Channel.Heartbeat();
        }
    }
}
