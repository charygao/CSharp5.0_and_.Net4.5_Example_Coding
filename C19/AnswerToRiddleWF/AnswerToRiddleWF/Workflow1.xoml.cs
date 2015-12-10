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

namespace AnswerToRiddleWF
{
	public partial class Workflow1 : SequentialWorkflowActivity
	{
        private bool isRight;
        public bool IsRight
        {
            get { return isRight; }
            set { isRight = value; }
        }
        //CodeActivity 用于向工作流中添加一代要执行的代码。
        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            string answer = Console.ReadLine();
            if (answer == "祸从口出")
            {
                Console.WriteLine("恭喜！回答正确，程序将退出");
                isRight = true;
            }
            else
            {
                Console.WriteLine("回答错误，请重新回答");
            }
        }
	}
}
