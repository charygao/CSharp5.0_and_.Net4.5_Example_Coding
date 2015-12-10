using System;
using System.Workflow.Activities;
using System.Workflow.Runtime;
namespace EventHandlingScopeActivityDemo
{
    public class ScopeImpl:IScope
    {
        //定义一个局部变量用于保存工作流的实例ID
        private Guid _instanceId;
        public void Started()
        {
            //当工作流启动时，首先保存的是工作流实例的Id号
            _instanceId = WorkflowEnvironment.WorkflowInstanceId;
        }
        public event EventHandler<ExternalDataEventArgs> EventOne;
        public event EventHandler<ExternalDataEventArgs> EventTwo;
        public event EventHandler<ExternalDataEventArgs> EventStop;
        public void OnEventOne()
        {
            if (EventOne != null)
            {
                EventOne(null, new ExternalDataEventArgs(_instanceId));
            }
        }
        public void OnEventTwo()
        {
            if (EventTwo != null)
            {
                EventTwo(null, new ExternalDataEventArgs(_instanceId));
            }
        }
        public void OnEventStop()
        {
            if (EventStop != null)
            {
                EventStop(null, new ExternalDataEventArgs(_instanceId));
            }
        }
    }
}
