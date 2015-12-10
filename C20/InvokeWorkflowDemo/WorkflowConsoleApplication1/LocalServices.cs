using System;
using System.Workflow.Activities;

namespace WorkflowConsoleApplication1
{
    [ExternalDataExchange]
    internal interface ILocalService
    {
        event EventHandler<ExternalDataEventArgs> InvokedWorkflowComplete;
        void WorkComplete(Guid HostWFGuid);
    }
    //定义一个本地服务实现，该服务将被添加到工作流运行时引擎中
    internal class LocalService : ILocalService
    {
        public event EventHandler<ExternalDataEventArgs> InvokedWorkflowComplete;
        public void WorkComplete(Guid HostWFGuid)
        {
            if (InvokedWorkflowComplete != null)
            {
                InvokedWorkflowComplete(null, new ExternalDataEventArgs(HostWFGuid));
            }
        }
    }
}