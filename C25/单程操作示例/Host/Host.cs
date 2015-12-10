using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace WCF.Third
{
    class Host
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Service)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
