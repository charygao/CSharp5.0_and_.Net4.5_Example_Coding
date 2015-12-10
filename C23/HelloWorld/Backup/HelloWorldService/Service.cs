using System;
using System.ServiceModel;
namespace HelloWorldService
{
    //服务的实现
    public class Service:IService
    {
        //服务操作实现
        public String HelloWorld(String name)
        {
            //拼装字符串并返回
            return name + " 说：HelloWorld!";
        }
    }
}
