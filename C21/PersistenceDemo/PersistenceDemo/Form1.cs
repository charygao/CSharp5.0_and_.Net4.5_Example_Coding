using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using PersistenceWorkflow;


namespace PersistenceDemo
{
    public partial class Form1 : Form
    {
        //工作流运行时引擎
        private WorkflowRuntime _wfruntime;
        //工作流持久化服务基类型
        private WorkflowPersistenceService _persistence;
        //来自工作流的本地化服务类
        private PersistenceService _persistenceservice;
        //当前宿主运行的工作流实例的集合
        private Dictionary<Guid, Workflow> _workflows = new Dictionary<Guid, Workflow>();
        //当前所选择的工作流
        private Workflow _selectedWorkflow;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //创建一个新的工作流运行时引擎
            _wfruntime = new WorkflowRuntime();
            //向运行时引擎添加服务
            AddServices(_wfruntime);
            //关联运行时引擎事件
            _wfruntime.WorkflowCreated += new EventHandler<WorkflowEventArgs>(WorkflowRuntime_WorkflowCreated);
            _wfruntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(WorkflowRuntime_WorkflowCompleted);
            _wfruntime.WorkflowPersisted += new EventHandler<WorkflowEventArgs>(WorkflowRuntime_WorkflowPersisted);
            _wfruntime.WorkflowUnloaded += new EventHandler<WorkflowEventArgs>(WorkflowRuntime_WorkflowUnloaded);
            _wfruntime.WorkflowLoaded += new EventHandler<WorkflowEventArgs>(WorkflowRuntime_WorkflowLoaded);
            _wfruntime.WorkflowIdled += new EventHandler<WorkflowEventArgs>(WorkflowRuntime_WorkflowIdled);
            //初始化状态的显示
            btnContinue.Enabled = false;
            btnStop.Enabled = false;
            //开始工作流的运行
            _wfruntime.StartRuntime();
            //加载任何己经被持久化的信息
            RetrieveExistingWorkflows();
        }

        /// <summary>
        ///向运行时引擎添加持久化服务和本地服务
        /// </summary>
        /// <param name="instance"></param>
        private void AddServices(WorkflowRuntime instance)
        {
            //使用标准的SQL持久化服务
            String connStringPersistence = String.Format(
            "Initial Catalog={0};Data Source={1};Integrated Security={2};",
            "WorkflowPersistence", @"localhost\MSSQLSERVER2012", "SSPI");
            _persistence = new SqlWorkflowPersistenceService(connStringPersistence, true, new TimeSpan(0, 2, 0), new TimeSpan(0, 0, 5));
            instance.AddService(_persistence);
            //添加外部数据交换服务
            ExternalDataExchangeService exchangeService = new ExternalDataExchangeService();
            instance.AddService(exchangeService);
            //添加本地服务
            _persistenceservice = new PersistenceService();
            exchangeService.AddService(_persistenceservice);
        }

