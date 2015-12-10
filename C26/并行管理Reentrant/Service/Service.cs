using System;
using System.ServiceModel;
using System.Threading;
namespace WCF.Fourth
{
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IService
    {
        [OperationContract]
        void Operate();
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
    /// 设置并行管理为Reentrant
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, 
                    ConcurrencyMode=ConcurrencyMode.Reentrant)]
    public class Service : IService,IDisposable
    {
        public void Operate()
        {
            Console.WriteLine("{0}进入操作", DateTime.Now.ToString());
            //这里进行回调，WCF会释放同步锁
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            callback.Callback();
            Console.WriteLine("{0}退出操作", DateTime.Now.ToString());
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose方法被调用");
        }
    }
}
