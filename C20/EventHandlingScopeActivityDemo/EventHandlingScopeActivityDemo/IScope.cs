using System;
using System.Workflow.Activities;
namespace EventHandlingScopeActivityDemo
{
    [ExternalDataExchange]
    public interface IScope
    {
        /// <summary>
        /// 通知宿主工作流开始运行的方法
        /// </summary>
        void Started();
        //定义三个事件
        event EventHandler<ExternalDataEventArgs> EventOne;
        event EventHandler<ExternalDataEventArgs> EventTwo;
        event EventHandler<ExternalDataEventArgs> EventStop;
    }
}
