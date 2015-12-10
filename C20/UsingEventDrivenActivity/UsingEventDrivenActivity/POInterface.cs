using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;

namespace UsingEventDrivenActivity
{
    [Serializable]
    public class OrderEventArgs : ExternalDataEventArgs
    {
        private string id;
        //构造函数，在初始化时传入id号。
        public OrderEventArgs(Guid instanceId, string id)
            : base(instanceId)
        {
            this.id = id;
        }
        // 获取和设置id值，由工作流设置并传递。
        public string OrderId
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
    }
    //使用ExternalDataExchangeAttribute将IOrderService接口指定为一个本地服务接口
    [ExternalDataExchange]
    public interface IOrderService
    {
        void CreateOrder(string id);
        //定义批核和拒收事件
        event EventHandler<OrderEventArgs> OrderApproved;
        event EventHandler<OrderEventArgs> OrderRejected;
    }
}
