using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;

namespace UsingEventDrivenActivity
{
    class Program
    {
        //定义本地服务类
        static POInterfaceImpl orderService;
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                orderService = new POInterfaceImpl();
                //注册本地服务
                ExternalDataExchangeService dataService = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataService);
                dataService.AddService(orderService);
               //关联服务事件
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                //当工作流空闲时，触发此事件
                workflowRuntime.WorkflowIdled += OnWorkflowIdled;
                //其他代码省略
                //.......
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(UsingEventDrivenActivity.Workflow1));
                instance.Start();

                waitHandle.WaitOne();
                Console.ReadLine();
            }
        }

        //当工作流实例空闲时，该方法将被工作流实例调用
        static void OnWorkflowIdled(object sender, WorkflowEventArgs e)
        {
            orderService.instanceId = e.WorkflowInstance;
            //随机的批核，拒收或让采购订单超时
            Random randGen = new Random();
            //根据随机值来决定批核、拒收或超时过程
            int pick = randGen.Next(1, 100) % 3;
            switch (pick)
            {
                case 0:
                    orderService.ApproveOrder();
                    break;
                case 1:
                    orderService.RejectOrder();
                    break;
                case 2:
                    // 超时
                    break;
            }
        }
    }
}
