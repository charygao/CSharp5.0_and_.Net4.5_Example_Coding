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

namespace CAGDemo
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
        //表示书籍和出版社的泛型字符串
        private List<String> _bookPublisher = new List<string>();
        //公共属性
        public List<string> BookPublisher
        {
            get { return _bookPublisher; }
            set { _bookPublisher = value; }
        }
		public Workflow1()
		{
			InitializeComponent();
            _bookPublisher.Add("甲出版社");
            _bookPublisher.Add("乙出版社");
            _bookPublisher.Add("丙出版社");
            _bookPublisher.Add("丁出版社");
		}
        //处理完毕后，移除己经处理的书 
        private void ProcessBookPublisher(String item)
        {
            Int32 itemIndex = BookPublisher.IndexOf(item);
            if (itemIndex >= 0)
            {
                BookPublisher.RemoveAt(itemIndex);
            }
        }
        private void ACode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("甲出版社出版完成");
            ProcessBookPublisher("甲出版社");
        }
        private void BCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("乙出版社出版完成");
            ProcessBookPublisher("乙出版社");
        }
        private void CCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("丙出版社出版完成");
            ProcessBookPublisher("丙出版社");
        }
        private void DCode_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("丁出版社出版完成");
            ProcessBookPublisher("丁出版社");
        }
	}

}
