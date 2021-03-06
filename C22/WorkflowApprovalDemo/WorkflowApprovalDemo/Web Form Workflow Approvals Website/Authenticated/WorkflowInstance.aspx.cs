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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Authenticated_WorkflowInstance : System.Web.UI.Page
{
	/// <summary>
	/// Name of the current activity that will be highlighted by the designer
	/// </summary>
	protected string activityName = "";
	/// <summary>
	/// Typename for the workflow that gets loaded by the designer
	/// </summary>
	protected string workflowTypeName = "Workflows.ApprovedWorkItemWorkflow,Workflows";

	protected void Page_Load(object sender, EventArgs e)
	{
        TrackingDataSet.UserActivityWorkItemTrackingRow youngestTrackingRow = TrackingHelper.GetYoungestTrackingRecordForWorkflow(QueryStringHelper.GetWorkflowGuid(this));
        activityName = youngestTrackingRow.ActivityName;
        ClientScript.RegisterStartupScript(typeof(string), "Focus Window", @"<script language=JavaScript>window.focus();</script>");
	}
}
