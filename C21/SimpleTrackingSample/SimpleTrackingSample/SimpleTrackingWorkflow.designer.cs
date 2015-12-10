using System;
using System.Workflow.Activities;


namespace Microsoft.Samples.Workflow.SimpleTrackingSample
{
    public partial class SimpleTrackingWorkflow 
    {
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.code1 = new System.Workflow.Activities.CodeActivity();
            // 
            // code1
            // 
            this.code1.Name = "code1";
            this.code1.ExecuteCode += new System.EventHandler(this.OnCode1ExecuteCode);
            // 
            // SimpleTrackingWorkflow
            // 
            this.Activities.Add(this.code1);
            this.Name = "SimpleTrackingWorkflow";
            this.CanModifyActivities = false;
        }
        private CodeActivity code1;
    }
}
