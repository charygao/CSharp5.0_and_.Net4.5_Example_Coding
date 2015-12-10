using System;
namespace WCF.CaseStudy
{
    public enum ClientState
    {
        /// <summary>
        /// 没有心跳，表示客户端系统出现了故障
        /// </summary>
        MissingHeartBeat,
        /// <summary>
        /// 客户端系统开启，但并没有开始注射
        /// </summary>
        On,
        /// <summary>
        /// 表示客户端系统在进行注射
        /// </summary>
        Injecting,
        /// <summary>
        /// 表示客户端系统在呼叫服务，只有注射时才能进行服务
        /// </summary>
        Calling
    }
}
