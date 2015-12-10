using System;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace WCF.Third
{
    /// <summary>
    /// 基类
    /// </summary>
    [DataContract]
    public class People
    {
        [DataMember]
        public String Name;
        //使用Order属性
        [DataMember(Order = 1)]
        public int Age;
    }
    /// <summary>
    /// 子类
    /// </summary>
    [DataContract]
    public class Student:People
    {
        [DataMember]
        public String SchoolName;
        [DataMember]
        public String Major;
        [DataMember]
        public String Minor;
        //下面两个成员使用了Order属性
        [DataMember(Order = 1)]
        public String StudentId;
        [DataMember(Order = 2)]
        public String RoomId;
    }
}
