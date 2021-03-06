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
using UserActivitiesDataSetTableAdapters;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Runtime.Hosting;
using System.Configuration;
using System.Web.Security;
//添加如下命名空间的引用
using Workflows;
using System.Workflow.Runtime.Tracking;
using System.Data.SqlClient;
using System.Collections.Generic;
using Workflows.Tracking;

public static class UserActivitiesHelper
{
    private static WorkflowRuntime runtime;
    /// <summary>
    /// 返回工作流运行时引擎
    /// </summary>
    public static WorkflowRuntime Runtime
    {
        get { return runtime; }
    }
    /// <summary>
    /// 工作流运行时引擎的计划执行服务，被用于运行工作流实例直到工作流实例空闲或完成
    /// </summary>
    public static ManualWorkflowSchedulerService SchedulerService
    {
        get { return runtime.GetService<ManualWorkflowSchedulerService>(); }
    }
    private static Guid applicationGuid;
    /// <summary>
    /// ASP.NET应用程序标识符
    /// </summary>
    public static Guid ApplicationGuid
    {
        get { return applicationGuid; }
    }
    /// <summary>
    /// 初始化工作流运行时引擎，获以应用程序标识符
    /// </summary>
    static UserActivitiesHelper()
    {
        //获取数据库连接字符串
        string connectionString =
            ConfigurationManager.ConnectionStrings["ApprovalsConnectionString"].ConnectionString;
        /* 每次服务开始时清除数据库数据 */
        ClearDataBase(connectionString);
        //创建一个新的工作流运行时引擎
        runtime = new WorkflowRuntime();
        Helper.Runtime = runtime;
        Helper.UserActivityService = UserActivityService.Singleton;
        //添加工作流运行时引擎服务
        runtime.AddService(new UserActivityTrackingService());
        runtime.AddService(new SqlWorkflowPersistenceService(connectionString));
        runtime.AddService(new SharedConnectionWorkflowCommitWorkBatchService(connectionString));
        runtime.AddService(new ManualWorkflowSchedulerService(true));
        //开始工作流运行时引擎
        runtime.StartRuntime();
        //获取应用程序的Guid
        using (ApplicationGuidAdapter applicationGuidAdapter = new ApplicationGuidAdapter())
            applicationGuid = (Guid)applicationGuidAdapter.GetApplicationGuid(Membership.ApplicationName);
    }
    /// <summary>
    /// 清除数据库数据
    /// </summary>
    /// <param name="connectionString"></param>
    private static void ClearDataBase(string connectionString)
    {
        SqlCommand clearDB = new SqlCommand("AllClearDatabase", 
            new SqlConnection(connectionString));
        clearDB.CommandType = CommandType.StoredProcedure;
        clearDB.Connection.Open();
        clearDB.ExecuteNonQuery();
        clearDB.Connection.Close();
    }

    /// <summary>
    /// 创建一个UserActivitiesDataSet，使用角色、用户和用户所属的角色以及活动类型填充该DataSet
    /// </summary>
    /// <returns>一个新的己填充的DataSet</returns>
    public static UserActivitiesDataSet GetDataSetWithReferenceData()
    {
        UserActivitiesDataSet dataSet = new UserActivitiesDataSet();

        using (aspnet_RolesTableAdapter rolesAdapter = new aspnet_RolesTableAdapter())
        using (aspnet_UsersTableAdapter usersAdapter = new aspnet_UsersTableAdapter())
        using (aspnet_UsersInRolesTableAdapter usersInRolesAdapter = new aspnet_UsersInRolesTableAdapter())
        using (UserActivityTypesTableAdapter activityTypesAdapter = new UserActivityTypesTableAdapter())
        {
            rolesAdapter.Fill(dataSet.aspnet_Roles);
            usersAdapter.Fill(dataSet.aspnet_Users);
            usersInRolesAdapter.Fill(dataSet.aspnet_UsersInRoles);
            activityTypesAdapter.Fill(dataSet.UserActivityTypes);
        }

        return dataSet;
    }

    /// <summary>
    /// 确定指定的用户角色是否可以运行工作流活动
    /// </summary>
    /// <param name="activityGuid">工作流活动</param>
    /// <param name="userGuid">用户ID</param>
    public static bool CanUserWorkOnActivity(Guid activityGuid, Guid userGuid)
    {
        using (UserActivitiesTableAdapter activitiesAdapter = new UserActivitiesTableAdapter())
            return (int)activitiesAdapter.CanUserWorkOnActivity(activityGuid.ToString(), userGuid) > 0;
    }

    /// <summary>
    /// 确定当前用户是否被分配了一个活动
    /// </summary>
    public static bool UserIsAssignedToActivity(Guid activityGuid, Guid userGuid)
    {
        UserActivitiesDataSet.UserActivityAssignmentsDataTable assignments;
        using (UserActivityAssignmentsTableAdapter assignmentsAdapter = new UserActivityAssignmentsTableAdapter())
            assignments = new UserActivityAssignmentsTableAdapter().GetDataByActivityGuid(activityGuid.ToString());

        DataRow[] orderedAssignments = assignments.Select(string.Empty, assignments.DateAssignedColumn.ColumnName + " DESC");

        return orderedAssignments.Length > 0 && userGuid == (Guid)orderedAssignments[0][assignments.AssignedUserColumn];
    }

    /// <summary>
    /// 确定活动是否执行完成
    /// </summary>
    /// <param name="activityGuid">The activity.</param>
    /// <returns>true if the activity is not complete.</returns>
    public static bool ActivityIsIncomplete(Guid activityGuid)
    {
        using (UserActivitiesTableAdapter activitiesAdapter = new UserActivitiesTableAdapter())
            return (int)activitiesAdapter.IsActivityIncomplete(activityGuid.ToString()) > 0;
    }
}
