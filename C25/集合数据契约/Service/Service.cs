using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections;
namespace WCF.Third
{
    /// <summary>
    /// 定义集合数据契约
    /// </summary>
    [CollectionDataContract]
    public class LogCollection<T> : IEnumerable<T>
    {
        private List<T> _logs = new List<T>();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _logs.GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _logs.GetEnumerator();
        }
        public void Add(T item)
        {
            _logs.Add(item);
        }
    }    
    /// <summary>
    /// 定义简单的服务契约
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void PrintLogs(LogCollection<String> logs);
    }
    /// <summary>
    /// 服务契约的实现
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// 打印所有的log
        /// </summary>
        /// <param name="logs"></param>
        public void PrintLogs(LogCollection<String> logs)
        {
            foreach (String log in logs)
                Console.WriteLine(log);
        }
    }
}

