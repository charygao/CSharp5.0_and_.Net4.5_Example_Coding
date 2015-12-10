using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Data;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Workflows
{
	/// <summary>
	/// 一个自定义的活动外观主题
	/// </summary>
	internal sealed class UserActivityDesignerTheme : ActivityDesignerTheme
	{
		public UserActivityDesignerTheme(WorkflowTheme theme)
			: base(theme)
		{
			this.BorderColor = Color.DarkSlateBlue;
			this.BorderStyle = DashStyle.Solid;
			this.BackColorStart = Color.AliceBlue;
			this.BackColorEnd = Color.CadetBlue;
			this.BackgroundStyle = LinearGradientMode.ForwardDiagonal;
		}
	}
	/// <summary>
	///为活动应用自定义的外观主题
	/// </summary>
	[ActivityDesignerThemeAttribute(typeof(UserActivityDesignerTheme))]
	public class UserActivityDesigner : ActivityDesigner
	{
	}
    //为活动指定一个自定义的没计器组件
	[Designer(typeof(UserActivityDesigner), typeof(IDesigner))]
	public partial class UserActivity : Activity, IEventActivity, IActivityEventListener<QueueEventArgs>
	{
        public enum Status 
        { 
            /// <summary>
            ///从工作流队列中等待输入
            /// </summary>
            Waiting, 
            /// <summary>
            ///当从工作流队列中成功接收到输入时
            /// </summary>
            Completed, 
            /// <summary>
            ///当从工作流中取消而并未接收到输入时
            /// </summary>
            Cancelled 
        }
        //构造函数
        public UserActivity()
		{
			InitializeComponent();
            //使用在Helper类中定义的MakeQueueName方法生成活动的名称
			queueName = Helper.MakeQueueName(this.ActivityGuid);
        }

		#region IEventActivity 成员
		private string queueName;
        /// <summary>
        /// IEventActivity所需要指定的队列名称
        /// </summary>
		public IComparable QueueName
		{
			get { return queueName; }
		}
        /// <summary>
        /// 当活动作为EventDrivenActivity活动的子活动，并且活动并不实际的被执行时，将调用该方法。
        /// ChangeToSubscribedState会将当前活动的状态变为Waiting状态。
        /// </summary>
        /// <param name="parentContext">表示Activity的执行环境的ActivityExecutionContext</param>
        /// <param name="parentEventHandler">父事件的EventHandler</param>
		public void Subscribe(ActivityExecutionContext parentContext, 
            IActivityEventListener<QueueEventArgs> parentEventHandler)
		{
			ChangeToSubscribedState(parentContext, parentEventHandler);
		}
        /// <summary>
        /// 取消活动对事件的订，ChangeToUnsubscribedState方法将移除事件的订阅
        /// </summary>
        public void Unsubscribe(ActivityExecutionContext parentContext, 
            IActivityEventListener<QueueEventArgs> parentEventHandler)
		{
			ChangeToUnsubscribedState(parentContext, parentEventHandler);
		}
		#endregion

		#region Activity Overrides
        /// <summary>        
        /// 需要考虑两种活动的执行场景，作为EventDrivenActivity的子活动或者是直接放在工作流中时
        /// 当直接放在工作流实例中时，需要创建队列，订阅事件，然后告之工作流引擎正在处理。
        /// 当作为EventDrivenActivity的子活动时，队列己经被创建，在活动执行前接收输入。
		protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
		{
            if (TryToComplete(context) == Status.Completed)
            {
                //写入跟踪数据库中
                TrackThis(context);
                return ActivityExecutionStatus.Closed;
            }
            //活动开始执行时转到订阅状态
			this.ChangeToSubscribedState(context, this);
			return ActivityExecutionStatus.Executing;
		}
        /// <summary>
        /// 当需要取消一个正在执行的活动时，调用该方法，该方法将取消订阅事件并删除队列。
        /// </summary>
        protected override ActivityExecutionStatus Cancel(ActivityExecutionContext context)
		{
            Close(context, false);
            //返回活动的状态为Closed。
			return ActivityExecutionStatus.Closed;
		}
		#endregion
        
        #region IActivityEventListener<UserActivityCompletedEventArgs> Members
        /// <summary>
        /// 当按标准顺序执行时（直接放在工作流上时），队列事件被该方法处理，该方法检查输入并且关闭活动。
        /// </summary>
        public void OnEvent(object sender, QueueEventArgs e)
		{
			ActivityExecutionContext context = sender as ActivityExecutionContext;
            //获取当前活动的执行环境，如果当前活动不是直接放在工作流实例中，则直接返回
            if (context == null || this.ExecutionStatus != ActivityExecutionStatus.Executing)
                return;
            //如果是的话，则直接关闭活动
            else if (TryToComplete(context) == Status.Completed)
                Close(context, true);
        }
        #endregion

        /// <summary>
        /// 更改事件订阅状态，通过UserActivityService一个新的用户活动己经创建，
        /// 在该方法中将获取己存在的队列或者是创建一个新的队列。并注册相应的监听器
        /// </summary>
        private void ChangeToSubscribedState(ActivityExecutionContext context, 
            IActivityEventListener<QueueEventArgs> listener)
        {
            WorkflowQueue queue = GetOrCreateQueue(context);
            //向队列中注册一个订户
            queue.RegisterForQueueItemAvailable(listener);
            //根据用户在属性窗口中指定的参数创建一个用户活动数据库记录
            Helper.UserActivityService.CreateUserActivity(WorkflowGuid, 
                ActivityGuid, ActivityType, RequiredRole, Description, DataSet);
            //设置当前状态为Waiting状态
            currentStatus = Status.Waiting;
            //添加跟踪记录
            TrackThis(context);
        }
        /// <summary>
        /// 创建或获取一个工作流队列
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private WorkflowQueue GetOrCreateQueue(ActivityExecutionContext context)
        {
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (qService.Exists(this.QueueName))
                //如果存在指定名称的队列，则获取该队列
                return qService.GetWorkflowQueue(this.QueueName);
            else
                //否则创建一个新的队列
                return qService.CreateWorkflowQueue(this.QueueName, true);
        }
        /// <summary>
        /// 关闭活动的执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="closeActivity"></param>
        private void Close(ActivityExecutionContext context, bool closeActivity)
        {
            //取消订阅状态
            ChangeToUnsubscribedState(context, this);
            EnsureQueueDoesNotExist(context);
            //记录跟踪数据
            TrackThis(context);
            //关闭活动
            if (closeActivity)
                context.CloseActivity();
        }
        /// <summary>
        /// 切换到未订阅状态，涉及取消注册队列的监听器，检测并记录在输入被接收前是否己取消订阅在 。意味着活动己被取消
        /// </summary>
        private void ChangeToUnsubscribedState(ActivityExecutionContext context,
            IActivityEventListener<QueueEventArgs> listener)
        {
            if (TryToComplete(context) != Status.Completed)
                RecordCancellation(context);
            //获取WorkflowQueuingService对象实例
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (qService.Exists(this.QueueName))
            {
                WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);
                //向队列取消一个订户
                queue.UnregisterForQueueItemAvailable(listener);
            }
        }
        /// <summary>
        /// 将当前活动状态置为取消
        /// </summary>
        /// <param name="context"></param>
        private void RecordCancellation(ActivityExecutionContext context)
        {
            Helper.UserActivityService.CancelUserActivity(ActivityGuid);
            this.currentStatus = Status.Cancelled;
            TrackThis(context);
        }
        /// <summary>
        /// 检查并删除指定名称的工作流队列
        /// </summary>
        /// <param name="context"></param>
        private void EnsureQueueDoesNotExist(ActivityExecutionContext context)
		{
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (qService.Exists(this.QueueName))
                qService.DeleteWorkflowQueue(this.QueueName);
		}
        /// <summary>
        /// 手动的写入跟踪数据
        /// </summary>
        private void TrackThis(ActivityExecutionContext context)
        {
            context.TrackData(this);
        }
        /// <summary>
        /// 如果用户活动己经完成，返回CurrentStatus，否则尝试改变用户活动的状态为完成。
        /// </summary>
        private Status TryToComplete(ActivityExecutionContext context)
        {
            if (CurrentStatus == Status.Completed)
                return CurrentStatus;
            //获取输入数据
            UserActivityCompletedEventArgs input = TryGetInput(context);
            if (input != null)
            {
                DataSet = input.ActivityData;
                currentStatus = Status.Completed;
            }
            //返回当前的状态
            return CurrentStatus;
        }
        /// <summary>
        /// 从队列中获取输入，如果找不到则返回null
        /// </summary>               
        private UserActivityCompletedEventArgs TryGetInput(ActivityExecutionContext context)
        {
            if (context == null)
                return null;
            //获取WorkflowQueueingService对象的实例
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (!qService.Exists(this.QueueName))
                return null;
            //获取当前活动的工作流队列
            WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);
            if (queue.Count == 0)
                return null;
            //从队列中获取当前输入数据
            UserActivityCompletedEventArgs eventArgs = 
                queue.Dequeue() as UserActivityCompletedEventArgs;
            if (eventArgs == null)
                return null;
            //返回输入数据
            return eventArgs;
        }
		#region Properties
        //当前活动的状态
        private Status currentStatus;
        /// <summary>
        /// 当前活动的状态
        /// </summary>
        public Status CurrentStatus
        {
            get { return currentStatus; }
        }
		private Guid? activityGuid = null;
		/// <summary>
		/// 活动的全局唯一标识符
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Guid ActivityGuid
		{
			get
			{
				if (!activityGuid.HasValue)
					activityGuid = Guid.NewGuid();
                //如果为空值，则生成一个全新的Guid并返回
				return activityGuid.Value;
			}
		}
		/// <summary>
		///容器工作流的全局唯一标识符
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Guid WorkflowGuid
		{
			get { return this.WorkflowInstanceId; }
		}
        //定义一个用于数据绑定的依赖属性
		public static DependencyProperty DataSetProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("DataSet", 
            typeof(DataSet), typeof(UserActivity));
		[Description("当活动运行时用户所要编辑的数据集")]
		[Category("Parameters")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public DataSet DataSet
		{
			get { return ((DataSet)(base.GetValue(UserActivity.DataSetProperty))); }
			set { base.SetValue(UserActivity.DataSetProperty, value); }
		}
        //定义活动类型的依赖属性
		public static DependencyProperty ActivityTypeProperty = 
            System.Workflow.ComponentModel.DependencyProperty.Register("ActivityType", 
            typeof(UserActivityType), typeof(UserActivity));
		[Description("用户将要使用的活动的类型.")]
		[Category("Parameters")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public UserActivityType ActivityType
		{
			get { return ((UserActivityType)(base.GetValue(UserActivity.ActivityTypeProperty))); }
			set { base.SetValue(UserActivity.ActivityTypeProperty, value); }
		}
        //定义所需要的角色的依赖属性
		public static DependencyProperty RequiredRoleProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("RequiredRole",
            typeof(UserRole), typeof(UserActivity));
		[Description("用户必须具备的角色类型")]
		[Category("Parameters")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public UserRole RequiredRole
		{
			get { return ((UserRole)(base.GetValue(UserActivity.RequiredRoleProperty))); }
			set { base.SetValue(UserActivity.RequiredRoleProperty, value); }
		}
		#endregion
	}
}
