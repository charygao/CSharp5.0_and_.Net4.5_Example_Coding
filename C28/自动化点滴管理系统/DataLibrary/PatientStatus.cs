using System;
using System.Runtime.Serialization;
namespace WCF.CaseStudy
{
    [DataContract]
    public class PatientStatus
    {
        [DataMember]
        //病人
        public Patient _patient;
        [DataMember]
        //药物
        public Medication _medication;
        [DataMember]
        //药物剩余
        public long _remainMed;
        [DataMember]
        //当前注射速率
        public long _rate;
        public PatientStatus(Patient patient, Medication med, long remain, long rate)
        {
            _patient = patient;
            _medication = med;
            _remainMed = remain;
            _rate = rate;
        }
    }
}
