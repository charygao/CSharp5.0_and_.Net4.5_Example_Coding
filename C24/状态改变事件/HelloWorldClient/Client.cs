﻿using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace HelloWorldClient
{
    class Client
    {
        /// <summary>
        /// 入口方法
        /// </summary>
        static void Main(string[] args)
        {
            using (HelloWorldProxy proxy = new HelloWorldProxy())
            {
                ICommunicationObject communicationObject = (ICommunicationObject)proxy;
                communicationObject.Opening += new EventHandler(Opened);
                communicationObject.Closed += new EventHandler(Closed);
                //利用代理调用服务
                Console.WriteLine(proxy.HelloWorld("WCF"));
            }
            Console.Read();
        }
        //Opened事件
        static void Opened(object sender, EventArgs args)
        {
            Console.WriteLine("状态机开启！");
        }
        //Closed事件
        static void Closed(object sender, EventArgs args)
        {
            Console.WriteLine("状态机关闭！");
        }
    }
    //硬编码定义服务契约
    [ServiceContract]
    interface IService
    {
        //服务操作
        [OperationContract]
        String HelloWorld(String name);
    }
    /// <summary>
    /// 客户端代理类型
    /// </summary>
    class HelloWorldProxy : ClientBase<IService>, IService
    {
        //硬编码定义绑定
        public static readonly Binding HelloWorldBinding = new NetNamedPipeBinding();
        //硬编码定义地址
        public static readonly EndpointAddress HelloWorldAddress=new EndpointAddress(new Uri("net.pipe://localhost/HelloWorld"));
        /// <summary>
        /// 构造方法
        /// </summary>
        public HelloWorldProxy() : base(HelloWorldBinding, HelloWorldAddress) { }
        public String HelloWorld(String name)
        {
            //使用Channel属性对服务进行调用
            return Channel.HelloWorld(name);
        }
    }
}
