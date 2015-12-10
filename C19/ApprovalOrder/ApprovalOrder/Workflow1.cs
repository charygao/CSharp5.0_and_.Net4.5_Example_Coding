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

namespace ApprovalOrder
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        private bool _approved = false;
        public bool Approved
        {
            get { return _approved; }
            set { _approved = value; }
        }


        private void IsApproved(object sender, ConditionalEventArgs e)
        {
            e.Result = _approved;
        }
        //NoIfBranch中的代码活动所执行的代码
        private void ApprovalOrderCode(object sender, EventArgs e)
        {
            Console.WriteLine("订单被批核了!");
        }
        //YesIfBranch中的代码活动所执行的代码
        private void RejectOrderCode(object sender, EventArgs e)
        {
            Console.WriteLine("订单被取消了!");
        }
	}

}
