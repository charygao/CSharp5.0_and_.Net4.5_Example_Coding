//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Workflows
{
	public sealed partial class ApprovedWorkItemWorkflow : SequentialWorkflowActivity
	{
		public ApprovedWorkItemWorkflow()
		{
			InitializeComponent();
		}
        //定义一个表示此工作流实例正在执行的工作流条目
		public static DependencyProperty WorkItemsProperty = 
            System.Workflow.ComponentModel.DependencyProperty.Register("WorkItems", 
            typeof(WorkItemsDataSet), typeof(ApprovedWorkItemWorkflow));
		[Description("本工作流的工作条目.")]
		[Category("Data")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public WorkItemsDataSet WorkItems
		{
			get
			{
				return ((WorkItemsDataSet)(base.GetValue(ApprovedWorkItemWorkflow.WorkItemsProperty)));
			}
			set
			{
				base.SetValue(ApprovedWorkItemWorkflow.WorkItemsProperty, value);
			}
		}
        //CodeActivity的执行代码，该代码会将WorkItems属性中所有的工作流条目的Approved属性设置为false
		private void SetWorkItemsToDeclined_ExecuteCode(object sender, EventArgs e)
		{
			foreach (WorkItemsDataSet.WorkItemsRow workItem in WorkItems.WorkItems.Rows)
				workItem.Approved = false;
		}
	}
}
