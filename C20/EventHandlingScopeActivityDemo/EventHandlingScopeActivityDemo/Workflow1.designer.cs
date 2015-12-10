using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace EventHandlingScopeActivityDemo
{
	partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.CodeMainlineMessage = new System.Workflow.Activities.CodeActivity();
            this.HandleEventStop = new System.Workflow.Activities.HandleExternalEventActivity();
            this.HandleEventTwo = new System.Workflow.Activities.HandleExternalEventActivity();
            this.HandleEventOne = new System.Workflow.Activities.HandleExternalEventActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.eventDrivenActivity3 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            this.eventHandlersActivity1 = new System.Workflow.Activities.EventHandlersActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.eventHandlingScopeActivity1 = new System.Workflow.Activities.EventHandlingScopeActivity();
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:01");
            // 
            // CodeMainlineMessage
            // 
            this.CodeMainlineMessage.Name = "CodeMainlineMessage";
            this.CodeMainlineMessage.ExecuteCode += new System.EventHandler(this.CodeMainlineMessage_ExecuteCode);
            // 
            // HandleEventStop
            // 
            this.HandleEventStop.EventName = "EventStop";
            this.HandleEventStop.InterfaceType = typeof(EventHandlingScopeActivityDemo.IScope);
            this.HandleEventStop.Name = "HandleEventStop";
            this.HandleEventStop.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.HandleEventStop_Invoked);
            // 
            // HandleEventTwo
            // 
            this.HandleEventTwo.EventName = "EventTwo";
            this.HandleEventTwo.InterfaceType = typeof(EventHandlingScopeActivityDemo.IScope);
            this.HandleEventTwo.Name = "HandleEventTwo";
            this.HandleEventTwo.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.HandleEventTwo_Invoked);
            // 
            // HandleEventOne
            // 
            this.HandleEventOne.EventName = "EventOne";
            this.HandleEventOne.InterfaceType = typeof(EventHandlingScopeActivityDemo.IScope);
            this.HandleEventOne.Name = "HandleEventOne";
            this.HandleEventOne.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.HandleEventOne_Invoked);
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.CodeMainlineMessage);
            this.sequenceActivity2.Activities.Add(this.delayActivity1);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // eventDrivenActivity3
            // 
            this.eventDrivenActivity3.Activities.Add(this.HandleEventStop);
            this.eventDrivenActivity3.Name = "eventDrivenActivity3";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.HandleEventTwo);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.HandleEventOne);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.sequenceActivity2);
            ruleconditionreference1.ConditionName = "条件1";
            this.whileActivity1.Condition = ruleconditionreference1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(EventHandlingScopeActivityDemo.IScope);
            this.callExternalMethodActivity1.MethodName = "Started";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            // 
            // eventHandlersActivity1
            // 
            this.eventHandlersActivity1.Activities.Add(this.eventDrivenActivity1);
            this.eventHandlersActivity1.Activities.Add(this.eventDrivenActivity2);
            this.eventHandlersActivity1.Activities.Add(this.eventDrivenActivity3);
            this.eventHandlersActivity1.Name = "eventHandlersActivity1";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.callExternalMethodActivity1);
            this.sequenceActivity1.Activities.Add(this.whileActivity1);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // eventHandlingScopeActivity1
            // 
            this.eventHandlingScopeActivity1.Activities.Add(this.sequenceActivity1);
            this.eventHandlingScopeActivity1.Activities.Add(this.eventHandlersActivity1);
            this.eventHandlingScopeActivity1.Name = "eventHandlingScopeActivity1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.eventHandlingScopeActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private HandleExternalEventActivity HandleEventStop;
        private HandleExternalEventActivity HandleEventTwo;
        private EventDrivenActivity eventDrivenActivity3;
        private EventDrivenActivity eventDrivenActivity2;
        private DelayActivity delayActivity1;
        private CodeActivity CodeMainlineMessage;
        private SequenceActivity sequenceActivity2;
        private EventHandlersActivity eventHandlersActivity1;
        private EventDrivenActivity eventDrivenActivity1;
        private HandleExternalEventActivity HandleEventOne;
        private CallExternalMethodActivity callExternalMethodActivity1;
        private SequenceActivity sequenceActivity1;
        private WhileActivity whileActivity1;
        private EventHandlingScopeActivity eventHandlingScopeActivity1;














    }
}
