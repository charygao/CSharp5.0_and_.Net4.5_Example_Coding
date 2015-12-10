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
using Workflows;

public partial class Authenticated_EnterApprovalRequestTask : ApprovalRequestBasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
            //如果活动没有被完成，则返回
            if (!((MasterPages_WorkflowTask)this.Master).ActivityIsIncomplete())
                return;
			//设置母版页的UserActivityType
			((MasterPages_WorkflowTask)this.Master).UserActivityType = UserActivityType.EnterApprovalRequest;
			//从会话中清除老的数据
			this.ClearData();
			//设置任务名称
			((MasterPages_WorkflowTask)this.Master).TaskName = "输入审核请求";
			((MasterPages_WorkflowTask)this.Master).TaskTip = "请在下面输入审核请求的详细信息";
            //加载任务数据
			this.LoadData();
		}
	}    
	private void LoadData()
	{
		WorkItemsDataSet dataSet = this.GetData();
		WorkItemsDataSet.WorkItemsRow dataRow = null;
        //从WorkItemsDataSet中加载工作条目数据，如果不存在数据，则新建一条数据
		if (dataSet.WorkItems.Rows.Count.Equals(0))
		{
			dataRow = dataSet.WorkItems.NewWorkItemsRow();
			dataRow.WorkItemType = dataSet.WorkTypes[0].WorkTypeName;
			dataRow.DateRequested = DateTime.Now;
			dataRow.Approved = false;
			dataRow.WorkItemName =
					dataRow.Description =
					dataRow.Reason =
					dataRow.FundingCostCenter =
					dataRow.AreaAffected =
					dataRow.Result = string.Empty;
            //添加到数据集中
			dataSet.WorkItems.AddWorkItemsRow(dataRow);
		}
		else
		{
			dataRow = dataSet.WorkItems[0];
		}
        //将数据绑定到FieldControl控件中
		this.nameFieldControl.DataSource =
				this.descriptionFieldControl.DataSource =
				this.typeOfWorkFieldControl.DataSource =
				this.reasonFieldControl.DataSource =
				this.dateRequestedFieldControl.DataSource =
				this.fundingFieldControl.DataSource =
				this.areaFieldControl.DataSource = dataRow;
        //指定搜寻字段的数据源
		this.typeOfWorkFieldControl.OptionDataSource = dataSet.WorkTypes;
	}
}
