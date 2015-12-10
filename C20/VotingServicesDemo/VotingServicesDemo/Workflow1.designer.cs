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

namespace VotingServicesDemo
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.RejectProposal = new System.Workflow.Activities.HandleExternalEventActivity();
            this.ApprovalProposal = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // RejectProposal
            // 
            this.RejectProposal.EventName = "RejectedProposal";
            this.RejectProposal.InterfaceType = typeof(VotingServicesDemo.IVotingService);
            this.RejectProposal.Name = "RejectProposal";
            this.RejectProposal.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnRejected);
            // 
            // ApprovalProposal
            // 
            this.ApprovalProposal.EventName = "ApprovedProposal";
            this.ApprovalProposal.InterfaceType = typeof(VotingServicesDemo.IVotingService);
            this.ApprovalProposal.Name = "ApprovalProposal";
            this.ApprovalProposal.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnApproved);
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.RejectProposal);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.ApprovalProposal);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity1);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity2);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // callExternalMethodActivity1
            // 
            this.callExternalMethodActivity1.InterfaceType = typeof(VotingServicesDemo.IVotingService);
            this.callExternalMethodActivity1.MethodName = "CreateBallot";
            this.callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "Alias";
            workflowparameterbinding1.ParameterName = "alias";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.callExternalMethodActivity1);
            this.Activities.Add(this.listenActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private HandleExternalEventActivity RejectProposal;
        private HandleExternalEventActivity ApprovalProposal;
        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity listenActivity1;
        private CallExternalMethodActivity callExternalMethodActivity1;



    }
}
