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
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WorkflowConsoleApplication1
{
    partial class SubWorkflow
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
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.stateInitializationActivity1 = new System.Workflow.Activities.StateInitializationActivity();
            this.stateActivity1 = new System.Workflow.Activities.StateActivity();
            this.SubWorkflowInitialState = new System.Workflow.Activities.StateActivity();
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
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
            // stateInitializationActivity1
            // 
            this.stateInitializationActivity1.Activities.Add(this.codeActivity1);
            this.stateInitializationActivity1.Activities.Add(this.setStateActivity1);
            this.stateInitializationActivity1.Activities.Add(this.codeActivity2);
            this.stateInitializationActivity1.Name = "stateInitializationActivity1";
            // 
            // stateActivity1
            // 
            this.stateActivity1.Name = "stateActivity1";
            // 
            // SubWorkflowInitialState
            // 
            this.SubWorkflowInitialState.Activities.Add(this.stateInitializationActivity1);
            this.SubWorkflowInitialState.Name = "SubWorkflowInitialState";
            // 
            // SubWorkflow
            // 
            this.Activities.Add(this.SubWorkflowInitialState);
            this.Activities.Add(this.stateActivity1);
            this.CompletedStateName = "stateActivity1";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "SubWorkflowInitialState";
            this.Name = "SubWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private StateActivity stateActivity1;
        private SetStateActivity setStateActivity1;
        private CodeActivity codeActivity1;
        private StateInitializationActivity stateInitializationActivity1;
        private CodeActivity codeActivity2;
        private StateActivity SubWorkflowInitialState;












    }
}
