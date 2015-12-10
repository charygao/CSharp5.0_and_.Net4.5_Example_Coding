using System;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;

namespace SuspendAndTerminate
{
    public sealed partial class SuspendAndTerminateWorkflow 
    {
        #region Designer generated code
        
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.终止工作流 = new System.Workflow.ComponentModel.TerminateActivity();
            this.控制台消息 = new System.Workflow.Activities.CodeActivity();
            this.挂起工作流 = new System.Workflow.ComponentModel.SuspendActivity();
            // 
            // 终止工作流
            // 
            this.终止工作流.Name = "终止工作流";
            // 
            // 控制台消息
            // 
            this.控制台消息.Name = "控制台消息";
            this.控制台消息.ExecuteCode += new System.EventHandler(this.OnConsoleMessage);
            // 
            // 挂起工作流
            // 
            this.挂起工作流.Name = "挂起工作流";
            // 
            // SuspendAndTerminateWorkflow
            // 
            this.Activities.Add(this.挂起工作流);
            this.Activities.Add(this.控制台消息);
            this.Activities.Add(this.终止工作流);
            this.Name = "SuspendAndTerminateWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private SuspendActivity 挂起工作流;
        private CodeActivity 控制台消息;
        private TerminateActivity 终止工作流;



    }
}
