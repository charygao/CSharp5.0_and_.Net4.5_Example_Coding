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
using System.Collections.Generic;
using System.Text;
using System.Workflow.Runtime;

namespace Workflows
{
	public class Helper
	{
        //����������������ActivityGuid�������Ƶĳ���
        public const string DescriptionPropertyName = "QualifiedName", ActivityGuidPropertyName = "ActivityGuid";
        //����һ�����湤��������ʱ����ľ�̬�ֶ�
        private static WorkflowRuntime runtime;
		/// <summary>
		/// �ṩ���ʺͻ�ȡ����������ʱ����Ĺ�����̬����
		/// </summary>
		public static WorkflowRuntime Runtime
		{
			get { return runtime; }
			set { runtime = value; }
		}
        //���徲̬��IUserActivityService����
		private static IUserActivityService userActivityService;
		/// <summary>
		/// �ṩ���ʺͻ�ȡIUserActivityServiceʵ�ֶ���ľ�̬����
		/// </summary>
		public static IUserActivityService UserActivityService
		{
			get { return userActivityService; }
			set { userActivityService = value; }
		}
        //���幤�����������Ƶľ�̬����
		public static string MakeQueueName(Guid activityGuid)
		{
			return "User Activity: " + activityGuid.ToString();
		}
	}
}
