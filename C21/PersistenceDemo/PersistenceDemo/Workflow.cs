using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersistenceDemo
{
    //获取当前工作流信息的类 
    public class Workflow
    {
        public Guid InstanceId { get; set; }
        public String StatusMessage { get; set; }
        public Boolean IsCompleted { get; set; }
    }
}
