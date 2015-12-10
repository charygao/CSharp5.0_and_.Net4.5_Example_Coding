using System;
using System.Threading;
using System.Workflow.Runtime;


namespace SuspendAndTerminate
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);
        //当工作流挂起时，将该变量设为true,以便于工作流的恢复
        static Boolean workflowSuspended = false;
        static void Main()
        {
            //开启工作流引擎
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                workflowRuntime.StartRuntime();
                //加载工作流
                Type type = typeof(SuspendAndTerminateWorkflow);
                //定义了工作流的挂起、恢复、终止和完成事件
                workflowRuntime.WorkflowCompleted += OnWorkflowCompletion;
                workflowRuntime.WorkflowSuspended += OnWorkflowSuspend;
                workflowRuntime.WorkflowResumed += OnWorkflowResume;
                workflowRuntime.WorkflowTerminated += OnWorkflowTerminate;
                //创建并开启工作流
                WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(type);
                workflowInstance.Start();
                waitHandle.WaitOne();
                //如果工作流挂起，则恢复工作流
                if (workflowSuspended)
                {
                    Console.WriteLine("\r\n恢复工作流实例");
                    workflowInstance.Resume();
                    waitHandle.WaitOne();
                }
                workflowRuntime.StopRuntime();
                Console.Read();
            }
        }
        //工作流实例完成
        static void OnWorkflowCompletion(object sender, WorkflowCompletedEventArgs instance)
        {
            Console.WriteLine("\r\n工作流实例执行完成");
            waitHandle.Set();
        }
        //工作流实例挂起
        static void OnWorkflowSuspend(object sender, WorkflowSuspendedEventArgs instance)
        {
            workflowSuspended = true;
            Console.WriteLine("\n工作流挂起事件被触发");
            waitHandle.Set();
        }
        //工作流实例恢复
        static void OnWorkflowResume(object sender, WorkflowEventArgs instance)
        {
            Console.WriteLine("\n工作流恢复事件被触发");
        }
        //工作流实例终止
        static void OnWorkflowTerminate(object sender, WorkflowTerminatedEventArgs instance)
        {
            Console.WriteLine("\n工作流终止事件被触发");
            waitHandle.Set();
        }
    }
}
