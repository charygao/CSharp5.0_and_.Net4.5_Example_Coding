using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace WCF.CaseStudy
{
    public partial class Detail : Form
    {
        //病人状态
        private PatientStatus _status;
        //回调引用
        private IInjector _injector;
        public Detail()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化窗体显示的信息
        /// </summary>
        public Detail(PatientStatus status, IInjector injector)
            : this()
        {
            _status = status;
            _injector = injector;
            PATIENTID.Text = _status._patient.ID;
            DOCID.Text = _status._patient.Doctor.ID;
            MEDID.Text = _status._medication.ID;
            MEDTOTAL.Text = _status._medication.Amount.ToString();
            MEDREMAIN.Text = _status._remainMed.ToString();
            RATE.Text = _status._rate.ToString();
        }
        /// <summary>
        /// 回调客户端，调整速率
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (RATE.Text.Trim() != _status._rate.ToString())
            {
                long newRate = 0;
                if (long.TryParse(RATE.Text.Trim(), out newRate) && newRate < _status._remainMed)
                {
                    _injector.AdjustRate(newRate);
                    DialogResult = DialogResult.Cancel;
                }
                else
                    MessageBox.Show("错误的速率设定！");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
