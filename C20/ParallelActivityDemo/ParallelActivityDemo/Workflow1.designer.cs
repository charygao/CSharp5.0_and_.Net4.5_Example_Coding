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

namespace ParallelActivityDemo
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
            this.Code4 = new System.Workflow.Activities.CodeActivity();
            this.Code2 = new System.Workflow.Activities.CodeActivity();
            this.Code3 = new System.Workflow.Activities.CodeActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.Code1 = new System.Workflow.Activities.CodeActivity();
            this.Sequence2 = new System.Workflow.Activities.SequenceActivity();
            this.Sequence1 = new System.Workflow.Activities.SequenceActivity();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            this.WhileLoop = new System.Workflow.Activities.WhileActivity();
            // 
            // Code4
            // 
            this.Code4.Name = "Code4";
            this.Code4.ExecuteCode += new System.EventHandler(this.Code4_ExecuteCode);
            // 
            // Code2
            // 
            this.Code2.Name = "Code2";
            this.Code2.ExecuteCode += new System.EventHandler(this.Code2_ExecuteCode);
            // 
            // Code3
            // 
            this.Code3.Name = "Code3";
            this.Code3.ExecuteCode += new System.EventHandler(this.Code3_ExecuteCode);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
            // 
            // Code1
            // 
            this.Code1.Name = "Code1";
            this.Code1.ExecuteCode += new System.EventHandler(this.Code1_ExecuteCode);
            // 
            // Sequence2
            // 
            this.Sequence2.Activities.Add(this.Code2);
            this.Sequence2.Activities.Add(this.Code4);
            this.Sequence2.Name = "Sequence2";
            // 
            // Sequence1
            // 
            this.Sequence1.Activities.Add(this.Code1);
            this.Sequence1.Activities.Add(this.delayActivity1);
            this.Sequence1.Activities.Add(this.Code3);
            this.Sequence1.Name = "Sequence1";
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.Sequence1);
            this.parallelActivity1.Activities.Add(this.Sequence2);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // WhileLoop
            // 
            this.WhileLoop.Activities.Add(this.parallelActivity1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.WhileCondition);
            this.WhileLoop.Condition = codecondition1;
            this.WhileLoop.Name = "WhileLoop";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.WhileLoop);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private DelayActivity delayActivity1;
        private CodeActivity Code4;
        private CodeActivity Code3;
        private CodeActivity Code2;
        private CodeActivity Code1;
        private SequenceActivity Sequence2;
        private SequenceActivity Sequence1;
        private ParallelActivity parallelActivity1;
        private WhileActivity WhileLoop;







    }
}
