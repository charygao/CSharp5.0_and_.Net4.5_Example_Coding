using System;
using System.ComponentModel;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Design;

namespace ParallelReplicatorDemo
{
    //定义一个派生自SequenceActivity的自定义活动
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    public partial class SampleReplicatorChildActivity : SequenceActivity
    {
        public SampleReplicatorChildActivity()
        {
            InitializeComponent();
        }
        //定义一个依赖属性，将用于从其父活动获取数据
        private static DependencyProperty InstanceDataProperty = DependencyProperty.Register("InstanceData", typeof(System.String), typeof(SampleReplicatorChildActivity));
        //依赖属性的.NET包装
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
        //CodeActivity的执行代码
        private void CodeHandler(object sender, EventArgs e)
        {           
            Console.WriteLine(this.InstanceData);
        }
    }
}
