using System;
using System.Collections.Generic;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Activities;

namespace VotingServicesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                // 创建本地服务并添加到工作流运行时引擎中
                ExternalDataExchangeService dataService = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataService);
                VotingServiceImpl votingService = new VotingServiceImpl();
                dataService.AddService(votingService);
                //关联事件
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };
                //向工作流实例传递参数
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("Alias", "张三");
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(VotingServicesDemo.Workflow1),parameters);
                instance.Start();               
                waitHandle.WaitOne();
                Console.Read();
            }
        }
    }
}
