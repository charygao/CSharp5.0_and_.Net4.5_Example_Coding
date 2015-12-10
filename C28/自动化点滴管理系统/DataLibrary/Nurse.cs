using System;
using System.Runtime.Serialization;
namespace WCF.CaseStudy
{
    [DataContract]
    public sealed class Nurse : People
    {
        public Nurse(String id)
            : base(id)
        {
            if (!CheckNurseID(id))
                throw new ArgumentException("非法的护士ID！");
        }
        /// <summary>
        /// 护士的ID必须以N开头
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool CheckNurseID(String id)
        {
            if (!People.CheckID(id))
                return false;
            if (!id.StartsWith("N"))
                return false;
            return true;
        }
    }
}
