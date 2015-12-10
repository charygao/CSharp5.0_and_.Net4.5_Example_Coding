using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace UsingEventDrivenActivity
{
	partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            this.超时代码CodeActivity = new System.Workflow.Activities.CodeActivity();
            this.延时DelayActivity = new System.Workflow.Activities.DelayActivity();
            this.拒收采购单HandleExternalEventActivity = new System.Workflow.Activities.HandleExternalEventActivity();
            this.批核采购单HandleExternalEventActivity = new System.Workflow.Activities.HandleExternalEventActivity();
            this.eventDrivenActivity3 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.等待批核或拒绝ListenActivity = new System.Workflow.Activities.ListenActivity();
            this.创建采购订单 = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // 超时代码CodeActivity
            // 
            this.超时代码CodeActivity.Name = "超时代码CodeActivity";
            this.超时代码CodeActivity.ExecuteCode += new System.EventHandler(this.OnTimeout);
            // 
            // 延时DelayActivity
            // 
            this.延时DelayActivity.Name = "延时DelayActivity";
            this.延时DelayActivity.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // 
            // 拒收采购单HandleExternalEventActivity
            // 
            this.拒收采购单HandleExternalEventActivity.EventName = "OrderRejected";
            this.拒收采购单HandleExternalEventActivity.InterfaceType = typeof(UsingEventDrivenActivity.IOrderService);
            this.拒收采购单HandleExternalEventActivity.Name = "拒收采购单HandleExternalEventActivity";
            this.拒收采购单HandleExternalEventActivity.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnRejected);
            // 
            // 批核采购单HandleExternalEventActivity
            // 
            this.批核采购单HandleExternalEventActivity.EventName = "OrderApproved";
            this.批核采购单HandleExternalEventActivity.InterfaceType = typeof(UsingEventDrivenActivity.IOrderService);
            this.批核采购单HandleExternalEventActivity.Name = "批核采购单HandleExternalEventActivity";
            this.批核采购单HandleExternalEventActivity.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.OnApprovePO);
            // 
            // eventDrivenActivity3
            // 
            this.eventDrivenActivity3.Activities.Add(this.延时DelayActivity);
            this.eventDrivenActivity3.Activities.Add(this.超时代码CodeActivity);
            this.eventDrivenActivity3.Name = "eventDrivenActivity3";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.拒收采购单HandleExternalEventActivity);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.批核采购单HandleExternalEventActivity);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // 等待批核或拒绝ListenActivity
            // 
            this.等待批核或拒绝ListenActivity.Activities.Add(this.eventDrivenActivity1);
            this.等待批核或拒绝ListenActivity.Activities.Add(this.eventDrivenActivity2);
            this.等待批核或拒绝ListenActivity.Activities.Add(this.eventDrivenActivity3);
            this.等待批核或拒绝ListenActivity.Name = "等待批核或拒绝ListenActivity";
            // 
            // 创建采购订单
            // 
            this.创建采购订单.InterfaceType = typeof(UsingEventDrivenActivity.IOrderService);
            this.创建采购订单.MethodName = "CreateOrder";
            this.创建采购订单.Name = "创建采购订单";
            this.创建采购订单.MethodInvoking += new System.EventHandler(this.OnBeforeCreateOrder);
            // 
            // Workflow1
            // 
            this.Activities.Add(this.创建采购订单);
            this.Activities.Add(this.等待批核或拒绝ListenActivity);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private HandleExternalEventActivity 拒收采购单HandleExternalEventActivity;
        private HandleExternalEventActivity 批核采购单HandleExternalEventActivity;
        private EventDrivenActivity eventDrivenActivity3;
        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity 等待批核或拒绝ListenActivity;
        private CodeActivity 超时代码CodeActivity;
        private DelayActivity 延时DelayActivity;
        private CallExternalMethodActivity 创建采购订单;








    }
}
