using System;
using System.Workflow.Activities;

namespace ParallelReplicatorDemo
{
    public partial class SampleReplicatorChildActivity
    {
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.code1 = new System.Workflow.Activities.CodeActivity();
            this.CanModifyActivities = true;

            // 
            // code1
            // 
            this.code1.Name = "code1";
            this.code1.ExecuteCode += new System.EventHandler(this.CodeHandler);
            // 
            // SampleReplicatorChildActivity
            // 
            this.Activities.Add(this.code1);
            this.CanModifyActivities = false;
        }

        
        private CodeActivity code1;

    }
}
