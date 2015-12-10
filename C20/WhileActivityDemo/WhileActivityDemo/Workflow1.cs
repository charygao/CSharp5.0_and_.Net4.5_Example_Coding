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

namespace WhileActivityDemo
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}
        //外层循款变量
        private int i = 0;
        //内层循款变量
        private int j = 1;

        //外层循环将累加和初始化值
        private void Code1_ExecuteCode(object sender, EventArgs e)
        {
            j = 1;
            i++;
        }
        //内层循环输出口决。
        private void Code2_ExecuteCode(object sender, EventArgs e)
        {           
            Console.Write(i + "X" + j + "=" + i * j+" ");
            if (j == 9)
            {
                Console.WriteLine("");
            }
            j++; 
        }
	}

}
