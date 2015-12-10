using System;
using System.ServiceModel;
namespace WCF.Third
{
    /// <summary>
    /// 数据契约，会转换为XSD
    /// </summary>
    [Serializable]
    public class InputPar
    {
        private String _name;
        private int _age;
        public String Name
        {
            get
            {
                return _name;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
        }
        public InputPar(String name, int age)
        {
            _name = name;
            _age = age;
        }
    }
    /// <summary>
    /// 数据契约，会转换为XSD
    /// </summary>
    [Serializable]
    public class OutputPar
    {
        private bool _isSuccess;
        private String _comment;
        public OutputPar(bool isSuccess, String comment)
        {
            _isSuccess = isSuccess;
            _comment = comment;
        }
        public bool IsSuccess
        {
            get
            {
                return _isSuccess;
            }
        }
        public String Comment
        {
            get
            {
                return _comment;
            }
        }
    }
    /// <summary>
    /// 服务契约，使用了自定义的数据类型
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        OutputPar DoSomeWork(InputPar input);
    }
    /// <summary>
    /// 服务的实现
    /// </summary>
    public class Service : IService
    {
        public OutputPar DoSomeWork(InputPar input)
        {
            Console.WriteLine(input.Name);
            Console.WriteLine(input.Age.ToString());
            return new OutputPar(true, "Success");
        }
    }
}
