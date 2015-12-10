using System;
using System.Threading;
using System.Windows.Forms;
using System.Workflow.Runtime;
using System.Workflow.Activities;


namespace VotingServicesDemo
{
    //�����������͹�����֮����Ҫ���ݵĲ���
    [Serializable]
    internal class VotingServiceEventArgs : ExternalDataEventArgs
    {
        private string aliasValue;
        public VotingServiceEventArgs(Guid instanceID, string alias)
            : base(instanceID)
        {
            this.aliasValue = alias;
        }
        //�������ԣ������������͹�����ʵ��֮�䴫�ݲ�����������Ǹ��ӵ�������Ǽ򵥵��ַ���
        public string Alias
        {
            get 
            {
                return this.aliasValue;
            }
        }
    }

    // ������Լ��������ϵ���ط���͹�����
    [ExternalDataExchange]
    internal interface IVotingService
    {
        event EventHandler<VotingServiceEventArgs> ApprovedProposal;
        event EventHandler<VotingServiceEventArgs> RejectedProposal;
        //����һ���µ�ͶƱ
        void CreateBallot(string alias);
    }
    //��������ʵ�ַ�����Լ��ʵ���䷽�����¼��Ա㹤�����ڲ�����
    internal class VotingServiceImpl : IVotingService
    {
        public event EventHandler<VotingServiceEventArgs> ApprovedProposal;
        public event EventHandler<VotingServiceEventArgs> RejectedProposal;

        //�ɹ�����������������һ�ε�ͶƱ���÷������������߳�����ʾһ��ͶƱ�Ի���
        public void CreateBallot(string alias)
        {
            Console.WriteLine("Ϊ{0}����ͶƱ", alias);
            ShowVotingDialog(new VotingServiceEventArgs(WorkflowEnvironment.WorkflowInstanceId, alias));
        }
        //��ʾ��Ϣ�򣬲������¼�
        public void ShowVotingDialog(VotingServiceEventArgs votingEventArgs)
        {
            DialogResult result;
            string alias = votingEventArgs.Alias;
            //���û���ʾһ���Ի��򣬸����û�����Ӧ������ͬ���¼�
            result = MessageBox.Show(string.Format("�Ƿ����� , {0}?", alias), string.Format("{0} ͶƱ", alias), MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                EventHandler<VotingServiceEventArgs> approvedProposal = this.ApprovedProposal;
                if (approvedProposal != null)
                    approvedProposal(null, votingEventArgs);
            }
            else
            {
                EventHandler<VotingServiceEventArgs> rejectedProposal = this.RejectedProposal;
                if (rejectedProposal != null)
                    rejectedProposal(null, votingEventArgs);
            }
        }
    }
}