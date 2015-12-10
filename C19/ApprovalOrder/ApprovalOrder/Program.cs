using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Collections.ObjectModel;

namespace ApprovalOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            //弹出提示信息，要求用户指定批核还是拒批单据
            Console.WriteLine("是否要批核该单据？请输入Y或者是N");
            string str=Console.ReadLine();
            //开始工作流引擎
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

               // ReadOnlyCollection<WorkflowInstance> workflow = workflowRuntime.GetLoadedWorkflows();
                //定义工作流参数，CreateWorkflow方法接收一个Dictionary的参数，string类型的key
                //与工作流实例中的公共可写属性对应。
                Dictionary<string, object> wfArgument = new Dictionary<string, object>();
                //将用户输入的信息转换为布尔值
                bool approvedarg = str == "Y" ? true : false;
                wfArgument.Add("Approved", approvedarg);
                //使用CreateWorkflow的重载方法创建工作流实例，并传递wfArgument作为参数。
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(ApprovalOrder.Workflow1),wfArgument);
                instance.Start();
                waitHandle.WaitOne();
            }
            Console.Read();
        }
    }
}
