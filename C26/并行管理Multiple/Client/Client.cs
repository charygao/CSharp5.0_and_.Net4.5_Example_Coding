using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
namespace WCF.Fourth
{
    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                using (ServiceClient proxy = new ServiceClient(new WSHttpBinding(),
                            new EndpointAddress("http://localhost:8675/Service")))
                {
                    //多次异步访问服务操作
                    proxy.BeginOperate(CallbackOperation, null);
                    proxy.BeginOperate(CallbackOperation, null);
                    proxy.BeginOperate(CallbackOperation, null);
                    Console.Read();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// 异步操作返回执行的方法
        /// </summary>
        static void CallbackOperation(IAsyncResult ar)
        {
            ar.AsyncWaitHandle.Close();
            Console.WriteLine("操作返回");
        }
    }
}
