using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace WCF.Third
{
    /// <summary>
    /// 回调契约
    /// </summary>
    public interface IHeartbeatCallback
    {
        /// <summary>
        /// 回调操作，调整心跳频率
        /// </summary>
        /// <param name="seconds">新的频率</param>
        [OperationContract(IsOneWay=true)]
        void UpdateInterval(int seconds);
    }
    /// <summary>
    /// 心跳服务契约
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IHeartbeatCallback))]
    public interface IHeartbeatService
    {
        [OperationContract]
        void Heartbeat();
    }
    /// <summary>
    /// 契约实现
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class HeartbeatService : IHeartbeatService
    {
        //是否处于高负荷状态
        private bool _highLoad = false;
        //状态是否已经改变
        private bool _changed = false;
        //不同负荷下的心跳周期
        private int _highloadInterval = 5;
        private int _lowloadInterval = 2;
        //设置负荷状态
        public bool HighLoad
        {
            set
            {
                lock (this)
                {
                    if (_highLoad != value)
                    {
                        _changed = true;
                        _highLoad = value;
                        Console.WriteLine("Highload 已经被设置为：{0}", value);
                    }
                }
            }
        }
        //实现心跳契约
        public void Heartbeat()
        {
            //如何符合已经更改，则回调客户端，更新心跳频率
            if (_changed)
            {
                IHeartbeatCallback callback = OperationContext.Current.GetCallbackChannel<IHeartbeatCallback>();
                callback.UpdateInterval(_highLoad ? _highloadInterval : _lowloadInterval);
            }
            Console.WriteLine("{0} 收到心跳。",DateTime.Now.ToString());
        }
    }
}
