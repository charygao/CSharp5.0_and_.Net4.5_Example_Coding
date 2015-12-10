using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SimpleStateMachine
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
            this.setStateActivity2 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.delayActivity2 = new System.Workflow.Activities.DelayActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.CompleteState = new System.Workflow.Activities.StateActivity();
            this.State1 = new System.Workflow.Activities.StateActivity();
            this.StartState = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivity2
            // 
            this.setStateActivity2.Name = "setStateActivity2";
            this.setStateActivity2.TargetStateName = "CompleteState";
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // delayActivity2
            // 
            this.delayActivity2.Name = "delayActivity2";
            this.delayActivity2.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "State1";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.delayActivity2);
            this.eventDrivenActivity2.Activities.Add(this.codeActivity2);
            this.eventDrivenActivity2.Activities.Add(this.setStateActivity2);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.delayActivity1);
            this.eventDrivenActivity1.Activities.Add(this.codeActivity1);
            this.eventDrivenActivity1.Activities.Add(this.setStateActivity1);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // CompleteState
            // 
            this.CompleteState.Name = "CompleteState";
            // 
            // State1
            // 
            this.State1.Activities.Add(this.eventDrivenActivity2);
            this.State1.Name = "State1";
            // 
            // StartState
            // 
            this.StartState.Activities.Add(this.eventDrivenActivity1);
            this.StartState.Name = "StartState";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.StartState);
            this.Activities.Add(this.State1);
            this.Activities.Add(this.CompleteState);
            this.CompletedStateName = "CompleteState";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "StartState";
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private EventDrivenActivity eventDrivenActivity1;

        private CodeActivity codeActivity1;

        private DelayActivity delayActivity1;

        private SetStateActivity setStateActivity1;

        private StateActivity State1;

        private SetStateActivity setStateActivity2;

        private CodeActivity codeActivity2;

        private DelayActivity delayActivity2;

        private EventDrivenActivity eventDrivenActivity2;

        private StateActivity CompleteState;

        private StateActivity StartState;















    }
}
