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

namespace UsingEventDrivenActivity
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        private void OnBeforeCreateOrder(object sender, EventArgs e)
        {
            Console.WriteLine("\n采购订单工作流被创建");
        }

        private void OnTimeout(object sender, EventArgs e)
        {
            Console.WriteLine("\n采购订单工作流超时");
        }

        private void OnApprovePO(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("\n采购订单被批核");
        }
        private void OnRejected(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("\n采购订单被拒收");
        }
	}

}
