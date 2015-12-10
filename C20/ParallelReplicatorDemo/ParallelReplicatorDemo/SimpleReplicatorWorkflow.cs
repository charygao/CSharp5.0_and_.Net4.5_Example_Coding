using System;
using System.Collections;
using System.Workflow.Activities;
using System.Collections.Generic;

namespace ParallelReplicatorDemo
{
    public sealed partial class SimpleReplicatorWorkflow : SequentialWorkflowActivity
    {
        private List<string> childData = new List<string>();
        public List<string> ChildData
        {
            get
            {
                return childData;
            }
        }
        public SimpleReplicatorWorkflow()
        {
            InitializeComponent();
            childData.Add("这是子活动数据1");
            childData.Add("这是子活动数据2");
            childData.Add("这是子活动数据3");
            childData.Add("这是子活动数据4");
        }


        private void ChildInitializer(object sender, ReplicatorChildEventArgs args)
        {
            //使用传递进来的InstanceData为子活动的属性赋值            
            (args.Activity as SampleReplicatorChildActivity).InstanceData = args.InstanceData as string;
        }
    }
}
