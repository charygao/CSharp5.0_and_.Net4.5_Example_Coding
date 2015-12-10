using System;
using System.ServiceModel;
namespace WCF.Fourth
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void Operate();
    }
    /// <summary>
    /// 设置实例管理
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class Service : IService,IDisposable
    {
        private int _count = 0;
        public void Operate()
        {
            //由于是PerCall，_count的值不会被保存
            _count++;
            Console.WriteLine("Count的值为{0}",_count);
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose方法被调用");
        }
    }
}
