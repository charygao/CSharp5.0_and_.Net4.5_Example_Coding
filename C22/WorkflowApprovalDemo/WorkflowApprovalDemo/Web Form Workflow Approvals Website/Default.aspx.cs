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
using System.Threading;
using System.Workflow;
using System.Workflow.Runtime;
using System.Collections.ObjectModel;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //根据用户的角色判断用户是否有权限创建工作条目
            this.approvalRequestLinkButton.Visible = 
                WorkflowUserActivityInvestigator.Singleton.
                CanCurrentUserWorkOnFirstUserActivityForWorkflow(typeof(Workflows.ApprovedWorkItemWorkflow));
            //获取消息字符串
            string messageString = QueryStringHelper.GetString(this.Page, Global.QuerystringKeys.Message, false);
            if (!String.IsNullOrEmpty(messageString.Trim()))
                JavascriptHelper.Alert(this.Page, messageString, "defaultMessage");
        }
    }

    private Controls_TaskList GetTaskList(string name)
    {
        return this.loginView.Controls[0].FindControl(name) as Controls_TaskList;
    }

    private Controls_TaskList UsersTaskList
    {
        get
        {
            return this.GetTaskList("usersTaskList");
        }
    }

    private Controls_TaskList RolesTaskList
    {
        get
        {
            return this.GetTaskList("rolesTaskList");
        }
    }

    protected void approvalRequestLinkButton_Click(object sender, EventArgs e)
    {
        WorkflowInstance instance = 
            UserActivitiesHelper.Runtime.CreateWorkflow(typeof(Workflows.ApprovedWorkItemWorkflow));
        instance.Start();
        //因为为WorkflowRuntime配置了ManualWorkflowSchedulerService以代替默认
        //的DefaultWorkflowSchedulerSerivce
        //因此需要手动的告之工作流实例让其进行处理，使用这种方式开发人员可以控制执行的线程。
        //在一个受限制的线程的环境中
        //这是非常重要的，比如在IIS中的ASP.NET，这种方式也让开发人员很容易的在工作流进度和UI之间保持同步。
        UserActivitiesHelper.SchedulerService.RunWorkflow(instance.InstanceId);
        //使用TrackingHelper获取最近一次保存的跟踪记录
        TrackingDataSet.UserActivityWorkItemTrackingRow latestTrackingRecord = 
            TrackingHelper.GetYoungestTrackingRecordForWorkflow(instance.InstanceId);
        //重定向到编辑的连接页面。
        Response.Redirect(QueryStringHelper.CreateEditTaskLink(latestTrackingRecord.ActivityGuid,
            latestTrackingRecord.ActivityTypeName,
            instance.InstanceId));
    }

    protected void refreshTaskListsLinkButton_Click(object sender, EventArgs e)
    {
        this.RefreshTaskLists();
    }

    private void RefreshTaskLists()
    {
        if (User.Identity.IsAuthenticated)
        {
            Controls_TaskList taskList = this.UsersTaskList;

            if (taskList != null)
            {
                taskList.Refresh();
            }

            taskList = this.RolesTaskList;

            if (taskList != null)
            {
                taskList.Refresh();
            }
        }
    }
}
