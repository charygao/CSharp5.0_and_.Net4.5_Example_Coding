using System;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace WCF.CaseStudy
{
    /// <summary>
    /// 代理类型，由于支持回调，继承自DuplexClientBase类型"/>
    /// </summary>
    public class ServiceProxy : System.ServiceModel.DuplexClientBase<WCF.CaseStudy.IControlCenter>, WCF.CaseStudy.IControlCenter
    {
        public ServiceProxy(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(callbackInstance, binding, remoteAddress)
        {
        }
        public bool StartMainline(WCF.CaseStudy.Patient patient, int bedNo)
        {
            return base.Channel.StartMainline(patient, bedNo);
        }
        public bool EndMainline(WCF.CaseStudy.Patient patient, int bedNo)
        {
            return base.Channel.EndMainline(patient, bedNo);
        }
        public void HeartBeat(int bedNo, PatientStatus status)
        {
            base.Channel.HeartBeat(bedNo, status);
        }
        public bool EmergentCall(int bedNo)
        {
            return base.Channel.EmergentCall(bedNo);
        }
        public bool EndEmergentCall(int bedNo)
        {
            return base.Channel.EndEmergentCall(bedNo);
        }
    }
}
