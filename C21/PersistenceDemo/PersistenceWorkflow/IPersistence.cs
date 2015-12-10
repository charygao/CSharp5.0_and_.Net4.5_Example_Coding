using System;
using System.Workflow.Activities;
namespace PersistenceWorkflow
{
    //定义工作流本地服务接口
    [ExternalDataExchange]
    public interface IPersistence
    {
        event EventHandler<ExternalDataEventArgs> ContinueReceived;
        event EventHandler<ExternalDataEventArgs> StopReceived;
    }
}
