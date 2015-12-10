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

namespace ReplicatorActivityDemo
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
            this.Code = new System.Workflow.Activities.CodeActivity();
            this.rep1 = new System.Workflow.Activities.ReplicatorActivity();
            // 
            // Code
            // 
            this.Code.Name = "Code";
            this.Code.ExecuteCode += new System.EventHandler(this.Code_ExecuteCode);
            activitybind1.Name = "Workflow1";
            activitybind1.Path = "ChildData";
            // 
            // rep1
            // 
            this.rep1.Activities.Add(this.Code);
            this.rep1.ExecutionType = System.Workflow.Activities.ExecutionType.Sequence;
            this.rep1.Name = "rep1";
            this.rep1.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // Workflow1
            // 
            this.Activities.Add(this.rep1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private ReplicatorActivity rep1;

        private CodeActivity Code;




    }
}
