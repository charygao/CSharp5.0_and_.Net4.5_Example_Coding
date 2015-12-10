using System;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace WCF.Third
{
    /// <summary>
    /// SOAP的头部类型
    /// </summary>
    [Serializable]
    public class HeaderInfo
    {
        //会话ID
        public int SessionId;
        //描述
        public String Description;
        public HeaderInfo(int id, String des)
        {
            SessionId = id;
            Description = des;
        }
    }
    /// <summary>
    /// SOAP的Body类型
    /// </summary>
    [Serializable]
    public class BodyInfo
    {
        //类型信息
        public String Type;
        //时间信息
        public DateTime Time;
        //日志内容
        public String Content;
        public BodyInfo(String type, DateTime time, String content)
        {
            Type = type;
            Time = time;
            Content = content;
        }
    }
    /// <summary>
    /// 接受的消息契约
    /// </summary>
    [MessageContract]
    public class LogMessage
    {
        [MessageHeader]
        public HeaderInfo headerInfo;
        [MessageBodyMember]
        public BodyInfo bodyInfo;
        public LogMessage(HeaderInfo header, BodyInfo body)
        {
            headerInfo = header;
            bodyInfo = body;
        }
        /// <summary>
        /// 消息契约必须包含默认构造方法，否在在反序列化时将产生异常
        /// </summary>
        public LogMessage()
        {
        }
    }
    /// <summary>
    /// 返回码
    /// </summary>
    public enum ResponseCode
    {
        Success=101,
        Fail=102
    }
    /// <summary>
    /// 返回的消息契约
    /// </summary>
    [MessageContract]
    public class ResponseMessage
    {
        [MessageHeader]
        public ResponseCode responseCode;
        [MessageBodyMember]
        public String Response;
        public ResponseMessage(ResponseCode code, String response)
        {
            responseCode = code;
            Response = response;
        }
    }
}
