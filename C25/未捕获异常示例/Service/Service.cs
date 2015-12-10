using System;
using System.ServiceModel;
namespace WCF.Third
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void ThrowException();
    }
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service : IService
    {
        /// <summary>
        /// 抛出异常
        /// </summary>
        public void ThrowException()
        {
            throw new NullReferenceException("测试异常");
        }
    }
}
