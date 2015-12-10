using System;
using System.ServiceModel;
using System.Threading;
namespace WCF.Third
{
    [ServiceContract]
    public interface IService
    {
        //单程操作
        [OperationContract(IsOneWay=true)]
        void OneWay();
        //请求响应操作
        [OperationContract]
        void RequestReply();
    }
    /// <summary>
    /// 服务契约的实现
    /// </summary>
    public class Service : IService
    {
        public void OneWay()
        {
            //阻止当前线程10秒
            Thread.Sleep(10 * 1000);
        }
        public void RequestReply()
        {
            //阻止当前线程10秒
            Thread.Sleep(10 * 1000);
        }
    }
}
