using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Runtime;
using System.Threading;

namespace UsingEventDrivenActivity
{
    class POInterfaceImpl: IOrderService
    {
        string orderId;
        public WorkflowInstance instanceId;
        // 由工作流调用，传入一个订单的id号
        public void CreateOrder(string Id)
        {
            Console.WriteLine("\n采购订单己经被创建");
            orderId = Id;
        }
        //由宿主调用，触发批核事件
        public void ApproveOrder()
        {
            EventHandler<OrderEventArgs> orderApproved = this.OrderApproved;
            if (orderApproved != null)
                orderApproved(null, new OrderEventArgs(instanceId.InstanceId, orderId));
        }
        //由宿主调用，触发拒收事件 
        public void RejectOrder()
        {
            EventHandler<OrderEventArgs> orderRejected = this.OrderRejected;
            if (orderRejected != null)
                orderRejected(null, new OrderEventArgs(instanceId.InstanceId, orderId));
        }
        //在工作流内部经由HandleExternalEventActivity调用的事件        
        public event EventHandler<OrderEventArgs> OrderApproved;
        public event EventHandler<OrderEventArgs> OrderRejected;
    }
}
