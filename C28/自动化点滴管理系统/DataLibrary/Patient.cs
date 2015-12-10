using System;
using System.Runtime.Serialization;
namespace WCF.CaseStudy
{
    [DataContract]
    public sealed class Patient : People
    {
        [DataMember]
        //该病人的医生
        private Doctor _doctor;
        public Patient(String id, Doctor doctor)
            : base(id)
        {
            if (!CheckPatientID(id))
                throw new ArgumentException("非法的病人ID！");
            _doctor = doctor;
        }
        /// <summary>
        /// 病人的ID必须以P开头
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>返回是否合法</returns>
        public static bool CheckPatientID(String id)
        {
            if (!People.CheckID(id))
                return false;
            if (!id.StartsWith("P"))
                return false;
            return true;
        }
        public Doctor Doctor
        {
            get
            {
                return _doctor;
            }
        }
    }
}
