using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections;
namespace WCF.Third
{
    /// <summary>
    /// 定义服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        ResponseMessage PrintLog(LogMessage log);
    }
    /// <summary>
    /// 服务契约的实现
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// 打印所有的log
        /// </summary>
        public ResponseMessage PrintLog(LogMessage log)
        {
            try
            {
                Console.WriteLine("{0} {1}：{2}", log.bodyInfo.Time.ToString(),
                                   log.bodyInfo.Type, log.bodyInfo.Content);
                return new ResponseMessage(ResponseCode.Success, "打印完毕");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ResponseMessage(ResponseCode.Fail, ex.ToString());
            }
        }
    }
}

