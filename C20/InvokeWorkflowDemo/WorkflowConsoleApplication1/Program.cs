#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;

#endregion

namespace WorkflowConsoleApplication1
{
    class Program
    {
        static Guid HostWFGuid;
        static LocalService ls;

        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                //加载本地服务
                ExternalDataExchangeService dataService = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataService);
                //将自定义的通信服务加载到本地服务中
                ls = new LocalService();
                dataService.AddService(ls);
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e)
                {
                    //如果将要产生仅一个子工作流，那么需要检查工作流是否完成，而不是主工作流。
                    if (e.WorkflowInstance.InstanceId != HostWFGuid)
                    {
                        //该方法通知主工作流，调用工作流完成
                        ls.WorkComplete(HostWFGuid);
                    }
                    else
                    {
                        waitHandle.Set();
                    }
                }; 
                
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(WorkflowConsoleApplication1.Workflow1));
                HostWFGuid = instance.InstanceId;
                instance.Start();

                waitHandle.WaitOne();
                Console.ReadLine();
            }
        }
    }
}
