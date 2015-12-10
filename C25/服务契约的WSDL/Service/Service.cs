using System;
using System.ServiceModel;
namespace WCF.Third
{
    /// <summary>
    /// 定义简单的服务契约，以检查其WSDL
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        String Hello(String input);
        [OperationContract]
        void Close();
    }
    /// <summary>
    /// 服务契约的实现
    /// </summary>
    public class Service : IService
    {
        public String Hello(String input)
        {
            return "Hello, " + input;
        }
        public void Close()
        {
            Console.WriteLine("Bye!");
        }
    }
}
