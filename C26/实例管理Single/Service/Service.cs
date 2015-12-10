using System;
using System.ServiceModel;

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
    /// 设置实例管理
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class Service : IService,IDisposable
    {
        public int _count = 0;
        public void Operate()
        {
            //由于是Single，_count的值会持续累加
            _count++;
            Console.WriteLine("Count的值为{0}",_count);
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose方法被调用");
        }
    }
}
