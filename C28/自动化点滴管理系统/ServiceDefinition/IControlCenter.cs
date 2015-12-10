using System.ServiceModel;
namespace WCF.CaseStudy
{
    [ServiceContract(CallbackContract = typeof(IInjector))]
    public interface IControlCenter
    {
        /// <summary>
        /// 开始注射
        /// </summary>
        /// <param name="patient">病人</param>
        /// <param name="bedNo">床号</param>
        /// <returns>返回是否注册成功</returns>
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        bool StartMainline(Patient patient, int bedNo);
        /// <summary>
        /// 结束注射
        /// </summary>
        /// <param name="patient">病人</param>
        /// <param name="bedNo">床号</param>
        /// <returns>返回是否操作成功</returns>
        [OperationContract]
        bool EndMainline(Patient patient, int bedNo);
        /// <summary>
        /// 心跳，并且告知控制中心药水剩余比例
        /// </summary>
        /// <param name="bedNo">床号</param>
        /// <param name="remain">每秒毫升</param>
        [OperationContract]
        void HeartBeat(int bedNo,PatientStatus status);
        /// <summary>
        /// 病人发出护理请求
        /// </summary>
        /// <param name="bedNo">床号</param>
        [OperationContract]
        bool EmergentCall(int bedNo);
        /// <summary>
        /// 结束护理请求
        /// </summary>
        /// <param name="bedNo">床号</param>
        [OperationContract]
        bool EndEmergentCall(int bedNo);
    }
    public interface IInjector
    {
        /// <summary>
        /// 调整注射速率
        /// </summary>
        /// <param name="bedNo">床号</param>
        /// <param name="amountPerSecond">每秒毫升数</param>
        [OperationContract(IsOneWay=true)]
        void AdjustRate(long amountPerSecond);
    }
}
