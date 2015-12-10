using System;
using System.Collections.Generic;
using System.Threading;
namespace WCF.CaseStudy
{
    /// <summary>
    /// 心跳管理类型
    /// </summary>
    public class HeartBeatManager
    {
        //心跳记录
        private Dictionary<int, DateTime> _hbRecord = new Dictionary<int, DateTime>();
        //丢失心跳事件
        private event EventHandler<ClientEventArg> _missingHBHandlers;
        //心跳事件
        private event EventHandler<ClientEventArg> _hbHandlers;
        //检查心跳的定时器
        private Timer _timer;
        //2秒检查一次心跳
        private static readonly long _checkInterval = 2*1000;
        //15秒得不到心跳消息则视为心跳丢失
        public static readonly TimeSpan HBTimeout = TimeSpan.FromSeconds(15);
        /// <summary>
        /// 构造方法
        /// </summary>
        public HeartBeatManager()
        {
            _timer = new Timer(new TimerCallback(CheckHeartBeat), null, 0, _checkInterval);
        }
        /// <summary>
        /// 订阅丢失心跳事件
        /// </summary>
        /// <param name="handler">事件处理方法</param>
        public void AddMissingHBHandler(EventHandler<ClientEventArg> handler)
        {
            if (_missingHBHandlers == null)
                _missingHBHandlers = new EventHandler<ClientEventArg>(handler);
            else
                _missingHBHandlers += handler;
        }
        /// <summary>
        /// 订阅心跳事件
        /// </summary>
        /// <param name="handler">事件处理方法</param>
        public void AddHBHandler(EventHandler<ClientEventArg> handler)
        {
            if (_hbHandlers == null)
                _hbHandlers = new EventHandler<ClientEventArg>(handler);
            else
                _hbHandlers += handler;
        }
        /// <summary>
        /// 检查心跳
        /// </summary>
        private void CheckHeartBeat(object sender)
        {
            foreach (int bedno in _hbRecord.Keys)
            {
                DateTime time = _hbRecord[bedno];
                if (DateTime.Now.Subtract(time) > HBTimeout &&
                    _missingHBHandlers != null)
                {
                    //这里出发丢失心跳事件
                    ClientEventArg arg = new ClientEventArg(bedno, ClientEventType.MissHeartBeat, null);
                    _missingHBHandlers(this, arg);
                }
            }
        }
        /// <summary>
        /// 触发心跳事件
        /// </summary>
        /// <param name="bedNo">床号</param>
        /// <param name="time">心跳时间</param>
        /// <param name="status">客户端状态</param>
        public void HeartBeat(int bedNo, DateTime time, PatientStatus status)
        {
            _hbRecord[bedNo] = time;
            if (_hbHandlers != null)
            {
                ClientEventArg arg = new ClientEventArg(bedNo, ClientEventType.HeartBeat, status);
                _hbHandlers(this, arg);
            }
        }
    }
}
