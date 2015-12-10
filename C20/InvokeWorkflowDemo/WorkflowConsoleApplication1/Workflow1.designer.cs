//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation Sample Code.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

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

namespace WorkflowConsoleApplication1
{
    partial class Workflow1
    {
		#region Designer generated code
        
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.setStateActivity3 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setStateActivity2 = new System.Workflow.Activities.SetStateActivity();
            this.invokeWorkflowActivity1 = new System.Workflow.Activities.InvokeWorkflowActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.stateInitializationActivity2 = new System.Workflow.Activities.StateInitializationActivity();
            this.stateInitializationActivity1 = new System.Workflow.Activities.StateInitializationActivity();
            this.stateActivity3 = new System.Workflow.Activities.StateActivity();
            this.stateActivity2 = new System.Workflow.Activities.StateActivity();
            this.stateActivity1 = new System.Workflow.Activities.StateActivity();
            this.Workflow1InitialState = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivity3
            // 
            this.setStateActivity3.Name = "setStateActivity3";
            this.setStateActivity3.TargetStateName = "stateActivity3";
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // handleExternalEventActivity1
            // 
            this.handleExternalEventActivity1.EventName = "InvokedWorkflowComplete";
            this.handleExternalEventActivity1.InterfaceType = typeof(WorkflowConsoleApplication1.ILocalService);
            this.handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            // 
            // setStateActivity2
            // 
            this.setStateActivity2.Name = "setStateActivity2";
            this.setStateActivity2.TargetStateName = "stateActivity2";
            // 
            // invokeWorkflowActivity1
            // 
            this.invokeWorkflowActivity1.Name = "invokeWorkflowActivity1";
            this.invokeWorkflowActivity1.TargetWorkflow = typeof(WorkflowConsoleApplication1.SubWorkflow);
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "stateActivity1";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.handleExternalEventActivity1);
            this.eventDrivenActivity1.Activities.Add(this.codeActivity2);
            this.eventDrivenActivity1.Activities.Add(this.setStateActivity3);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // stateInitializationActivity2
            // 
            this.stateInitializationActivity2.Activities.Add(this.invokeWorkflowActivity1);
            this.stateInitializationActivity2.Activities.Add(this.setStateActivity2);
            this.stateInitializationActivity2.Name = "stateInitializationActivity2";
            // 
            // stateInitializationActivity1
            // 
            this.stateInitializationActivity1.Activities.Add(this.codeActivity1);
            this.stateInitializationActivity1.Activities.Add(this.setStateActivity1);
            this.stateInitializationActivity1.Name = "stateInitializationActivity1";
            // 
            // stateActivity3
            // 
            this.stateActivity3.Name = "stateActivity3";
            // 
            // stateActivity2
            // 
            this.stateActivity2.Activities.Add(this.eventDrivenActivity1);
            this.stateActivity2.Name = "stateActivity2";
            // 
            // stateActivity1
            // 
            this.stateActivity1.Activities.Add(this.stateInitializationActivity2);
            this.stateActivity1.Name = "stateActivity1";
            // 
            // Workflow1InitialState
            // 
            this.Workflow1InitialState.Activities.Add(this.stateInitializationActivity1);
            this.Workflow1InitialState.Name = "Workflow1InitialState";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.Workflow1InitialState);
            this.Activities.Add(this.stateActivity1);
            this.Activities.Add(this.stateActivity2);
            this.Activities.Add(this.stateActivity3);
            this.CompletedStateName = "stateActivity3";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "Workflow1InitialState";
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity codeActivity1;
        private StateInitializationActivity stateInitializationActivity1;
        private InvokeWorkflowActivity invokeWorkflowActivity1;
        private SetStateActivity setStateActivity1;
        private StateInitializationActivity stateInitializationActivity2;
        private StateActivity stateActivity1;
        private SetStateActivity setStateActivity2;
        private StateActivity stateActivity2;
        private CodeActivity codeActivity2;
        private HandleExternalEventActivity handleExternalEventActivity1;
        private EventDrivenActivity eventDrivenActivity1;
        private SetStateActivity setStateActivity3;
        private StateActivity stateActivity3;
        private StateActivity Workflow1InitialState;



















    }
}
