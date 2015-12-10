using System;
using System.Threading;
using System.Windows.Forms;
using System.Workflow.Runtime;
using System.Workflow.Activities;


namespace VotingServicesDemo
{
    //定义在宿主和工作流之间需要传递的参数
    [Serializable]
    internal class VotingServiceEventArgs : ExternalDataEventArgs
    {
        private string aliasValue;
        public VotingServiceEventArgs(Guid instanceID, string alias)
            : base(instanceID)
        {
            this.aliasValue = alias;
        }
        //公共属性，用于在宿主和工作流实例之间传递参数，这可以是复杂的类或者是简单的字符串
        public string Alias
        {
            get 
            {
                return this.aliasValue;
            }
        }
    }

    // 定义契约，用于联系本地服务和工作流
    [ExternalDataExchange]
    internal interface IVotingService
    {
        event EventHandler<VotingServiceEventArgs> ApprovedProposal;
        event EventHandler<VotingServiceEventArgs> RejectedProposal;
        //创建一次新的投票
        void CreateBallot(string alias);
    }
    //在宿主端实现服务契约，实现其方法和事件以便工作流内部调用
    internal class VotingServiceImpl : IVotingService
    {
        public event EventHandler<VotingServiceEventArgs> ApprovedProposal;
        public event EventHandler<VotingServiceEventArgs> RejectedProposal;

        //由工作流调用来开启新一次的投票，该方法将在宿主线程中显示一个投票对话框。
        public void CreateBallot(string alias)
        {
            Console.WriteLine("为{0}创建投票", alias);
            ShowVotingDialog(new VotingServiceEventArgs(WorkflowEnvironment.WorkflowInstanceId, alias));
        }
        //显示消息框，并触发事件
        public void ShowVotingDialog(VotingServiceEventArgs votingEventArgs)
        {
            DialogResult result;
            string alias = votingEventArgs.Alias;
            //向用户显示一个对话框，根据用户的响应触发不同的事件
            result = MessageBox.Show(string.Format("是否批核 , {0}?", alias), string.Format("{0} 投票", alias), MessageBoxButtons.YesNo);
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