using System;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace WCF.Third
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [FaultContract(typeof(NullReferenceException))]
        [FaultContract(typeof(Exception))]
        [FaultContract(typeof(MyException))]
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
                        //生成FaultException<NullReferenceException>
                        throw new FaultException<NullReferenceException>(new NullReferenceException("测试空引用异常"),
                                                                         new FaultReason(reasons),
                                                                         faultCode);
                    }
                case "Normal":
                    {
                        //设置FaultCode和FaultReason
                        FaultCode faultCode = FaultCode.CreateReceiverFaultCode(new FaultCode("普通异常"));
                        FaultReasonText[] reasons = new FaultReasonText[2]{
                                                new FaultReasonText("Exception"),
                                                new FaultReasonText("测试普通异常")};
                        //生成FaultException<Exception>
                        throw new FaultException<Exception>(new Exception("测试普通异常"),
                                                            new FaultReason(reasons), 
                                                            faultCode);
                    }
                case "Customized":
                    {
                        String message = "自定义异常";
                        throw new FaultException<MyException>(new MyException(message));
                    }
            }
        }
    }
    /// <summary>
    /// 作为FaultException<T>的实参，所以使用了DataContract和DataMember
    /// </summary>
    [DataContract]
    public class MyException
    {
        [DataMember]
        public String Message;
        public MyException(String message)
        {
            Message = message;
        }
    }
}
