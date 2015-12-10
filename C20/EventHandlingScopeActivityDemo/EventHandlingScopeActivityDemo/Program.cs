using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;

namespace EventHandlingScopeActivityDemo
{
    class Program
    {
        private static ScopeImpl _scopeService;
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                //注册本地服务
                ExternalDataExchangeService exchangeService= new ExternalDataExchangeService();
                workflowRuntime.AddService(exchangeService);
                _scopeService = new ScopeImpl();
                exchangeService.AddService(_scopeService);
                //关联事件
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(EventHandlingScopeActivityDemo.Workflow1));
                instance.Start();              
                //允许主活动执行
                Thread.Sleep(300);
                //触发事件
                _scopeService.OnEventOne();
                Thread.Sleep(100);
                _scopeService.OnEventOne();
                Thread.Sleep(100);
                _scopeService.OnEventOne();
                Thread.Sleep(100);
                _scopeService.OnEventTwo();
                Thread.Sleep(100);
                _scopeService.OnEventOne();
                //让主活动再次执行
                Thread.Sleep(3000);
                //通知工作流需要停止
                _scopeService.OnEventStop();             
                Console.WriteLine("完成工作流的执行\n\r");
                Console.Read();
            }
        }
    }
}
