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
            //����û�б���ɣ��򷵻�
            if (!((MasterPages_WorkflowTask)this.Master).ActivityIsIncomplete())
                return;
			//����ĸ��ҳ��UserActivityType
			((MasterPages_WorkflowTask)this.Master).UserActivityType = UserActivityType.EnterApprovalRequest;
			//�ӻỰ������ϵ�����
			this.ClearData();
			//������������
			((MasterPages_WorkflowTask)this.Master).TaskName = "�����������";
			((MasterPages_WorkflowTask)this.Master).TaskTip = "����������������������ϸ��Ϣ";
            //������������
			this.LoadData();
		}
	}    
	private void LoadData()
	{
		WorkItemsDataSet dataSet = this.GetData();
		WorkItemsDataSet.WorkItemsRow dataRow = null;
        //��WorkItemsDataSet�м��ع�����Ŀ���ݣ�������������ݣ����½�һ������
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
            //��ӵ����ݼ���
			dataSet.WorkItems.AddWorkItemsRow(dataRow);
		}
		else
		{
			dataRow = dataSet.WorkItems[0];
		}
        //�����ݰ󶨵�FieldControl�ؼ���
		this.nameFieldControl.DataSource =
				this.descriptionFieldControl.DataSource =
				this.typeOfWorkFieldControl.DataSource =
				this.reasonFieldControl.DataSource =
				this.dateRequestedFieldControl.DataSource =
				this.fundingFieldControl.DataSource =
				this.areaFieldControl.DataSource = dataRow;
        //ָ����Ѱ�ֶε�����Դ
		this.typeOfWorkFieldControl.OptionDataSource = dataSet.WorkTypes;
	}
}
