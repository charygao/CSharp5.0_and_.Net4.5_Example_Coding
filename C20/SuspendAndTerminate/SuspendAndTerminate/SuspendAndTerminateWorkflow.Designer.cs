using System;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;

namespace SuspendAndTerminate
{
    public sealed partial class SuspendAndTerminateWorkflow 
    {
        #region Designer generated code
        
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.��ֹ������ = new System.Workflow.ComponentModel.TerminateActivity();
            this.����̨��Ϣ = new System.Workflow.Activities.CodeActivity();
            this.�������� = new System.Workflow.ComponentModel.SuspendActivity();
            // 
            // ��ֹ������
            // 
            this.��ֹ������.Name = "��ֹ������";
            // 
            // ����̨��Ϣ
            // 
            this.����̨��Ϣ.Name = "����̨��Ϣ";
            this.����̨��Ϣ.ExecuteCode += new System.EventHandler(this.OnConsoleMessage);
            // 
            // ��������
            // 
            this.��������.Name = "��������";
            // 
            // SuspendAndTerminateWorkflow
            // 
            this.Activities.Add(this.��������);
            this.Activities.Add(this.����̨��Ϣ);
            this.Activities.Add(this.��ֹ������);
            this.Name = "SuspendAndTerminateWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private SuspendActivity ��������;
        private CodeActivity ����̨��Ϣ;
        private TerminateActivity ��ֹ������;



    }
}
