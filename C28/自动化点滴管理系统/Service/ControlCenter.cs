using System;
using System.Collections.Generic;
using System.ServiceModel;
namespace WCF.CaseStudy
{
    /// <summary>
    /// 服务的实现
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single,
        ConcurrencyMode=ConcurrencyMode.Multiple)]
    public sealed class ControlCenter:IControlCenter
    {
        //呼叫事件
        private event EventHandler<ClientEventArg> _emergentCallHandler;
        //结束呼叫事件
        private event EventHandler<ClientEventArg> _endemergentCallHandler;
        //开始注射事件
        private event EventHandler<ClientEventArg> _startMainlineHandler;
        //结束注射事件
        private event EventHandler<ClientEventArg> _endMainlineHandler;
        //存储所有客户端的回调引用
        private Dictionary<int, IInjector> _callbackList = new Dictionary<int, IInjector>();
        //心跳管理对象
        private HeartBeatManager _hbManager=new HeartBeatManager();
        /// <summary>
        /// 定阅事件
        /// </summary>
        /// <param name="type">事件类型</param>
        /// <param name="handler">事件处理方法</param>
        public void AddClientEventHandler(ClientEventType type, EventHandler<ClientEventArg> handler)
        {
            switch (type)
            {
                case ClientEventType.EmergentCall:
                    {
                        if (_emergentCallHandler == null)
                            _emergentCallHandler = new EventHandler<ClientEventArg>(handler);
                        else
                            _emergentCallHandler += handler;
                        break;
                    }
                case ClientEventType.EndEmergentCall:
                    {
                        if (_endemergentCallHandler == null)
                            _endemergentCallHandler = new EventHandler<ClientEventArg>(handler);
                        else
                            _endemergentCallHandler += handler;
                        break;
                    }
                case ClientEventType.EndMainline:
                    {
                        if (_endMainlineHandler == null)
                            _endMainlineHandler = new EventHandler<ClientEventArg>(handler);
                        else
                            _endMainlineHandler += handler;
                        break;
                    }
                case ClientEventType.MissHeartBeat:
                    {
                        _hbManager.AddMissingHBHandler(handler);
                        break;
                    }
                case ClientEventType.HeartBeat:
                    {
                        _hbManager.AddHBHandler(handler);
                        break;
                    }
                case ClientEventType.StartMainline:
                    {
                        if (_startMainlineHandler == null)
                            _startMainlineHandler = new EventHandler<ClientEventArg>(handler);
                        else
                            _startMainlineHandler += handler;
                        break;
                    }
            }
        }
        /// <summary>
        /// 开始注射操作
        /// </summary>
        /// <param name="patient">病人</param>
        /// <param name="bedNo">床号</param>
        /// <returns>返回是否执行成功</returns>
        public bool StartMainline(Patient patient, int bedNo)
        {
            try
            {
                if (_startMainlineHandler != null)
                {
                    ClientEventArg arg = new ClientEventArg(bedNo, ClientEventType.StartMainline, new PatientStatus(patient, null, 0, 0));
                    _startMainlineHandler(this, arg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        /// <summary>
        /// 结束注射操作
        /// </summary>
        /// <param name="patient">病人</param>
        /// <param name="bedNo">床号</param>
        /// <returns>返回是否执行成功</returns>
        public bool EndMainline(Patient patient, int bedNo)
        {
            try
            {
                if (_endMainlineHandler != null)
                {
                    ClientEventArg arg = new ClientEventArg(bedNo, ClientEventType.StartMainline, new PatientStatus(patient, null, 0, 0));
                    _endMainlineHandler(this, arg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        /// <summary>
        /// 心跳操作
        /// </summary>
        /// <param name="bedNo">床号</param>
        /// <param name="status">状态</param>
        public void HeartBeat(int bedNo, PatientStatus status)
        {
            _hbManager.HeartBeat(bedNo, DateTime.Now, status);
            IInjector injector = OperationContext.Current.GetCallbackChannel<IInjector>();
            _callbackList[bedNo] = injector;
        }
        /// <summary>
        /// 呼叫服务操作
        /// </summary>
        /// <param name="bedNo">床号</param>
        public bool EmergentCall(int bedNo)
        {
            try
            {
                if (_emergentCallHandler != null)
                {
                    ClientEventArg arg = new ClientEventArg(bedNo, ClientEventType.EmergentCall, null);
                    _emergentCallHandler(this, arg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        /// <summary>
        /// 结束呼叫服务操作
        /// </summary>
        /// <param name="bedNo">床号</param>
        public bool EndEmergentCall(int bedNo)
        {
            try
            {
                if (_endemergentCallHandler != null)
                {
                    ClientEventArg arg = new ClientEventArg(bedNo, ClientEventType.EndEmergentCall, null);
                    _endemergentCallHandler(this, arg);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.ToString());
            }
        }
        /// <summary>
        /// 这里返回了引用，所以_callbackList是不安全的
        /// </summary>
        public Dictionary<int, IInjector> CallbackList
        {
            get
            {
                return _callbackList;
            }
        }
    }
}
