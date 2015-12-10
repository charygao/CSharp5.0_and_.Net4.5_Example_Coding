using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.ServiceModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WCF.CaseStudy
{
    public partial class Console : Form
    {
        //客户端的状态集合
        private Dictionary<int, ClientState> _clientStates = new Dictionary<int, ClientState>();
        //客户端回调引用集合
        private Dictionary<int, IInjector> _callbackRef;
        //病人状态集合
        private Dictionary<int, PatientStatus> _patientStatus = new Dictionary<int, PatientStatus>();
        //最小床号
        private const int minBedNo = 1;
        //最大床号
        private const int maxBedNo = 4;
        //锁对象
        private object lockobj = new object();
        //注射时的颜色
        private static readonly Color inServiceColor = Color.Green;
        //非注射时的颜色
        private static readonly Color outServiceColor = Color.Gray;
        //程序内部使用
        private bool flashflag = false;
        //呼叫服务时，闪烁的亮色
        private static readonly Color CallingColor = Color.Red;
        //呼叫服务时，闪烁的暗色
        private static readonly Color CallingColorBack = Color.FromArgb(255, 236, 233, 216);
        //控制呼叫服务时的定时器
        private System.Threading.Timer _calltimer;
        //呼叫服务闪烁间隔
        private static readonly long _callinterval = 500;
        //呼叫服务时使用的委托类型
        private delegate void CallDelegate();

        /// <summary>
        /// 构造方法
        /// </summary>
        public Console()
        {
            InitializeComponent();
            //初始化定时器
            _calltimer = new System.Threading.Timer(
                                    new System.Threading.TimerCallback(CallTimerHandler), null,
                                    System.Threading.Timeout.Infinite,
                                    System.Threading.Timeout.Infinite);
            //初始化状态机集合
            for (int i = minBedNo; i <= maxBedNo; i++)
            {
                _clientStates.Add(i, ClientState.MissingHeartBeat);
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="callbackRef">客户端回调引用集合</param>
        public Console(Dictionary<int, IInjector> callbackRef)
            : this()
        {
            _callbackRef = callbackRef;
        }
        /// <summary>
        /// 开始注射
        /// </summary>
        public void StartMainlineHandler(object sender, ClientEventArg arg)
        {
            int bedno = arg.BedNo;
            //改变颜色
            Control control = GetBedControl(bedno);
            control.BackColor = inServiceColor;
            //改变状态机
            _clientStates[bedno] = ClientState.Injecting;
        }
        /// <summary>
        /// 结束注射
        /// </summary>
        public void EndMainlineHandler(object sender, ClientEventArg arg)
        {
            int bedno = arg.BedNo;
            //改变颜色
            Control control = GetBedControl(bedno);
            control.BackColor = outServiceColor;
            //改变状态机
            _clientStates[bedno] = ClientState.On;
        }
        /// <summary>
        /// 呼叫服务
        /// </summary>
        public void EmergentCall(object sender, ClientEventArg arg)
        {
            int bedno = arg.BedNo;
            _clientStates[bedno] = ClientState.Calling;
            _calltimer.Change(0, _callinterval);
        }
        /// <summary>
        /// 结束呼叫
        /// </summary>
        public void EndEmergentCall(object sender, ClientEventArg arg)
        {
            int bedno = arg.BedNo;
            _clientStates[bedno] = ClientState.Injecting;
            Control control = GetBedControl(bedno);
            control.BackColor = inServiceColor;
        }
        /// <summary>
        /// 定时器的事件处理方法，使用BeginInvoke来间接访问UI控件
        /// </summary>
        private void CallTimerHandler(object sender)
        {
            BeginInvoke(new CallDelegate(CallFlash));
        }
        /// <summary>
        /// 控制按钮闪烁
        /// </summary>
        private void CallFlash()
        {
            lock (lockobj)
            {
                int count = 0;
                foreach (int bedno in _clientStates.Keys)
                {
                    if (_clientStates[bedno] == ClientState.Calling)
                    {
                        count++;
                        Control control = GetBedControl(bedno);
                        if (!flashflag)
                        {
                            control.BackColor = CallingColor;
                        }
                        else
                        {
                            control.BackColor = CallingColorBack;
                        }
                    }
                }
                if (count == 0)
                    _calltimer.Change(System.Threading.Timeout.Infinite,
                                        System.Threading.Timeout.Infinite);
                else
                    flashflag = !flashflag;
            }
        }
        /// <summary>
        /// 丢失心跳处理
        /// </summary>
        public void MissHeartBeat(object sender, ClientEventArg arg)
        {
            int bedno = arg.BedNo;
            Control control = GetBedControl(bedno);
            control.BackColor = CallingColor;
            _clientStates[bedno] = ClientState.MissingHeartBeat;
        }
        /// <summary>
        /// 心跳处理
        /// </summary>
        public void HeaertBeat(object sender, ClientEventArg arg)
        {
            int bedno = arg.BedNo;
            //如果从丢失心跳的状态恢复，设置按钮颜色
            if (_clientStates[bedno] == ClientState.MissingHeartBeat)
            {
                _clientStates[bedno] = ClientState.On;
                Control control = GetBedControl(bedno);
                control.BackColor = outServiceColor;
            }
            //保存状态
            if (arg.PatientStatus != null)
                _patientStatus[bedno] = arg.PatientStatus;
        }
        private void BED2_Click(object sender, EventArgs e)
        {
            PopupDetail(2);
        }
        private void BED3_Click(object sender, EventArgs e)
        {
            PopupDetail(3);
        }
        private void BED4_Click(object sender, EventArgs e)
        {
            PopupDetail(4);
        }
        private void BED1_Click(object sender, EventArgs e)
        {
            PopupDetail(1);
        }
        /// <summary>
        /// 获取保存的病人信息和注射状态，并且打开Detail窗体
        /// </summary>
        /// <param name="bedNo">床号</param>
        private void PopupDetail(int bedNo)
        {
            if (_clientStates[bedNo] == ClientState.On)
            {
                MessageBox.Show("未开始注射！");
                return;
            }
            if (_clientStates[bedNo] == ClientState.MissingHeartBeat)
            {
                MessageBox.Show("客户端故障！");
                return;
            }
            IInjector injector = _callbackRef[bedNo];
            if (injector == null || !_patientStatus.Keys.Contains(bedNo))
            {
                MessageBox.Show("客户端在启动中，请稍候再试！");
                return;
            }

            Detail detailDialog = new Detail(_patientStatus[bedNo], injector);
            detailDialog.ShowDialog();
        }
        /// <summary>
        /// 根据床号获得按钮控件
        /// </summary>
        /// <param name="bedno">床号</param>
        private Control GetBedControl(int bedno)
        {
            if (bedno >= minBedNo && bedno <= maxBedNo)
            {
                String controlName = "BED" + bedno.ToString();
                foreach (Control control in Controls)
                {
                    if (control.Name == controlName)
                    {
                        return control;
                    }
                }
            }
            return null;
        }
    }
}