using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Collections.Generic;

namespace ReplicatorActivityDemo
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
            childData.Add("这是数据1");
            childData.Add("这是数据2");
            childData.Add("这是数据3");
            childData.Add("这是数据4");
        }
        //定义用于种子数据的字符串变量
        private List<string> childData = new List<string>();
        public List<string> ChildData
        {
            get
            {
                return childData;
            }
        }

        private void Code_ExecuteCode(object sender, EventArgs e)
        {
            Object data = String.Empty;
            if (sender is Activity)
            {
                //如果当前活动的父活动为ReplicatorActivity
                if (((Activity)sender).Parent is ReplicatorActivity)
                {
                    //获取ReplicatorActivity的引用
                    ReplicatorActivity rep
                    = ((Activity)sender).Parent as ReplicatorActivity;
                    //获取当前子活动的所需要显示的字符串数据，CurrentIndex表示当前活动的索引 
                    data = rep.InitialChildData[rep.CurrentIndex];
                }
            }
            Console.WriteLine("当前代码活动的实例数据是: {0}", data);
        }
    }

}
