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

namespace ApprovalOrder
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
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            this.RejectOrder = new System.Workflow.Activities.CodeActivity();
            this.ApprovalOrder = new System.Workflow.Activities.CodeActivity();
            this.NoIfElseBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.YesIfElseBranch = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            // 
            // RejectOrder
            // 
            this.RejectOrder.Name = "RejectOrder";
            this.RejectOrder.ExecuteCode += new System.EventHandler(this.RejectOrderCode);
            // 
            // ApprovalOrder
            // 
            this.ApprovalOrder.Name = "ApprovalOrder";
            this.ApprovalOrder.ExecuteCode += new System.EventHandler(this.ApprovalOrderCode);
            // 
            // NoIfElseBranch
            // 
            this.NoIfElseBranch.Activities.Add(this.RejectOrder);
            this.NoIfElseBranch.Name = "NoIfElseBranch";
            // 
            // YesIfElseBranch
            // 
            this.YesIfElseBranch.Activities.Add(this.ApprovalOrder);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IsApproved);
            this.YesIfElseBranch.Condition = codecondition1;
            this.YesIfElseBranch.Name = "YesIfElseBranch";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.YesIfElseBranch);
            this.ifElseActivity1.Activities.Add(this.NoIfElseBranch);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private IfElseBranchActivity NoIfElseBranch;
        private IfElseBranchActivity YesIfElseBranch;
        private CodeActivity RejectOrder;
        private CodeActivity ApprovalOrder;
        private IfElseActivity ifElseActivity1;








    }
}
