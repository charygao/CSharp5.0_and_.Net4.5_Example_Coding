using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace WCF.Third
{
    /// <summary>
    /// 事件类型的定义
    /// </summary>
    public enum EventType
    {
        Event1 = 1,
        Event2 = 2,
        Event3 = 3
    }
    /// <summary>
    /// 回调契约，实现了事件的触发
    /// </summary>
    public interface IEvents
    {
        //事件1的触发操作
        [OperationContract(IsOneWay = true)]
        void OnEvent1();
        //事件2的触发操作
        [OperationContract(IsOneWay = true)]
        void OnEvent2(int arg);
        //事件3的触发操作
        [OperationContract(IsOneWay = true)]
        void OnEvent3(String arg);
    }
    [ServiceContract(CallbackContract = typeof(IEvents))]
    public interface IEventPublisher
    {
        //订阅事件的操作
        [OperationContract]
        void Subscribe(EventType events);
        //取消订阅事件的操作
        [OperationContract]
        void Unsubscribe(EventType events);
    }
}