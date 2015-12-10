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
            Console.WriteLine("\n这是CodeActivity输出的消息，也是在工作流恢复之后的消息");
        }
    }
}
