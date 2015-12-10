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
//������������ռ������
using Workflows;
using System.Workflow.Runtime.Tracking;
using System.Data.SqlClient;
using System.Collections.Generic;
using Workflows.Tracking;

public static class UserActivitiesHelper
{
    private static WorkflowRuntime runtime;
    /// <summary>
    /// ���ع���������ʱ����
    /// </summary>
    public static WorkflowRuntime Runtime
    {
        get { return runtime; }
    }
    /// <summary>
    /// ����������ʱ����ļƻ�ִ�з��񣬱��������й�����ʵ��ֱ��������ʵ�����л����
    /// </summary>
    public static ManualWorkflowSchedulerService SchedulerService
    {
        get { return runtime.GetService<ManualWorkflowSchedulerService>(); }
    }
    private static Guid applicationGuid;
    /// <summary>
    /// ASP.NETӦ�ó����ʶ��
    /// </summary>
    public static Guid ApplicationGuid
    {
        get { return applicationGuid; }
    }
    /// <summary>
    /// ��ʼ������������ʱ���棬����Ӧ�ó����ʶ��
    /// </summary>
    static UserActivitiesHelper()
    {
        //��ȡ���ݿ������ַ���
        string connectionString =
            ConfigurationManager.ConnectionStrings["ApprovalsConnectionString"].ConnectionString;
        /* ÿ�η���ʼʱ������ݿ����� */
        ClearDataBase(connectionString);
        //����һ���µĹ���������ʱ����
        runtime = new WorkflowRuntime();
        Helper.Runtime = runtime;
        Helper.UserActivityService = UserActivityService.Singleton;
        //��ӹ���������ʱ�������
        runtime.AddService(new UserActivityTrackingService());
        runtime.AddService(new SqlWorkflowPersistenceService(connectionString));
        runtime.AddService(new SharedConnectionWorkflowCommitWorkBatchService(connectionString));
        runtime.AddService(new ManualWorkflowSchedulerService(true));
        //��ʼ����������ʱ����
        runtime.StartRuntime();
        //��ȡӦ�ó����Guid
        using (ApplicationGuidAdapter applicationGuidAdapter = new ApplicationGuidAdapter())
            applicationGuid = (Guid)applicationGuidAdapter.GetApplicationGuid(Membership.ApplicationName);
    }
    /// <summary>
    /// ������ݿ�����
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
    /// ����һ��UserActivitiesDataSet��ʹ�ý�ɫ���û����û������Ľ�ɫ�Լ����������DataSet
    /// </summary>
    /// <returns>һ���µļ�����DataSet</returns>
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
    /// ȷ��ָ�����û���ɫ�Ƿ�������й������
    /// </summary>
    /// <param name="activityGuid">�������</param>
    /// <param name="userGuid">�û�ID</param>
    public static bool CanUserWorkOnActivity(Guid activityGuid, Guid userGuid)
    {
        using (UserActivitiesTableAdapter activitiesAdapter = new UserActivitiesTableAdapter())
            return (int)activitiesAdapter.CanUserWorkOnActivity(activityGuid.ToString(), userGuid) > 0;
    }

    /// <summary>
    /// ȷ����ǰ�û��Ƿ񱻷�����һ���
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
    /// ȷ����Ƿ�ִ�����
    /// </summary>
    /// <param name="activityGuid">The activity.</param>
    /// <returns>true if the activity is not complete.</returns>
    public static bool ActivityIsIncomplete(Guid activityGuid)
    {
        using (UserActivitiesTableAdapter activitiesAdapter = new UserActivitiesTableAdapter())
            return (int)activitiesAdapter.IsActivityIncomplete(activityGuid.ToString()) > 0;
    }
}
