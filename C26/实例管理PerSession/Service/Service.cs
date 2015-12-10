using System;
using System.ServiceModel;
namespace WCF.Fourth
{
    /// <summary>
    /// 服务契约，定义SessionMode为Allowed
    /// </summary>
    [ServiceContract(SessionMode=SessionMode.Allowed)]
    public interface IService
    {
        [OperationContract]
        void Operate();
    }
    /// <summary>
    /// 设置实例管理
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class Service : IService,IDisposable
    {
        private int _count = 0;
        public void Operate()
        {
            //由于是PerSession，_count的值会累加
            _count++;
            Console.WriteLine("Count的值为{0}",_count);
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose方法被调用");
        }
    }
}
