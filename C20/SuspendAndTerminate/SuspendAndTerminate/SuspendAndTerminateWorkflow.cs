using System;
using System.Workflow.Activities;

namespace SuspendAndTerminate
{
    public sealed partial class SuspendAndTerminateWorkflow : SequentialWorkflowActivity
    {
        public SuspendAndTerminateWorkflow()
        {
            InitializeComponent();
        }

        private void OnConsoleMessage(object sender, EventArgs e)
        {
            Console.WriteLine("\n����CodeActivity�������Ϣ��Ҳ���ڹ������ָ�֮�����Ϣ");
        }
    }
}
