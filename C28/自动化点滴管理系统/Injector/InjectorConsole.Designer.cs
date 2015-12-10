namespace WCF.CaseStudy
{
    partial class InjectorConsole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CONTAINER = new System.Windows.Forms.Panel();
            this.REMAIN = new System.Windows.Forms.Panel();
            this.BEDTITILE = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MEDAMOUNT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CALL = new System.Windows.Forms.Button();
            this.SWITCH = new System.Windows.Forms.Button();
            this.MEDICATIONID = new System.Windows.Forms.TextBox();
            this.药物ID = new System.Windows.Forms.Label();
            this.NURSEID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DOCTORID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PATIENTID = new System.Windows.Forms.TextBox();
            this.CONTAINER.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CONTAINER
            // 
            this.CONTAINER.BackColor = System.Drawing.Color.Gray;
            this.CONTAINER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CONTAINER.Controls.Add(this.REMAIN);
            this.CONTAINER.Location = new System.Drawing.Point(12, 69);
            this.CONTAINER.Name = "CONTAINER";
            this.CONTAINER.Size = new System.Drawing.Size(120, 380);
            this.CONTAINER.TabIndex = 0;
            // 
            // REMAIN
            // 
            this.REMAIN.BackColor = System.Drawing.Color.LimeGreen;
            this.REMAIN.Location = new System.Drawing.Point(-1, 343);
            this.REMAIN.Name = "REMAIN";
            this.REMAIN.Size = new System.Drawing.Size(120, 0);
            this.REMAIN.TabIndex = 5;
            // 
            // BEDTITILE
            // 
            this.BEDTITILE.AutoSize = true;
            this.BEDTITILE.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BEDTITILE.Location = new System.Drawing.Point(191, 9);
            this.BEDTITILE.Name = "BEDTITILE";
            this.BEDTITILE.Size = new System.Drawing.Size(82, 46);
            this.BEDTITILE.TabIndex = 2;
            this.BEDTITILE.Text = "1床";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "病人ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MEDAMOUNT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CALL);
            this.groupBox1.Controls.Add(this.SWITCH);
            this.groupBox1.Controls.Add(this.MEDICATIONID);
            this.groupBox1.Controls.Add(this.药物ID);
            this.groupBox1.Controls.Add(this.NURSEID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DOCTORID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PATIENTID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(151, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 380);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病人信息";
            // 
            // MEDAMOUNT
            // 
            this.MEDAMOUNT.Location = new System.Drawing.Point(79, 207);
            this.MEDAMOUNT.Name = "MEDAMOUNT";
            this.MEDAMOUNT.Size = new System.Drawing.Size(198, 24);
            this.MEDAMOUNT.TabIndex = 14;
            this.MEDAMOUNT.Text = "300";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "药物总量";
            // 
            // CALL
            // 
            this.CALL.Enabled = false;
            this.CALL.Location = new System.Drawing.Point(6, 304);
            this.CALL.Name = "CALL";
            this.CALL.Size = new System.Drawing.Size(268, 37);
            this.CALL.TabIndex = 12;
            this.CALL.Text = "呼叫服务";
            this.CALL.UseVisualStyleBackColor = true;
            this.CALL.Click += new System.EventHandler(this.CALL_Click);
            // 
            // SWITCH
            // 
            this.SWITCH.Location = new System.Drawing.Point(6, 249);
            this.SWITCH.Name = "SWITCH";
            this.SWITCH.Size = new System.Drawing.Size(268, 37);
            this.SWITCH.TabIndex = 11;
            this.SWITCH.Text = "开始注射";
            this.SWITCH.UseVisualStyleBackColor = true;
            this.SWITCH.Click += new System.EventHandler(this.SWITCH_Click);
            // 
            // MEDICATIONID
            // 
            this.MEDICATIONID.Location = new System.Drawing.Point(79, 165);
            this.MEDICATIONID.Name = "MEDICATIONID";
            this.MEDICATIONID.Size = new System.Drawing.Size(198, 24);
            this.MEDICATIONID.TabIndex = 10;
            this.MEDICATIONID.Text = "M1111111";
            // 
            // 药物ID
            // 
            this.药物ID.AutoSize = true;
            this.药物ID.Location = new System.Drawing.Point(6, 165);
            this.药物ID.Name = "药物ID";
            this.药物ID.Size = new System.Drawing.Size(52, 18);
            this.药物ID.TabIndex = 9;
            this.药物ID.Text = "药物ID";
            // 
            // NURSEID
            // 
            this.NURSEID.Location = new System.Drawing.Point(79, 123);
            this.NURSEID.Name = "NURSEID";
            this.NURSEID.Size = new System.Drawing.Size(198, 24);
            this.NURSEID.TabIndex = 8;
            this.NURSEID.Text = "N1111111";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "护士ID";
            // 
            // DOCTORID
            // 
            this.DOCTORID.Location = new System.Drawing.Point(79, 81);
            this.DOCTORID.Name = "DOCTORID";
            this.DOCTORID.Size = new System.Drawing.Size(198, 24);
            this.DOCTORID.TabIndex = 6;
            this.DOCTORID.Text = "D1111111";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "医生ID";
            // 
            // PATIENTID
            // 
            this.PATIENTID.Location = new System.Drawing.Point(79, 39);
            this.PATIENTID.Name = "PATIENTID";
            this.PATIENTID.Size = new System.Drawing.Size(198, 24);
            this.PATIENTID.TabIndex = 4;
            this.PATIENTID.Text = "P1111111";
            // 
            // InjectorConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 476);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BEDTITILE);
            this.Controls.Add(this.CONTAINER);
            this.Name = "InjectorConsole";
            this.Text = "InjectorConsole";
            this.CONTAINER.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CONTAINER;
        private System.Windows.Forms.Label BEDTITILE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SWITCH;
        private System.Windows.Forms.TextBox MEDICATIONID;
        private System.Windows.Forms.Label 药物ID;
        private System.Windows.Forms.TextBox NURSEID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DOCTORID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PATIENTID;
        private System.Windows.Forms.Button CALL;
        private System.Windows.Forms.Panel REMAIN;
        private System.Windows.Forms.TextBox MEDAMOUNT;
        private System.Windows.Forms.Label label1;

    }
}