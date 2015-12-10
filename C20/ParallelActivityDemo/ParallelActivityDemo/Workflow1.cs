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

namespace ParallelActivityDemo
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        //循环的次数
        private int count;
        //WhileCondition是WhileActivity中的代码条件
        private void WhileCondition(object sender, ConditionalEventArgs e)
        {
            ++count;
            e.Result = (count <= 2);
        }
        //左侧的CodeActivity的执行代码
        private void Code1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("\n在Sequence1活动Code1: While循环次数 # {0}", count);
        }
        //右侧的CodeActivity的执行代码
        private void Code2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("\n在Sequence2活动Code2: While循环次数 # {0}", count);
        }

        private void Code3_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("\n在Sequence1活动Code3: While循环次数 # {0}", count);
        }

        private void Code4_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("\n在Sequence2活动Code4: While循环次数 # {0}", count);
        } 
	}

}
