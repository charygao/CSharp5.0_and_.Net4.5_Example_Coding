using System;
using System.ServiceModel;
namespace WCF.Third
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void ThrowException(String type);
    }
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service : IService
    {
        /// <summary>
        /// 抛出异常
        /// </summary>
        public void ThrowException(String type)
        {
            //根据type的值抛出不同类型的异常
            switch (type)
            {
                case "Null":
                    {
                        //设置FaultCode和FaultReason
                        FaultCode faultCode = FaultCode.CreateSenderFaultCode(new FaultCode("空引用"));
                        FaultReasonText[] reasons = new FaultReasonText[2]{
                                                new FaultReasonText("NullReferenceException"),
                                                new FaultReasonText("测试空引用异常")};
                        throw new FaultException(new FaultReason(reasons), faultCode);
                        break;
                    }
                case "Normal":
                    {
                        //设置FaultCode和FaultReason
                        FaultCode faultCode = FaultCode.CreateReceiverFaultCode(new FaultCode("普通异常"));
                        FaultReasonText[] reasons = new FaultReasonText[2]{
                                                new FaultReasonText("Exception"),
                                                new FaultReasonText("测试普通异常")};
                        throw new FaultException(new FaultReason(reasons), faultCode);
                        break;
                    }
            }
        }
    }
}
