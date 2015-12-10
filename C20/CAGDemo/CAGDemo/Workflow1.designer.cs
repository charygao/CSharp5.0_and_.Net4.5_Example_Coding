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

namespace CAGDemo
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference3 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference4 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.DCode = new System.Workflow.Activities.CodeActivity();
            this.CCode = new System.Workflow.Activities.CodeActivity();
            this.BCode = new System.Workflow.Activities.CodeActivity();
            this.ACode = new System.Workflow.Activities.CodeActivity();
            this.conditionedActivityGroup1 = new System.Workflow.Activities.ConditionedActivityGroup();
            ruleconditionreference1.ConditionName = "丁出版社";
            // 
            // DCode
            // 
            this.DCode.Name = "DCode";
            this.DCode.ExecuteCode += new System.EventHandler(this.DCode_ExecuteCode);
            this.DCode.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference1);
            ruleconditionreference2.ConditionName = "丙出版社";
            // 
            // CCode
            // 
            this.CCode.Name = "CCode";
            this.CCode.ExecuteCode += new System.EventHandler(this.CCode_ExecuteCode);
            this.CCode.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference2);
            ruleconditionreference3.ConditionName = "丙出版社";
            // 
            // BCode
            // 
            this.BCode.Name = "BCode";
            this.BCode.ExecuteCode += new System.EventHandler(this.BCode_ExecuteCode);
            this.BCode.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference3);
            ruleconditionreference4.ConditionName = "丙出版社";
            // 
            // ACode
            // 
            this.ACode.Name = "ACode";
            this.ACode.ExecuteCode += new System.EventHandler(this.ACode_ExecuteCode);
            this.ACode.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, ruleconditionreference4);
            // 
            // conditionedActivityGroup1
            // 
            this.conditionedActivityGroup1.Activities.Add(this.ACode);
            this.conditionedActivityGroup1.Activities.Add(this.BCode);
            this.conditionedActivityGroup1.Activities.Add(this.CCode);
            this.conditionedActivityGroup1.Activities.Add(this.DCode);
            this.conditionedActivityGroup1.Name = "conditionedActivityGroup1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.conditionedActivityGroup1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity DCode;
        private CodeActivity CCode;
        private CodeActivity BCode;
        private CodeActivity ACode;
        private ConditionedActivityGroup conditionedActivityGroup1;























    }
}
