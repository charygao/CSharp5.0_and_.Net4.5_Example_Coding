using System;
using System.ComponentModel;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Design;

namespace ParallelReplicatorDemo
{
    //����һ��������SequenceActivity���Զ���
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    public partial class SampleReplicatorChildActivity : SequenceActivity
    {
        public SampleReplicatorChildActivity()
        {
            InitializeComponent();
        }
        //����һ���������ԣ������ڴ��丸���ȡ����
        private static DependencyProperty InstanceDataProperty = DependencyProperty.Register("InstanceData", typeof(System.String), typeof(SampleReplicatorChildActivity));
        //�������Ե�.NET��װ
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        public string InstanceData
        {
            get
            {
                return ((string)(base.GetValue(SampleReplicatorChildActivity.InstanceDataProperty)));
            }
            set
            {
                base.SetValue(SampleReplicatorChildActivity.InstanceDataProperty, value);
            }
        }
        //CodeActivity��ִ�д���
        private void CodeHandler(object sender, EventArgs e)
        {           
            Console.WriteLine(this.InstanceData);
        }
    }
}
