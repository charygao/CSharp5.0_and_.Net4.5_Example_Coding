using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace VotingServicesDemo
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}
        
        private string alias;
        //定义一个表示投票人信息的属性
        public string Alias
        {
            get
            {
                return this.alias;
            }
            set
            {
                this.alias = value;
            }
        }
        //当拒绝事件触发后，触发此事件
        private void OnRejected(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("提议由{0}拒绝.", this.alias);
        }
        //当批核事件触发后，触发此事件
        private void OnApproved(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("提议由{0}批核.", this.alias);
        }
	}

}
