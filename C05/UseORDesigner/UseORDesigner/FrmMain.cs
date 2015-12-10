using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseORDesigner
{
    public partial class FrmMain : Form
    {
        public FrmMain( )
        {
            InitializeComponent( );
        }

        private StudentsDataContext _StuDC = new StudentsDataContext( );

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.studentsBindingSource.AllowNew = false;
            this.studentsBindingSource.DataSource = this._StuDC.Students;
        }

        private void studentsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            
        }
    }
}
