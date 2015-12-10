using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;

namespace WCF.CaseStudy
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class InjectorConsole : Form, IInjector
    {
        //客户端状态机
        private ClientState _state;
        //床号
        private int _bedNo;
        //服务代理
        private ServiceProxy _proxy;
        //锁对象，程序使用
        private object lockobj = new object();
        //病人成员
        private Patient _patient;
        //药物成员
        private Medication _medication;
        //每秒注射的毫升数
        private long _injectingRate; 
        //默认注射60秒
        private static readonly TimeSpan _defaultSpan = TimeSpan.FromSeconds(60);
        //最近一次的药物量更新
        private DateTime _lastUpdate;
        //剩余的药物
        private long _remainAmount;
        //注射显示的背景色
        private static readonly Color InjectorBackcolor = Color.White;
        //非注射时背景色
        private static readonly Color InjectorSwithedOff = Color.Gray;
        //更新注射显示的定时器
        private System.Threading.Timer _injecttimer;
        //更新注射显示的周期
        private static readonly long interval = 300;
        //更新注射显示所使用的委托
        private delegate void DrawInjectorDelegate(int height);
        //呼叫闪烁定时器
        private System.Threading.Timer _calltimer;
        //闪烁周期
        private static readonly long _callinterval = 500;
        //闪烁使用的委托
        private delegate void CallDelegate();
        //闪烁亮色
        private static readonly Color CallingColor = Color.Red;
        //闪烁暗色
        private static readonly Color CallingColorBack = Color.FromArgb(255, 236, 233, 216);
        /// <summary>
        /// 构造方法
        /// </summary>
        public InjectorConsole()
        {
            InitializeComponent();
            String bedNoValue = ConfigurationManager.AppSettings["bedNo"];
            if (!Int32.TryParse(bedNoValue, out _bedNo))
            {
                throw new ConfigurationErrorsException("床号配置错误！");
            }
            BEDTITILE.Text = _bedNo.ToString() + "床";

            _injecttimer = new System.Threading.Timer(
                                    new TimerCallback(Inject), null, 
                                    System.Threading.Timeout.Infinite, 
                                    System.Threading.Timeout.Infinite);
            _calltimer = new System.Threading.Timer(
                                    new TimerCallback(CallTimerHandler), null,
                                    System.Threading.Timeout.Infinite,
                                    System.Threading.Timeout.Infinite);
            _state = ClientState.On;
        }
        private void SWITCH_Click(object sender, EventArgs e)
        {
            lock (lockobj)
            {
                //如果处于未注射状态，则执行启动注射
                if (_state == ClientState.On)
                {
                    //检查表单的输入
                    String patientId = PATIENTID.Text.Trim();
                    if (!Patient.CheckPatientID(patientId))
                    {
                        ShowMessage("错误的病人ID！");
                        return;
                    }
                    String docId = DOCTORID.Text.Trim();
                    if (!Doctor.CheckDocID(docId))
                    {
                        ShowMessage("错误的医生ID！");
                        return;
                    }
                    String nurseId = NURSEID.Text.Trim();
                    if (!Nurse.CheckNurseID(nurseId))
                    {
                        ShowMessage("错误的护士ID！");
                        return;
                    }
                    String medId = MEDICATIONID.Text.Trim();
                    String amount = MEDAMOUNT.Text.Trim();
                    long medAmount = 0;
                    if (!Medication.CheckID(medId))
                    {
                        ShowMessage("错误的药物ID！");
                        return;
                    }
                    if (!long.TryParse(amount, out medAmount))
                    {
                        ShowMessage("错误的药物总量！");
                        return;
                    }
                    _medication = new Medication(medId, medAmount);
                    if (_proxy == null ||
                        _proxy.State != CommunicationState.Opened)
                    {
                        ShowMessage("代理已关闭！");
                        return;
                    }
                    Doctor doc = new Doctor(docId);
                    //构造病人类型
                    _patient = new Patient(patientId, doc);
                    //调用服务操作，开始注射
                    if (_proxy.StartMainline(_patient, _bedNo))
                    {
                        //使用默认注射时间计算注射速率
                        _injectingRate = (long)(((double)_medication.Amount) / _defaultSpan.TotalSeconds);
                        _remainAmount = _medication.Amount;
                        _lastUpdate = DateTime.Now;
                        CONTAINER.BackColor = InjectorBackcolor;
                        //开启注射定时器
                        _injecttimer.Change(0, interval);
                        CALL.Enabled = true;
                        SWITCH.Text = "结束注射";
                        //更新状态机
                        _state = ClientState.Injecting;
                    }
                }
                //如果处于注射状态，则执行结束注射
                else
                {
                    //调用服务操作，结束注射
                    if (_proxy.EndMainline(_patient, _bedNo))
                    {
                        //关闭定时器
                        _injecttimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                        //如果处于呼叫服务状态，停止呼叫
                        if (_state == ClientState.Calling)
                        {
                            _calltimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                            CALL.Text = "呼叫服务";
                        }
                        //这里的等待是为了防止定时器正在执行最后一次事件
                        Thread.Sleep(300);
                        CALL.BackColor = CallingColorBack;
                        CALL.Enabled = false;
                        SWITCH.Text = "开始注射";
                        REMAIN.Height = 0;
                        CONTAINER.BackColor = InjectorSwithedOff;
                        //修改状态机
                        _state = ClientState.On;
                    }

                }
            }
        }
        private static void ShowMessage(String message)
        {
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);
        }
        public void SetProxy(ServiceProxy proxy)
        {
            _proxy = proxy;
        }
        public void RemoveRroxy()
        {
            _proxy = null;
        }
        /// <summary>
        /// 注射定时器事件处理方法
        /// </summary>
        private void Inject(object state)
        {
            DateTime now = DateTime.Now;
            //计算药物剩余量
            _remainAmount -= (long)(((double)_injectingRate) * (now.Subtract(_lastUpdate).TotalSeconds));
            _lastUpdate = now;
            decimal temp = ((decimal)CONTAINER.Height) * _remainAmount;
            //计算控件高度
            decimal height = temp / _medication.Amount;
            //调用委托
            BeginInvoke(new DrawInjectorDelegate(DrawInjector), (int)height);
        }
        /// <summary>
        /// 调整显示控件高度
        /// </summary>
        /// <param name="height">高度</param>
        private void DrawInjector(int height)
        {
            REMAIN.Height = height;
            REMAIN.Location = new System.Drawing.Point(0, CONTAINER.Height - height);
        }
        /// <summary>
        /// 点击了呼叫服务/结束呼叫
        /// </summary>
        private void CALL_Click(object sender, EventArgs e)
        {
            //如果状态为注射，则开始呼叫服务
            if (_state == ClientState.Injecting)
            {
                //调用代理访问服务
                if (_proxy.EmergentCall(_bedNo))
                {
                    CALL.Text = "呼叫中";
                    //启动定时器开始闪烁
                    _calltimer.Change(0, _callinterval);
                    _state = ClientState.Calling;
                }
            }
            //如果状态为呼叫服务，则停止呼叫
            else if (_state == ClientState.Calling)
            {
                //调用代理访问服务
                if (_proxy.EndEmergentCall(_bedNo))
                {
                    CALL.Text = "呼叫服务";
                    _calltimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                    CALL.BackColor = CallingColorBack;
                    _state = ClientState.Injecting;
                }
            }
        }
        /// <summary>
        /// 定时器事件处理方法
        /// </summary>
        private void CallTimerHandler(object state)
        {
            if (_state == ClientState.Calling)
                BeginInvoke(new CallDelegate(CallButtonFlash)); ;
        }
        /// <summary>
        /// 控制闪烁方法
        /// </summary>
        private void CallButtonFlash()
        {
            lock (lockobj)
            {
                if (CALL.BackColor == CallingColorBack)
                    CALL.BackColor = CallingColor;
                else
                    CALL.BackColor = CallingColorBack;
            }
        }
        public void AdjustRate(long amountPerSecond)
        {
            _injectingRate = amountPerSecond;
        }
        public PatientStatus GetStatus()
        {
            if (_state == ClientState.On || _state == ClientState.MissingHeartBeat)
                return null;
            PatientStatus status = new PatientStatus(_patient, _medication, _remainAmount, _injectingRate);
            return status;
        }
    }
}
