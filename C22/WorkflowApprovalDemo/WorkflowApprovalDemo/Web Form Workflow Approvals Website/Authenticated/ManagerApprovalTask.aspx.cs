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

public partial class Authenticated_ManagerApprovalTask : ApprovalRequestBasePage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
            //Ensure task has not been completed
            if (!((MasterPages_WorkflowTask)this.Master).ActivityIsIncomplete())
                return;

            //Set the user activity type of the master page
			((MasterPages_WorkflowTask)this.Master).UserActivityType = UserActivityType.ManagerApproval;

			//Clear any old datasets from the session
			this.ClearData();

			//Set the task name
			((MasterPages_WorkflowTask)this.Master).TaskName = "经理批核";
			((MasterPages_WorkflowTask)this.Master).TaskTip = "请批核或拒收该请求";

			this.LoadData();
		}
	}

	private void LoadData()
	{
		WorkItemsDataSet dataSet = this.GetData();
		WorkItemsDataSet.WorkItemsRow dataRow = null;

		dataRow = dataSet.WorkItems[0];

		this.nameFieldControl.DataSource =
				this.descriptionFieldControl.DataSource =
				this.typeOfWorkFieldControl.DataSource =
				this.reasonFieldControl.DataSource =
				this.dateRequestedFieldControl.DataSource =
				this.fundingFieldControl.DataSource =
				this.areaFieldControl.DataSource =
				this.approvedFieldControl.DataSource = dataRow;

		this.typeOfWorkFieldControl.OptionDataSource = dataSet.WorkTypes;
	}
}
