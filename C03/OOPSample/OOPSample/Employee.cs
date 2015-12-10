using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample
{
    class Employee
    {
        //私有属性的设计
        private int _id;				//员工号
        private string _name;		//姓名
        private int _age;			//年龄
        private string _address;	//地址
        public int EmployeeID  		//员工号
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name  			//姓名
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age  				//年龄
        {
            get { return _age; }
            set { _age = value; }
        }
        public string Address  			//地址
        {
            get { return _address; }
            set { _address = value; }
        }
        public void WorkOn()
        {
            //上班操作的代码
        }
        public void WorkOff()
        {
            //下班操作的代码
        }
    }
}
