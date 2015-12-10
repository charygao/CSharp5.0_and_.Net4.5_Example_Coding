namespace UseORDesigner
{
    partial class FrmMain
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
                components.Dispose( );
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container( );
            System.Windows.Forms.Label chineseLabel;
            System.Windows.Forms.Label englishLabel;
            System.Windows.Forms.Label mathLabel;
            System.Windows.Forms.Label scoreIDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton( );
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel( );
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton( );
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton( );
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator( );
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox( );
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator( );
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton( );
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton( );
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator( );
            this.studentsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton( );
            this.studentsDataGridView = new System.Windows.Forms.DataGridView( );
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn( );
            this.chineseTextBox = new System.Windows.Forms.TextBox( );
            this.englishTextBox = new System.Windows.Forms.TextBox( );
            this.mathTextBox = new System.Windows.Forms.TextBox( );
            this.scoreIDTextBox = new System.Windows.Forms.TextBox( );
            this.label1 = new System.Windows.Forms.Label( );
            chineseLabel = new System.Windows.Forms.Label( );
            englishLabel = new System.Windows.Forms.Label( );
            mathLabel = new System.Windows.Forms.Label( );
            scoreIDLabel = new System.Windows.Forms.Label( );
            ((System.ComponentModel.ISupportInitialize) (this.studentsBindingSource)).BeginInit( );
            ((System.ComponentModel.ISupportInitialize) (this.studentsBindingNavigator)).BeginInit( );
            this.studentsBindingNavigator.SuspendLayout( );
            ((System.ComponentModel.ISupportInitialize) (this.studentsDataGridView)).BeginInit( );
            this.SuspendLayout( );
            // 
            // chineseLabel
            // 
            chineseLabel.AutoSize = true;
            chineseLabel.Location = new System.Drawing.Point(471, 76);
            chineseLabel.Name = "chineseLabel";
            chineseLabel.Size = new System.Drawing.Size(53, 12);
            chineseLabel.TabIndex = 2;
            chineseLabel.Text = "Chinese:";
            // 
            // englishLabel
            // 
            englishLabel.AutoSize = true;
            englishLabel.Location = new System.Drawing.Point(471, 103);
            englishLabel.Name = "englishLabel";
            englishLabel.Size = new System.Drawing.Size(53, 12);
            englishLabel.TabIndex = 4;
            englishLabel.Text = "English:";
            // 
            // mathLabel
            // 
            mathLabel.AutoSize = true;
            mathLabel.Location = new System.Drawing.Point(471, 130);
            mathLabel.Name = "mathLabel";
            mathLabel.Size = new System.Drawing.Size(35, 12);
            mathLabel.TabIndex = 6;
            mathLabel.Text = "Math:";
            // 
            // scoreIDLabel
            // 
            scoreIDLabel.AutoSize = true;
            scoreIDLabel.Location = new System.Drawing.Point(471, 157);
            scoreIDLabel.Name = "scoreIDLabel";
            scoreIDLabel.Size = new System.Drawing.Size(59, 12);
            scoreIDLabel.TabIndex = 8;
            scoreIDLabel.Text = "Score ID:";
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataSource = typeof(UseORDesigner.Students);
            // 
            // studentsBindingNavigator
            // 
            this.studentsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.studentsBindingNavigator.BindingSource = this.studentsBindingSource;
            this.studentsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.studentsBindingNavigator.DeleteItem = null;
            this.studentsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.studentsBindingNavigatorSaveItem});
            this.studentsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.studentsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.studentsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.studentsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.studentsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.studentsBindingNavigator.Name = "studentsBindingNavigator";
            this.studentsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.studentsBindingNavigator.Size = new System.Drawing.Size(644, 25);
            this.studentsBindingNavigator.TabIndex = 0;
            this.studentsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image) (resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "新添";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image) (resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image) (resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image) (resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image) (resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // studentsBindingNavigatorSaveItem
            // 
            this.studentsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.studentsBindingNavigatorSaveItem.Enabled = false;
            this.studentsBindingNavigatorSaveItem.Image = ((System.Drawing.Image) (resources.GetObject("studentsBindingNavigatorSaveItem.Image")));
            this.studentsBindingNavigatorSaveItem.Name = "studentsBindingNavigatorSaveItem";
            this.studentsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.studentsBindingNavigatorSaveItem.Text = "保存数据";
            // 
            // studentsDataGridView
            // 
            this.studentsDataGridView.AutoGenerateColumns = false;
            this.studentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.studentsDataGridView.DataSource = this.studentsBindingSource;
            this.studentsDataGridView.Location = new System.Drawing.Point(12, 43);
            this.studentsDataGridView.Name = "studentsDataGridView";
            this.studentsDataGridView.RowTemplate.Height = 23;
            this.studentsDataGridView.Size = new System.Drawing.Size(450, 141);
            this.studentsDataGridView.TabIndex = 1;
            this.studentsDataGridView.SelectionChanged += new System.EventHandler(this.studentsDataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "XingBie";
            this.dataGridViewTextBoxColumn2.HeaderText = "XingBie";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Age";
            this.dataGridViewTextBoxColumn3.HeaderText = "Age";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ScoreID";
            this.dataGridViewTextBoxColumn4.HeaderText = "ScoreID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // chineseTextBox
            // 
            this.chineseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentsBindingSource, "Scores.Chinese", true));
            this.chineseTextBox.Location = new System.Drawing.Point(536, 73);
            this.chineseTextBox.Name = "chineseTextBox";
            this.chineseTextBox.Size = new System.Drawing.Size(100, 21);
            this.chineseTextBox.TabIndex = 3;
            // 
            // englishTextBox
            // 
            this.englishTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentsBindingSource, "Scores.English", true));
            this.englishTextBox.Location = new System.Drawing.Point(536, 100);
            this.englishTextBox.Name = "englishTextBox";
            this.englishTextBox.Size = new System.Drawing.Size(100, 21);
            this.englishTextBox.TabIndex = 5;
            // 
            // mathTextBox
            // 
            this.mathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentsBindingSource, "Scores.Math", true));
            this.mathTextBox.Location = new System.Drawing.Point(536, 127);
            this.mathTextBox.Name = "mathTextBox";
            this.mathTextBox.Size = new System.Drawing.Size(100, 21);
            this.mathTextBox.TabIndex = 7;
            // 
            // scoreIDTextBox
            // 
            this.scoreIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentsBindingSource, "Scores.ScoreID", true));
            this.scoreIDTextBox.Location = new System.Drawing.Point(536, 154);
            this.scoreIDTextBox.Name = "scoreIDTextBox";
            this.scoreIDTextBox.Size = new System.Drawing.Size(100, 21);
            this.scoreIDTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "选中学生成绩";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 193);
            this.Controls.Add(this.label1);
            this.Controls.Add(chineseLabel);
            this.Controls.Add(this.chineseTextBox);
            this.Controls.Add(englishLabel);
            this.Controls.Add(this.englishTextBox);
            this.Controls.Add(mathLabel);
            this.Controls.Add(this.mathTextBox);
            this.Controls.Add(scoreIDLabel);
            this.Controls.Add(this.scoreIDTextBox);
            this.Controls.Add(this.studentsDataGridView);
            this.Controls.Add(this.studentsBindingNavigator);
            this.Name = "FrmMain";
            this.Text = "使用 O/R 设计器";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize) (this.studentsBindingSource)).EndInit( );
            ((System.ComponentModel.ISupportInitialize) (this.studentsBindingNavigator)).EndInit( );
            this.studentsBindingNavigator.ResumeLayout(false);
            this.studentsBindingNavigator.PerformLayout( );
            ((System.ComponentModel.ISupportInitialize) (this.studentsDataGridView)).EndInit( );
            this.ResumeLayout(false);
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.BindingSource studentsBindingSource;
        private System.Windows.Forms.BindingNavigator studentsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton studentsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView studentsDataGridView;
        private System.Windows.Forms.TextBox chineseTextBox;
        private System.Windows.Forms.TextBox englishTextBox;
        private System.Windows.Forms.TextBox mathTextBox;
        private System.Windows.Forms.TextBox scoreIDTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label1;


    }
}