        /// <summary>
        ///当宿主程序关闭时，清除工作流运行时引擎
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            //cleanup the workflow runtime
            if (_wfruntime != null)
            {
                _wfruntime.Dispose();
            }
        }

        void WorkflowRuntime_WorkflowCreated(object sender,
        WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "己创建");
        }
        void WorkflowRuntime_WorkflowIdled(object sender,
        WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "空闲");
        }
        void WorkflowRuntime_WorkflowLoaded(object sender,
        WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "己加载");
        }
        void WorkflowRuntime_WorkflowUnloaded(object sender,
        WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "己卸载");
        }
        void WorkflowRuntime_WorkflowPersisted(object sender,
        WorkflowEventArgs e)
        {
            UpdateDisplay(e.WorkflowInstance.InstanceId, "己持久化");
        }
        void WorkflowRuntime_WorkflowCompleted(object sender,
        WorkflowCompletedEventArgs e)
        {
            UpdateCompletedWorkflow(e.WorkflowInstance.InstanceId);
            UpdateDisplay(e.WorkflowInstance.InstanceId, "己完成");
        }
        private delegate void UpdateDelegate();
        /// <summary>
        /// 为工作流更新状态消息
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="statusMessage"></param>
        private void UpdateDisplay(Guid instanceId, String statusMessage)
        {
            UpdateDelegate theDelegate = delegate()
            {
                Workflow workflow = GetWorkflow(instanceId);
                workflow.StatusMessage = statusMessage;
                RefreshData();
                //将当前线程延迟1秒。
                System.Threading.Thread.Sleep(1000);
                SetButtonState();
            };
            //在UI线程上执行委托代码
            this.Invoke(theDelegate);
        }
        /// <summary>
        /// 更新DataGridView的数据绑定
        /// </summary>
        private void RefreshData()
        {
            if (dataGridView1.DataSource == null)
            {
                //为DataGriedView设置数据绑定
                dataGridView1.DataSource = new BindingList<Workflow>();
                dataGridView1.Columns[0].MinimumWidth = 250;
                dataGridView1.Columns[1].MinimumWidth = 140;
                dataGridView1.Columns[2].MinimumWidth = 40;
            }
            BindingList<Workflow> bl =(BindingList<Workflow>)dataGridView1.DataSource;
            foreach (Workflow wf in _workflows.Values)
            {
                //确保绑定列表包含所有的工作流实例
                if (!bl.Contains(wf))
                {
                    bl.Add(wf);
                    //设置新实例作为GridView的当前实例                    
                    this.BindingContext[dataGridView1.DataSource].Position
                    = bl.Count - 1;
                }
            }
            dataGridView1.Refresh();
        }
        /// <summary>
        /// 使工作流实例完成
        /// </summary>
        /// <param name="instanceId"></param>
        private void UpdateCompletedWorkflow(Guid instanceId)
        {
            UpdateDelegate theDelegate = delegate()
            {
                Workflow workflow = GetWorkflow(instanceId);
                workflow.IsCompleted = true;
            };
            //在UI线程上执行委托代码
            this.Invoke(theDelegate);
        }
        /// <summary>
        ///开始一个新的工作流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewWorkflow_Click(object sender, EventArgs e)
        {
            //创建一个新的工作流实例
            WorkflowInstance instance =_wfruntime.CreateWorkflow(typeof(Workflow1), null);
            instance.Start();
        }
        /// <summary>
        ///通过本地服务触发继续事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (_selectedWorkflow != null)
            {
                _persistenceservice.OnContinueReceived(
                new ExternalDataEventArgs(_selectedWorkflow.InstanceId));
            }
        }
        /// <summary>
        ///当按下停止按钮时，触发停止事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_selectedWorkflow != null)
            {
                _persistenceservice.OnStopReceived(
                new ExternalDataEventArgs(_selectedWorkflow.InstanceId));
            }
        }

        /// <summary>
        ///根据当前选定的工作流实例，设置按钮的状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(
        object sender, EventArgs e)
        {
            //保存选择的工作流实例为类局部变量
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                _selectedWorkflow = selectedRow.DataBoundItem as Workflow;
                SetButtonState();
            }
        }
        /// <summary>
        ///允许或禁止按钮的方法
        /// </summary>
        private void SetButtonState()
        {
            if (_selectedWorkflow != null)
            {
                btnContinue.Enabled = !(_selectedWorkflow.IsCompleted);
                btnStop.Enabled = !(_selectedWorkflow.IsCompleted);
            }
            else
            {
                btnContinue.Enabled = false;
                btnStop.Enabled = false;
            }
        }
        /// <summary>
        ///从本地集合中获取工作流实例
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        private Workflow GetWorkflow(Guid instanceId)
        {
            Workflow result = null;
            if (_workflows.ContainsKey(instanceId))
            {
                result = _workflows[instanceId];
            }
            else
            {
                //创建新的工作流实例
                result = new Workflow();
                result.InstanceId = instanceId;
                _workflows.Add(result.InstanceId, result);
            }
            return result;
        }
        /// <summary>
        ///加载所有己经被持久化的工作流
        /// </summary>
        private void RetrieveExistingWorkflows()
        {
            _workflows.Clear();
            //获取所有己经被持久化的工作流实例
            foreach (SqlPersistenceWorkflowInstanceDescription workflowDesc
            in ((SqlWorkflowPersistenceService)_persistence).GetAllWorkflows())
            {
                Workflow workflow = new Workflow();
                workflow.InstanceId = workflowDesc.WorkflowInstanceId;
                workflow.StatusMessage = "己卸载";
                _workflows.Add(workflow.InstanceId, workflow);
            }
            if (_workflows.Count > 0)
            {
                RefreshData();
            }
        }
    }
}