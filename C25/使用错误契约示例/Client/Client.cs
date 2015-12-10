using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
namespace WCF.Third
{
    class Client
    {
        static void Main(string[] args)
        {
            using (ServiceClient proxy = new ServiceClient(new WSHttpBinding(), 
                        new EndpointAddress("http://localhost:8675/Service")))
            {
                try
                {
                    proxy.ThrowException("Null");
                }
                catch (FaultException<NullReferenceException> ex)
                {
                    //这里打印错误的信息
                    Console.WriteLine(ex.Detail.Message);
                }
                try
                {
                    proxy.ThrowException("Normal");
                }
                catch (FaultException<Exception> ex)
                {
                    //这里打印错误的信息
                    Console.WriteLine(ex.Detail.Message);
                }
                try
                {
                    proxy.ThrowException("Customized");
                }
                catch (FaultException<MyException> ex)
                {
                    //这里打印错误的信息
                    Console.WriteLine(ex.Detail.Message);
                }
                Console.Read();

            }
        }
    }
}
