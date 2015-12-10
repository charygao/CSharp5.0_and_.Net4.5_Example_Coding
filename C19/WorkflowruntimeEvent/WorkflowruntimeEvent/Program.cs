using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace WorkflowruntimeEvent
{
    class Program
    {
        public static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                //AutoResetEvent waitHandle = new AutoResetEvent(false);
                //调用AddService方法添加自定义的文件持久化服务
                //workflowRuntime.AddService(new FilePersistenceService(true));
                workflowRuntime.WorkflowCreated += OnWorkflowCreated;
                workflowRuntime.WorkflowIdled += OnWorkflowIdle;
                workflowRuntime.WorkflowUnloaded += OnWorkflowUnload;
                workflowRuntime.WorkflowLoaded += OnWorkflowLoad;
                workflowRuntime.ServicesExceptionNotHandled += OnExceptionNotHandled;
                workflowRuntime.WorkflowTerminated += OnWorkflowTerminated;
                workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;
                //创建并启动工作流实例
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(WorkflowruntimeEvent.Workflow1));
                instance.Start();
                //等待接收信号中
                waitHandle.WaitOne();
                Console.Read();
            }
        }
        static void OnExceptionNotHandled(object sender, ServicesExceptionNotHandledEventArgs e)
        {
            Console.WriteLine(" 未处理的工作流异常 ");
            Console.WriteLine("  类型: " + e.GetType().ToString());
            Console.WriteLine("  消息: " + e.Exception.Message);
        }
        static void OnWorkflowCreated(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("工作流被创建\n");
        }
        static void OnWorkflowIdle(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("工作流空闲中\n");
        }
        static void OnWorkflowUnload(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("工作流己卸载\n");
        }
        static void OnWorkflowLoad(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("工作流己加载\n");
        }
        static void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine("工作流被中止，异常信息为："+e.Exception.Message);
            waitHandle.Set();
        }
        static void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            Console.WriteLine("工作流完成 \n");
            waitHandle.Set();
        }
    }
}
