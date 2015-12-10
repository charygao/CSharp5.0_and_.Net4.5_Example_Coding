using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace AnswerToRiddleWF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请回答迷底：言多必失！打一成语");
            //创建工作流引擎，并创建一个工作流实例
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };
                //创建并开启工作流。
                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(AnswerToRiddleWF.Workflow1));
                instance.Start();
                waitHandle.WaitOne();
            }
        }
    }
}
