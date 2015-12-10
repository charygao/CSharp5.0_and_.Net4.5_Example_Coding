using System;
using System.Runtime.Serialization;
namespace WCF.CaseStudy
{
    [DataContract]
    public sealed class Medication
    {
        [DataMember]
        //药物ID
        private String _id;
        [DataMember]
        //药物总量
        private long _amount;
        public String ID
        {
            get
            {
                return _id;
            }
            private set
            {
                if (!CheckID(value))
                    throw new ArgumentException("非法的药物ID！");
                _id = value;
            }
        }
        public long Amount
        {
            get
            {
                return _amount;
            }
            private set
            {
                _amount = value;
            }
        }
        public Medication(String id, long amount)
        {
            ID = id;
            Amount = amount;
        }
        /// <summary>
        /// 检查药物ID是否合法
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>返回是否合法</returns>
        public static bool CheckID(String id)
        {
            if (String.IsNullOrEmpty(id))
                return false;
            if (id.Length != 8 || !id.StartsWith("M"))
                return false;
            return true;
        }
    }
}
