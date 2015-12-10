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
	/// �������������ƣ�Ҫƥ�����ݿ��е�UserActivityTypes���еļ�¼
	/// </summary>
	public enum UserActivityType { EnterApprovalRequest, ManagerApproval, EnterResolution }
	/// <summary>
	/// �������û���ɫ
	/// </summary>
	public enum UserRole { Administrator, Manager, WorkItemRequester, WorkItemResolver }
	/// <summary>
    /// �����ڹ��������û�����֮�侭��UserActivity����ͨ��
	/// </summary>
	public interface IUserActivityService
	{
		/// <summary>
		///�����ݿ��д���һ���û����¼
		/// </summary>
		/// <param name="workflowGuid">����ڵĹ�������Guid����</param>
		/// <param name="activityGuid">���ȫ��Ψһ��ʶ��</param>
		/// <param name="type">�������</param>
		/// <param name="requiredRole">���Ҫ����û���ɫ</param>
		/// <param name="description">�����</param>
		/// <param name="activityData">���ʼ����</param>
		void CreateUserActivity(Guid workflowGuid, Guid activityGuid, 
            UserActivityType type, UserRole requiredRole, string description, DataSet activityData);
		/// <summary>
		/// ȡ��һ���
		/// </summary>
		/// <param name="activityGuid">Ҫȡ���Ļ��Guid����</param>
		void CancelUserActivity(Guid activityGuid);
	}
	/// <summary>
	/// ��һ���û��ִ�����ʱ�Ĳ���
	/// </summary>
	[Serializable]
	public class UserActivityCompletedEventArgs : EventArgs
	{
		private DataSet activityData;
		/// <summary>
		/// ����һ���µĲ���ʵ��
		/// </summary>
		/// <param name="activityData">������Ŀ���ݼ�</param>
		public UserActivityCompletedEventArgs(DataSet activityData)
		{
			this.activityData = activityData;
		}
		/// <summary>
		///������Ŀ���ݼ�����
		/// </summary>
		public DataSet ActivityData
		{
			get { return activityData; }
		}
	}
}
