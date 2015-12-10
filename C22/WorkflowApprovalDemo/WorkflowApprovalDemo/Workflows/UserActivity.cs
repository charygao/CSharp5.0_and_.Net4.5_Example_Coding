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
	/// һ���Զ���Ļ�������
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
	///Ϊ�Ӧ���Զ�����������
	/// </summary>
	[ActivityDesignerThemeAttribute(typeof(UserActivityDesignerTheme))]
	public class UserActivityDesigner : ActivityDesigner
	{
	}
    //Ϊ�ָ��һ���Զ����û�������
	[Designer(typeof(UserActivityDesigner), typeof(IDesigner))]
	public partial class UserActivity : Activity, IEventActivity, IActivityEventListener<QueueEventArgs>
	{
        public enum Status 
        { 
            /// <summary>
            ///�ӹ����������еȴ�����
            /// </summary>
            Waiting, 
            /// <summary>
            ///���ӹ����������гɹ����յ�����ʱ
            /// </summary>
            Completed, 
            /// <summary>
            ///���ӹ�������ȡ������δ���յ�����ʱ
            /// </summary>
            Cancelled 
        }
        //���캯��
        public UserActivity()
		{
			InitializeComponent();
            //ʹ����Helper���ж����MakeQueueName�������ɻ������
			queueName = Helper.MakeQueueName(this.ActivityGuid);
        }

		#region IEventActivity ��Ա
		private string queueName;
        /// <summary>
        /// IEventActivity����Ҫָ���Ķ�������
        /// </summary>
		public IComparable QueueName
		{
			get { return queueName; }
		}
        /// <summary>
        /// �����ΪEventDrivenActivity����ӻ�����һ����ʵ�ʵı�ִ��ʱ�������ø÷�����
        /// ChangeToSubscribedState�Ὣ��ǰ���״̬��ΪWaiting״̬��
        /// </summary>
        /// <param name="parentContext">��ʾActivity��ִ�л�����ActivityExecutionContext</param>
        /// <param name="parentEventHandler">���¼���EventHandler</param>
		public void Subscribe(ActivityExecutionContext parentContext, 
            IActivityEventListener<QueueEventArgs> parentEventHandler)
		{
			ChangeToSubscribedState(parentContext, parentEventHandler);
		}
        /// <summary>
        /// ȡ������¼��Ķ���ChangeToUnsubscribedState�������Ƴ��¼��Ķ���
        /// </summary>
        public void Unsubscribe(ActivityExecutionContext parentContext, 
            IActivityEventListener<QueueEventArgs> parentEventHandler)
		{
			ChangeToUnsubscribedState(parentContext, parentEventHandler);
		}
		#endregion

		#region Activity Overrides
        /// <summary>        
        /// ��Ҫ�������ֻ��ִ�г�������ΪEventDrivenActivity���ӻ������ֱ�ӷ��ڹ�������ʱ
        /// ��ֱ�ӷ��ڹ�����ʵ����ʱ����Ҫ�������У������¼���Ȼ���֮�������������ڴ���
        /// ����ΪEventDrivenActivity���ӻʱ�����м������������ڻִ��ǰ�������롣
		protected override ActivityExecutionStatus Execute(ActivityExecutionContext context)
		{
            if (TryToComplete(context) == Status.Completed)
            {
                //д��������ݿ���
                TrackThis(context);
                return ActivityExecutionStatus.Closed;
            }
            //���ʼִ��ʱת������״̬
			this.ChangeToSubscribedState(context, this);
			return ActivityExecutionStatus.Executing;
		}
        /// <summary>
        /// ����Ҫȡ��һ������ִ�еĻʱ�����ø÷������÷�����ȡ�������¼���ɾ�����С�
        /// </summary>
        protected override ActivityExecutionStatus Cancel(ActivityExecutionContext context)
		{
            Close(context, false);
            //���ػ��״̬ΪClosed��
			return ActivityExecutionStatus.Closed;
		}
		#endregion
        
        #region IActivityEventListener<UserActivityCompletedEventArgs> Members
        /// <summary>
        /// ������׼˳��ִ��ʱ��ֱ�ӷ��ڹ�������ʱ���������¼����÷��������÷���������벢�ҹرջ��
        /// </summary>
        public void OnEvent(object sender, QueueEventArgs e)
		{
			ActivityExecutionContext context = sender as ActivityExecutionContext;
            //��ȡ��ǰ���ִ�л����������ǰ�����ֱ�ӷ��ڹ�����ʵ���У���ֱ�ӷ���
            if (context == null || this.ExecutionStatus != ActivityExecutionStatus.Executing)
                return;
            //����ǵĻ�����ֱ�ӹرջ
            else if (TryToComplete(context) == Status.Completed)
                Close(context, true);
        }
        #endregion

        /// <summary>
        /// �����¼�����״̬��ͨ��UserActivityServiceһ���µ��û������������
        /// �ڸ÷����н���ȡ�����ڵĶ��л����Ǵ���һ���µĶ��С���ע����Ӧ�ļ�����
        /// </summary>
        private void ChangeToSubscribedState(ActivityExecutionContext context, 
            IActivityEventListener<QueueEventArgs> listener)
        {
            WorkflowQueue queue = GetOrCreateQueue(context);
            //�������ע��һ������
            queue.RegisterForQueueItemAvailable(listener);
            //�����û������Դ�����ָ���Ĳ�������һ���û�����ݿ��¼
            Helper.UserActivityService.CreateUserActivity(WorkflowGuid, 
                ActivityGuid, ActivityType, RequiredRole, Description, DataSet);
            //���õ�ǰ״̬ΪWaiting״̬
            currentStatus = Status.Waiting;
            //��Ӹ��ټ�¼
            TrackThis(context);
        }
        /// <summary>
        /// �������ȡһ������������
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private WorkflowQueue GetOrCreateQueue(ActivityExecutionContext context)
        {
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (qService.Exists(this.QueueName))
                //�������ָ�����ƵĶ��У����ȡ�ö���
                return qService.GetWorkflowQueue(this.QueueName);
            else
                //���򴴽�һ���µĶ���
                return qService.CreateWorkflowQueue(this.QueueName, true);
        }
        /// <summary>
        /// �رջ��ִ��
        /// </summary>
        /// <param name="context"></param>
        /// <param name="closeActivity"></param>
        private void Close(ActivityExecutionContext context, bool closeActivity)
        {
            //ȡ������״̬
            ChangeToUnsubscribedState(context, this);
            EnsureQueueDoesNotExist(context);
            //��¼��������
            TrackThis(context);
            //�رջ
            if (closeActivity)
                context.CloseActivity();
        }
        /// <summary>
        /// �л���δ����״̬���漰ȡ��ע����еļ���������Ⲣ��¼�����뱻����ǰ�Ƿ�ȡ�������� ����ζ�Ż����ȡ��
        /// </summary>
        private void ChangeToUnsubscribedState(ActivityExecutionContext context,
            IActivityEventListener<QueueEventArgs> listener)
        {
            if (TryToComplete(context) != Status.Completed)
                RecordCancellation(context);
            //��ȡWorkflowQueuingService����ʵ��
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (qService.Exists(this.QueueName))
            {
                WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);
                //�����ȡ��һ������
                queue.UnregisterForQueueItemAvailable(listener);
            }
        }
        /// <summary>
        /// ����ǰ�״̬��Ϊȡ��
        /// </summary>
        /// <param name="context"></param>
        private void RecordCancellation(ActivityExecutionContext context)
        {
            Helper.UserActivityService.CancelUserActivity(ActivityGuid);
            this.currentStatus = Status.Cancelled;
            TrackThis(context);
        }
        /// <summary>
        /// ��鲢ɾ��ָ�����ƵĹ���������
        /// </summary>
        /// <param name="context"></param>
        private void EnsureQueueDoesNotExist(ActivityExecutionContext context)
		{
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (qService.Exists(this.QueueName))
                qService.DeleteWorkflowQueue(this.QueueName);
		}
        /// <summary>
        /// �ֶ���д���������
        /// </summary>
        private void TrackThis(ActivityExecutionContext context)
        {
            context.TrackData(this);
        }
        /// <summary>
        /// ����û��������ɣ�����CurrentStatus�������Ըı��û����״̬Ϊ��ɡ�
        /// </summary>
        private Status TryToComplete(ActivityExecutionContext context)
        {
            if (CurrentStatus == Status.Completed)
                return CurrentStatus;
            //��ȡ��������
            UserActivityCompletedEventArgs input = TryGetInput(context);
            if (input != null)
            {
                DataSet = input.ActivityData;
                currentStatus = Status.Completed;
            }
            //���ص�ǰ��״̬
            return CurrentStatus;
        }
        /// <summary>
        /// �Ӷ����л�ȡ���룬����Ҳ����򷵻�null
        /// </summary>               
        private UserActivityCompletedEventArgs TryGetInput(ActivityExecutionContext context)
        {
            if (context == null)
                return null;
            //��ȡWorkflowQueueingService�����ʵ��
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();
            if (!qService.Exists(this.QueueName))
                return null;
            //��ȡ��ǰ��Ĺ���������
            WorkflowQueue queue = qService.GetWorkflowQueue(this.QueueName);
            if (queue.Count == 0)
                return null;
            //�Ӷ����л�ȡ��ǰ��������
            UserActivityCompletedEventArgs eventArgs = 
                queue.Dequeue() as UserActivityCompletedEventArgs;
            if (eventArgs == null)
                return null;
            //������������
            return eventArgs;
        }
		#region Properties
        //��ǰ���״̬
        private Status currentStatus;
        /// <summary>
        /// ��ǰ���״̬
        /// </summary>
        public Status CurrentStatus
        {
            get { return currentStatus; }
        }
		private Guid? activityGuid = null;
		/// <summary>
		/// ���ȫ��Ψһ��ʶ��
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Guid ActivityGuid
		{
			get
			{
				if (!activityGuid.HasValue)
					activityGuid = Guid.NewGuid();
                //���Ϊ��ֵ��������һ��ȫ�µ�Guid������
				return activityGuid.Value;
			}
		}
		/// <summary>
		///������������ȫ��Ψһ��ʶ��
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Guid WorkflowGuid
		{
			get { return this.WorkflowInstanceId; }
		}
        //����һ���������ݰ󶨵���������
		public static DependencyProperty DataSetProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("DataSet", 
            typeof(DataSet), typeof(UserActivity));
		[Description("�������ʱ�û���Ҫ�༭�����ݼ�")]
		[Category("Parameters")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public DataSet DataSet
		{
			get { return ((DataSet)(base.GetValue(UserActivity.DataSetProperty))); }
			set { base.SetValue(UserActivity.DataSetProperty, value); }
		}
        //�������͵���������
		public static DependencyProperty ActivityTypeProperty = 
            System.Workflow.ComponentModel.DependencyProperty.Register("ActivityType", 
            typeof(UserActivityType), typeof(UserActivity));
		[Description("�û���Ҫʹ�õĻ������.")]
		[Category("Parameters")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public UserActivityType ActivityType
		{
			get { return ((UserActivityType)(base.GetValue(UserActivity.ActivityTypeProperty))); }
			set { base.SetValue(UserActivity.ActivityTypeProperty, value); }
		}
        //��������Ҫ�Ľ�ɫ����������
		public static DependencyProperty RequiredRoleProperty =
            System.Workflow.ComponentModel.DependencyProperty.Register("RequiredRole",
            typeof(UserRole), typeof(UserActivity));
		[Description("�û�����߱��Ľ�ɫ����")]
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
