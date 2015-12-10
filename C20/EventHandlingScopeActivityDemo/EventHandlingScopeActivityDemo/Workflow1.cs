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

namespace EventHandlingScopeActivityDemo
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}
        
        private bool _isCompleted = false;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = true; }
        }

        private void CodeMainlineMessage_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("在主活动中执行的代码!");
        }

        private void HandleEventOne_Invoked(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("EventOne事件被触发");
        }
        private void HandleEventStop_Invoked(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("EventStop事件被触发");
            _isCompleted = true;
        }
        private void HandleEventTwo_Invoked(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("EventTwo事件被触发");
        }
	}

}
