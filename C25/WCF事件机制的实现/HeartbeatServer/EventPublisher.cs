using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace WCF.Third
{
    /// <summary>
    /// 存储回调引用的泛型委托定义
    /// </summary>
    public delegate void GenericEventHandler();
    public delegate void GenericEventHandler<T>(T arg);
    /// <summary>
    /// 事件发布服务的实现
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class EventPublisher:IEventPublisher
    {
        //存储回调引用的泛型委托链实例
        static GenericEventHandler event1List;
        static GenericEventHandler<int> event2List;
        static GenericEventHandler<String> event3List;
        /// <summary>
        /// 订阅事件的实现
        /// </summary>
        /// <param name="events">订阅的事件</param>
        public void Subscribe(EventType events)
        {
            //得到回调引用
            IEvents subscriber = OperationContext.Current.GetCallbackChannel<IEvents>();
            //查看订阅的是哪些事件，并把回调引用存储到相应的委托链中
            if ((events & EventType.Event1) == EventType.Event1)
                event1List += subscriber.OnEvent1;
            if ((events & EventType.Event2) == EventType.Event2)
                event2List += subscriber.OnEvent2;
            if ((events & EventType.Event3) == EventType.Event3)
                event3List += subscriber.OnEvent3;
        }
        /// <summary>
        /// 取消事件的订阅
        /// </summary>
        /// <param name="events">事件</param>
        public void Unsubscribe(EventType events)
        {
            //得到回调引用
            IEvents subscriber = OperationContext.Current.GetCallbackChannel<IEvents>();
            //查看取消的是哪些事件，并从相应的委托链中移除引用
            if ((events & EventType.Event1) == EventType.Event1)
                event1List -= subscriber.OnEvent1;
            if ((events & EventType.Event2) == EventType.Event2)
                event2List -= subscriber.OnEvent2;
            if ((events & EventType.Event3) == EventType.Event3)
                event3List -= subscriber.OnEvent3;
        }
        /// <summary>
        /// 事件触发方法
        /// </summary>
        /// <param name="eve">事件</param>
        /// <param name="Args">参数</param>
        public void OnEvent(EventType eve,params object[] Args)
        {
            if (eve == EventType.Event1 && event1List!=null)
                event1List();
            else if (eve == EventType.Event2 && event2List != null)
                event2List((int)Args[0]);
            else if (eve == EventType.Event3 && event3List != null)
                event3List((String)Args[0]);
        }
    }
}
