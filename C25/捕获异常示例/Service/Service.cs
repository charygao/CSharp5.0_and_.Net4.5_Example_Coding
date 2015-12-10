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
            try
            {
                //根据type的值抛出不同类型的异常
                switch (type)
                {
                    case "Null":
                        {
                            throw new NullReferenceException("测试空引用异常");
                            break;
                        }
                    case "Normal":
                        {
                            throw new Exception("测试普通异常");
                            break;
                        }
                }
            }
            catch (NullReferenceException ex)
            {
                //重新抛出FaultException
                throw new FaultException(ex.Message);
            }
            catch (Exception ex)
            {
                //重新抛出FaultException
                throw new FaultException(ex.Message);
            }

        }
    }
}
