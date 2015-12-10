using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample
{
    class SaleEmployee : Employee
    {
        private int _salecount;
        public int SaleCount 			//销售额
        {
            get { return _salecount; }
            set { _salecount = value; }
        }
        public void Sale()
        {
            //销售操作的代码
        }
    }
}
