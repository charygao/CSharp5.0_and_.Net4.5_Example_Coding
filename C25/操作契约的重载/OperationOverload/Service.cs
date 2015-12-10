using System;
using System.ServiceModel;
namespace WCF.Third
{
    [ServiceContract]
    public interface IService
    {
        //设置Name属性解决重载问题
        [OperationContract(Name="HelloString")]
        String Hello(String input);
        [OperationContract(Name = "HelloVoid")]
        void Hello();
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
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }
}
