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
            childData.Add("�����ӻ����1");
            childData.Add("�����ӻ����2");
            childData.Add("�����ӻ����3");
            childData.Add("�����ӻ����4");
        }


        private void ChildInitializer(object sender, ReplicatorChildEventArgs args)
        {
            //ʹ�ô��ݽ�����InstanceDataΪ�ӻ�����Ը�ֵ            
            (args.Activity as SampleReplicatorChildActivity).InstanceData = args.InstanceData as string;
        }
    }
}
