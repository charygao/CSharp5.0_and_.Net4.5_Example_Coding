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
        //定义描述属性名和ActivityGuid属性名称的常量
        public const string DescriptionPropertyName = "QualifiedName", ActivityGuidPropertyName = "ActivityGuid";
        //定义一个保存工作流运行时引擎的静态字段
        private static WorkflowRuntime runtime;
		/// <summary>
		/// 提供访问和获取工作流运行时引擎的公共静态属性
		/// </summary>
		public static WorkflowRuntime Runtime
		{
			get { return runtime; }
			set { runtime = value; }
		}
        //定义静态的IUserActivityService属性
		private static IUserActivityService userActivityService;
		/// <summary>
		/// 提供访问和获取IUserActivityService实现对象的静态属性
		/// </summary>
		public static IUserActivityService UserActivityService
		{
			get { return userActivityService; }
			set { userActivityService = value; }
		}
        //定义工作流队列名称的静态属性
		public static string MakeQueueName(Guid activityGuid)
		{
			return "User Activity: " + activityGuid.ToString();
		}
	}
}
