using System;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Tracking;

namespace Microsoft.Samples.Workflow.SimpleTrackingSample
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        //定义连接到跟踪数据库的连接字符串
        const string connectionString = @"Initial Catalog=WorkflowTracking;Data Source=localhost;Integrated Security=SSPI;User Id=sa;Password=sa";
        static void Main()
        {
            try
            {
                //为WorkflowRuntime指定配置节名
                using (WorkflowRuntime workflowRuntime = new WorkflowRuntime("WorkflowRuntime"))
                {
                    //添加SqltackingService到工作流运行时引擎中
                    //workflowRuntime.AddService(new SqlTrackingService(connectionString));
                    //关联工作流运行时引擎事件
                    workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
                    workflowRuntime.WorkflowTerminated += OnWorkflowTerminated;
                    //创建工作流实例
                    WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(typeof(SimpleTrackingWorkflow));
                    Guid instanceId = workflowInstance.InstanceId;
                    //开始工作流引擎的服务
                    workflowRuntime.StartRuntime();
                    //开始执行工作流实例
                    workflowInstance.Start();
                    //等待信号
                    waitHandle.WaitOne();
                    //停止工作流运行时引擎的执行
                    workflowRuntime.StopRuntime();
                    //获取并显示实例级别的跟踪事件
                    GetInstanceTrackingEvents(instanceId);
                    //获取并显示活动跟踪事件
                    GetActivityTrackingEvents(instanceId);
                    Console.WriteLine("\n工作流实例运行完成.");
                    Console.Read();
                }
            }
            catch (Exception ex)
            {
                //当出现异常时，在控制台窗口显示异常信息
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                else
                    Console.WriteLine(ex.Message);
            }
        }

        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            waitHandle.Set();
        }

        static void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
        }
        /// <summary>
        /// 获取并显示工作流实例级别的事件
        /// </summary>
        /// <param name="instanceId"></param>
        static void GetInstanceTrackingEvents(Guid instanceId)
        {
            SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);
            //使用SqlTrackingQuery对象查询跟踪数据
            SqlTrackingWorkflowInstance sqlTrackingWorkflowInstance;
            //获取工作流实例跟踪数据。
            sqlTrackingQuery.TryGetWorkflow(instanceId, out sqlTrackingWorkflowInstance);
            if (sqlTrackingWorkflowInstance != null)
            {
                Console.WriteLine("\n实例级别的事件:\n");
                //遍历并显示工作流实例跟踪数据
                foreach (WorkflowTrackingRecord workflowTrackingRecord 
                    in sqlTrackingWorkflowInstance.WorkflowEvents)
                {
                    Console.WriteLine("事件描述 : {0}  日期 : {1}", 
                        workflowTrackingRecord.TrackingWorkflowEvent, 
                        workflowTrackingRecord.EventDateTime);
                }
            }
        }
        /// <summary>
        /// 获取并显示活动跟踪事件
        /// </summary>
        /// <param name="instanceId"></param>
        static void GetActivityTrackingEvents(Guid instanceId)
        {
            SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);
            //查询工作流实例根踪数据
            SqlTrackingWorkflowInstance sqlTrackingWorkflowInstance;
            sqlTrackingQuery.TryGetWorkflow(instanceId, out sqlTrackingWorkflowInstance);
            if (sqlTrackingWorkflowInstance != null)
            {
                Console.WriteLine("\n活动跟踪事件:\n");
                //遍历并显示工作流中活动跟踪记录
                foreach (ActivityTrackingRecord activityTrackingRecord 
                    in sqlTrackingWorkflowInstance.ActivityEvents)
                {
                    Console.WriteLine("状态描述 : {0}  日期 : {1} 活动资格ID : {2}", 
                        activityTrackingRecord.ExecutionStatus, 
                        activityTrackingRecord.EventDateTime, 
                        activityTrackingRecord.QualifiedName);
                }
            }
        }
    }
}