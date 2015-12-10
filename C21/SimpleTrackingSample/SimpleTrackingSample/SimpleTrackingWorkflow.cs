using System;
using System.Workflow.Activities;

namespace Microsoft.Samples.Workflow.SimpleTrackingSample
{
    public partial class SimpleTrackingWorkflow : SequentialWorkflowActivity
    {
        public SimpleTrackingWorkflow()
        {
            InitializeComponent();
        }
        
        private void OnCode1ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Ö´ÐÐCodeActivity");
        }
    }
}
