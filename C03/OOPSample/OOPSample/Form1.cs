using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SaleEmployee mysale = new SaleEmployee();	//实例化销售部员工类
            mysale.Name = "销售员1";
            mysale.Sale(); 								//销售操作
            mysale.WorkOff();                           //下班
            mysale.SaleCount = 10000;
            label1.Text = mysale.SaleCount.ToString();		//显示此员工的销售额

            BuyEmployee mybuy = new BuyEmployee();			//实例化采购部员工类
            mybuy.Name = "采购员1";
            mybuy.WorkOn();									//上班
            mybuy.Buy();    									//采购
        }
    }
}
