using System;
using System.Runtime.Serialization;
namespace WCF.CaseStudy
{
    [DataContract]
    public class People
    {
        [DataMember]
        //医生，护士，病人都有对应的id,8位长的字符
        private String _id;     
        public String ID
        {
            get
            {
                return _id;
            }
            protected set
            {
                if (!CheckID(value))
                    throw new ArgumentException("非法ID！");
                _id = value;
            }
        }
        public People(String id)
        {
            ID = id;
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(ID))
                return "对象未构造";
            return "ID：{" + ID + "}";
        }
        /// <summary>
        /// 间接被构造方法调用，不适合声明为虚方法
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>返回是否合法</returns>
        protected static bool CheckID(String id)
        {
            if (String.IsNullOrEmpty(id))
                return false;
            if (id.Length != 8)
                return false;
            return true;
        }
    }
}