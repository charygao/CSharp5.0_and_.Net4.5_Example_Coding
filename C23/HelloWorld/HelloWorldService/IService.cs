using System;
using System.ServiceModel;
namespace HelloWorldService
{
    //HelloWorld的服务契约
    [ServiceContract]
    public interface IService
    {
        //服务操作
        [OperationContract]
        String HelloWorld(String name);
    }
}
