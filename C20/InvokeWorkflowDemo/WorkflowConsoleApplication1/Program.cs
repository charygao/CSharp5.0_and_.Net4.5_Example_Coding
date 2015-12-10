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
                //���ر��ط���
                ExternalDataExchangeService dataService = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataService);
                //���Զ����ͨ�ŷ�����ص����ط�����
                ls = new LocalService();
                dataService.AddService(ls);
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e)
                {
                    //�����Ҫ������һ���ӹ���������ô��Ҫ��鹤�����Ƿ���ɣ�����������������
                    if (e.WorkflowInstance.InstanceId != HostWFGuid)
                    {
                        //�÷���֪ͨ�������������ù��������
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
