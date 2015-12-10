using System;
using System.Workflow.Activities;
namespace PersistenceWorkflow
{
	public class PersistenceService:IPersistence
	{
        public event EventHandler<ExternalDataEventArgs> ContinueReceived;
        public event EventHandler<ExternalDataEventArgs> StopReceived;
        /// <summary>
        ///触发ContinueReceived事件
        /// </summary>
        /// <param name="args"></param>
        public void OnContinueReceived(ExternalDataEventArgs args)
        {
            if (ContinueReceived != null)
            {
                ContinueReceived(null, args);
            }
        }
        /// <summary>
        ///触发StopReceived事件
        /// </summary>
        /// <param name="args"></param>
        public void OnStopReceived(ExternalDataEventArgs args)
        {
            if (StopReceived != null)
            {
                StopReceived(null, args);
            }
        }
	}
}
