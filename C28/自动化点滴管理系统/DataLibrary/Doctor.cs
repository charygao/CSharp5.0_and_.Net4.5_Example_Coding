using System;
using System.Runtime.Serialization;
namespace WCF.CaseStudy
{
    [DataContract]
    public sealed class Doctor : People
    {
        public Doctor(String id)
            : base(id)
        {
            if (!CheckDocID(id))
                throw new ArgumentException("非法的医生ID！");
        }
        /// <summary>
        /// 医生的ID必须以D开头
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>返回是否合法</returns>
        public static bool CheckDocID(String id)
        {
            if (!People.CheckID(id))
                return false;
            if (!id.StartsWith("D"))
                return false;
            return true;
        }
    }
}
