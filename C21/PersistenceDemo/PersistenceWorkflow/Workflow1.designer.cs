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

namespace PersistenceWorkflow
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
            this.StopEventHandle = new System.Workflow.Activities.HandleExternalEventActivity();
            this.ContinueReceivedHandle = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.compensatableSequenceActivity1 = new System.Workflow.Activities.CompensatableSequenceActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            // 
            // StopEventHandle
            // 
            this.StopEventHandle.EventName = "StopReceived";
            this.StopEventHandle.InterfaceType = typeof(PersistenceWorkflow.IPersistence);
            this.StopEventHandle.Name = "StopEventHandle";
            this.StopEventHandle.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.StopEventHandle_Invoked);
            // 
            // ContinueReceivedHandle
            // 
            this.ContinueReceivedHandle.EventName = "ContinueReceived";
            this.ContinueReceivedHandle.InterfaceType = typeof(PersistenceWorkflow.IPersistence);
            this.ContinueReceivedHandle.Name = "ContinueReceivedHandle";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.StopEventHandle);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.ContinueReceivedHandle);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity1);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity2);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // compensatableSequenceActivity1
            // 
            this.compensatableSequenceActivity1.Activities.Add(this.listenActivity1);
            this.compensatableSequenceActivity1.Name = "compensatableSequenceActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.compensatableSequenceActivity1);
            ruleconditionreference1.ConditionName = "条件1";
            this.whileActivity1.Condition = ruleconditionreference1;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.whileActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity listenActivity1;
        private CompensatableSequenceActivity compensatableSequenceActivity1;
        private HandleExternalEventActivity StopEventHandle;
        private HandleExternalEventActivity ContinueReceivedHandle;
        private WhileActivity whileActivity1;








    }
}
