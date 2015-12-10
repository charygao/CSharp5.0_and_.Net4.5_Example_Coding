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

namespace RuleConditionDemo
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.LessThan0 = new System.Workflow.Activities.IfElseBranchActivity();
            this.GreaterThan0 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            // 
            // LessThan0
            // 
            ruleconditionreference1.ConditionName = "LessThan0";
            this.LessThan0.Condition = ruleconditionreference1;
            this.LessThan0.Name = "LessThan0";
            // 
            // GreaterThan0
            // 
            ruleconditionreference2.ConditionName = "GreaterThan0";
            this.GreaterThan0.Condition = ruleconditionreference2;
            this.GreaterThan0.Name = "GreaterThan0";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.GreaterThan0);
            this.ifElseActivity1.Activities.Add(this.LessThan0);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private IfElseBranchActivity LessThan0;
        private IfElseBranchActivity GreaterThan0;
        private IfElseActivity ifElseActivity1;





    }
}
