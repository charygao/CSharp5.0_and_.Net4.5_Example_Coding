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

namespace WhileActivityDemo
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
            this.Code2 = new System.Workflow.Activities.CodeActivity();
            this.内层循环 = new System.Workflow.Activities.WhileActivity();
            this.Code1 = new System.Workflow.Activities.CodeActivity();
            this.容器活动 = new System.Workflow.Activities.SequenceActivity();
            this.外层循环 = new System.Workflow.Activities.WhileActivity();
            // 
            // Code2
            // 
            this.Code2.Name = "Code2";
            this.Code2.ExecuteCode += new System.EventHandler(this.Code2_ExecuteCode);
            // 
            // 内层循环
            // 
            this.内层循环.Activities.Add(this.Code2);
            ruleconditionreference1.ConditionName = "jCondition";
            this.内层循环.Condition = ruleconditionreference1;
            this.内层循环.Name = "内层循环";
            // 
            // Code1
            // 
            this.Code1.Name = "Code1";
            this.Code1.ExecuteCode += new System.EventHandler(this.Code1_ExecuteCode);
            // 
            // 容器活动
            // 
            this.容器活动.Activities.Add(this.Code1);
            this.容器活动.Activities.Add(this.内层循环);
            this.容器活动.Name = "容器活动";
            // 
            // 外层循环
            // 
            this.外层循环.Activities.Add(this.容器活动);
            ruleconditionreference2.ConditionName = "iCondition";
            this.外层循环.Condition = ruleconditionreference2;
            this.外层循环.Name = "外层循环";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.外层循环);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity Code2;
        private CodeActivity Code1;
        private SequenceActivity 容器活动;
        private WhileActivity 内层循环;
        private WhileActivity 外层循环;











    }
}
