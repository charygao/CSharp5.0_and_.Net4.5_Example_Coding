using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using Client.WCF.Fifth;
namespace WCF.Fifth
{
    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                using (ServiceClient proxy = new ServiceClient())
                {
                    //指定Windows凭证
                    //proxy.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential(@"SCN4752\WCF_Op","Pass123!@#word");
                    proxy.PublicOperation();
                    proxy.RestrictedOperation();
                    proxy.AdminOperation();
                    Console.Read();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
        }
    }
}
