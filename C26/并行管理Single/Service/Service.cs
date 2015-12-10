using System;
using System.ServiceModel;
using System.Threading;

namespace WCF.Fourth
{
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void Operate();
    }
    /// <summary>
    /// 设置并行管理，
    /// 为了验证并行管理，这里使用Single实例管理模式
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, 
                    ConcurrencyMode=ConcurrencyMode.Single)]
    public class Service : IService,IDisposable
    {
        public void Operate()
        {
            Console.WriteLine("进入操作");
            //延长操作执行时间
            Thread.Sleep(1000 * 3);
            Console.WriteLine("退出操作");
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose方法被调用");
        }
    }
}
