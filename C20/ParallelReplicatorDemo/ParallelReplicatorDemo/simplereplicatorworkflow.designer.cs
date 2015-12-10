using System;
using System.Workflow.Activities;

namespace ParallelReplicatorDemo
{
    public sealed partial class SimpleReplicatorWorkflow
    {
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.SampleReplicatorChildActivity1 = new ParallelReplicatorDemo.SampleReplicatorChildActivity();
            this.ReplicatorWork = new System.Workflow.Activities.ReplicatorActivity();
            // 
            // SampleReplicatorChildActivity1
            // 
            this.SampleReplicatorChildActivity1.InstanceData = null;
            this.SampleReplicatorChildActivity1.Name = "SampleReplicatorChildActivity1";
            activitybind1.Name = "SimpleReplicatorWorkflow";
            activitybind1.Path = "ChildData";
            // 
            // ReplicatorWork
            // 
            this.ReplicatorWork.Activities.Add(this.SampleReplicatorChildActivity1);
            this.ReplicatorWork.ExecutionType = System.Workflow.Activities.ExecutionType.Parallel;
            this.ReplicatorWork.Name = "ReplicatorWork";
            this.ReplicatorWork.ChildInitialized += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.ChildInitializer);
            this.ReplicatorWork.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // SimpleReplicatorWorkflow
            // 
            this.Activities.Add(this.ReplicatorWork);
            this.Name = "SimpleReplicatorWorkflow";
            this.CanModifyActivities = false;

        }

        private SampleReplicatorChildActivity SampleReplicatorChildActivity1;
        private ReplicatorActivity ReplicatorWork;
    }
}
