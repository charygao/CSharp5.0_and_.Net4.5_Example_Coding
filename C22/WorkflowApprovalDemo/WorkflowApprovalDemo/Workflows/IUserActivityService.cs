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
using System.Workflow.Activities;
using System.Data;
using System.Workflow.ComponentModel;

namespace Workflows
{
	/// <summary>
	/// 工作流类型名称，要匹配数据库中的UserActivityTypes表中的记录
	/// </summary>
	public enum UserActivityType { EnterApprovalRequest, ManagerApproval, EnterResolution }
	/// <summary>
	/// 工作流用户角色
	/// </summary>
	public enum UserRole { Administrator, Manager, WorkItemRequester, WorkItemResolver }
	/// <summary>
    /// 允许在工作流和用户任务之间经由UserActivity进行通信
	/// </summary>
	public interface IUserActivityService
	{
		/// <summary>
		///在数据库中创建一个用户活动记录
		/// </summary>
		/// <param name="workflowGuid">活动所在的工作流的Guid编码</param>
		/// <param name="activityGuid">活动的全局唯一标识符</param>
		/// <param name="type">活动的类型</param>
		/// <param name="requiredRole">活动所要求的用户角色</param>
		/// <param name="description">活动描述</param>
		/// <param name="activityData">活动初始数据</param>
		void CreateUserActivity(Guid workflowGuid, Guid activityGuid, 
            UserActivityType type, UserRole requiredRole, string description, DataSet activityData);
		/// <summary>
		/// 取消一个活动
		/// </summary>
		/// <param name="activityGuid">要取消的活动的Guid编码</param>
		void CancelUserActivity(Guid activityGuid);
	}
	/// <summary>
	/// 当一个用户活动执行完成时的参数
	/// </summary>
	[Serializable]
	public class UserActivityCompletedEventArgs : EventArgs
	{
		private DataSet activityData;
		/// <summary>
		/// 构造一个新的参数实例
		/// </summary>
		/// <param name="activityData">工作条目数据集</param>
		public UserActivityCompletedEventArgs(DataSet activityData)
		{
			this.activityData = activityData;
		}
		/// <summary>
		///工作条目数据集属性
		/// </summary>
		public DataSet ActivityData
		{
			get { return activityData; }
		}
	}
}
