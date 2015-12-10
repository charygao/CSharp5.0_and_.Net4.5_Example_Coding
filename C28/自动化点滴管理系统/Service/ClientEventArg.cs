using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace WCF.CaseStudy
{
    /// <summary>
    /// 事件类型枚举
    /// </summary>
    public enum ClientEventType
    {
        //默认值是0
        None,
        //丢失心跳
        MissHeartBeat,
        //心跳事件
        HeartBeat,
        //呼叫服务
        EmergentCall,
        //结束服务呼叫
        EndEmergentCall,
        //开始注射
        StartMainline,
        //结束注射
        EndMainline
    }
    /// <summary>
    /// 事件参数
    /// </summary>
    public class ClientEventArg:EventArgs
    {
        //床号
        private int _bedNo;
        //事件类型
        private ClientEventType _eventType;
        //病人状态，可为null
        private PatientStatus _patientstatus;
        public ClientEventArg(int benNo, ClientEventType eventType, PatientStatus status)
        {
            _bedNo = benNo;
            _eventType = eventType;
            _patientstatus = status;
        }
        public int BedNo
        {
            get
            {
                return _bedNo;
            }
        }
        public ClientEventType ClientEventType
        {
            get
            {
                return _eventType;
            }
        }
        public PatientStatus PatientStatus
        {
            get
            {
                return _patientstatus;
            }
        }
    }
}
