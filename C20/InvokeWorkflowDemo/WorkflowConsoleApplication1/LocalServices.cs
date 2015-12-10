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
    //����һ�����ط���ʵ�֣��÷��񽫱���ӵ�����������ʱ������
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