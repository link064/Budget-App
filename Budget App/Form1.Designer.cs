namespace Budget_App
{
	partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgTransactions = new System.Windows.Forms.DataGridView();
            this.dgcolDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcolAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcolCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcolDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcolNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDateSelect = new System.Windows.Forms.ComboBox();
            this.lblTotals = new System.Windows.Forms.Label();
            this.lblTotalAmounts = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTransactions
            // 
            this.dgTransactions.AllowUserToAddRows = false;
            this.dgTransactions.AllowUserToDeleteRows = false;
            this.dgTransactions.AllowUserToResizeRows = false;
            this.dgTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcolDate,
            this.dgcolAmount,
            this.dgcolCategory,
            this.dgcolDescription,
            this.dgcolNote});
            this.dgTransactions.Location = new System.Drawing.Point(16, 102);
            this.dgTransactions.Margin = new System.Windows.Forms.Padding(4);
            this.dgTransactions.Name = "dgTransactions";
            this.dgTransactions.Size = new System.Drawing.Size(1180, 514);
            this.dgTransactions.TabIndex = 0;
            this.dgTransactions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTransactions_CellEndEdit);
            this.dgTransactions.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTransactions_ColumnHeaderMouseClick);
            this.dgTransactions.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgTransactions_DataBindingComplete);
            this.dgTransactions.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTransactions_RowHeaderMouseDoubleClick);
            // 
            // dgcolDate
            // 
            this.dgcolDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgcolDate.DataPropertyName = "TransDate";
            this.dgcolDate.FillWeight = 25F;
            this.dgcolDate.HeaderText = "Date";
            this.dgcolDate.Name = "dgcolDate";
            this.dgcolDate.Width = 67;
            // 
            // dgcolAmount
            // 
            this.dgcolAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgcolAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.dgcolAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcolAmount.FillWeight = 25F;
            this.dgcolAmount.HeaderText = "Amount";
            this.dgcolAmount.Name = "dgcolAmount";
            this.dgcolAmount.Width = 85;
            // 
            // dgcolCategory
            // 
            this.dgcolCategory.DataPropertyName = "TransType";
            this.dgcolCategory.FillWeight = 30F;
            this.dgcolCategory.HeaderText = "Category";
            this.dgcolCategory.Name = "dgcolCategory";
            // 
            // dgcolDescription
            // 
            this.dgcolDescription.DataPropertyName = "Description";
            this.dgcolDescription.HeaderText = "Description";
            this.dgcolDescription.Name = "dgcolDescription";
            // 
            // dgcolNote
            // 
            this.dgcolNote.DataPropertyName = "Memo";
            this.dgcolNote.HeaderText = "Memo";
            this.dgcolNote.Name = "dgcolNote";
            // 
            // cmbDateSelect
            // 
            this.cmbDateSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateSelect.FormattingEnabled = true;
            this.cmbDateSelect.Location = new System.Drawing.Point(227, 70);
            this.cmbDateSelect.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDateSelect.Name = "cmbDateSelect";
            this.cmbDateSelect.Size = new System.Drawing.Size(160, 24);
            this.cmbDateSelect.TabIndex = 1;
            this.cmbDateSelect.SelectedValueChanged += new System.EventHandler(this.cmbDateSelect_SelectedValueChanged);
            // 
            // lblTotals
            // 
            this.lblTotals.AutoSize = true;
            this.lblTotals.Location = new System.Drawing.Point(14, 637);
            this.lblTotals.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotals.Name = "lblTotals";
            this.lblTotals.Size = new System.Drawing.Size(47, 17);
            this.lblTotals.TabIndex = 2;
            this.lblTotals.Text = "Totals";
            // 
            // lblTotalAmounts
            // 
            this.lblTotalAmounts.AutoSize = true;
            this.lblTotalAmounts.Location = new System.Drawing.Point(14, 675);
            this.lblTotalAmounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmounts.Name = "lblTotalAmounts";
            this.lblTotalAmounts.Size = new System.Drawing.Size(0, 17);
            this.lblTotalAmounts.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.importToolStripMenuItem,
            this.compareToolStripMenuItem,
            this.graphToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1209, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicateCheckToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // duplicateCheckToolStripMenuItem
            // 
            this.duplicateCheckToolStripMenuItem.Name = "duplicateCheckToolStripMenuItem";
            this.duplicateCheckToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.duplicateCheckToolStripMenuItem.Text = "Duplicate Check";
            this.duplicateCheckToolStripMenuItem.Click += new System.EventHandler(this.duplicateCheckToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCSVToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // newCSVToolStripMenuItem
            // 
            this.newCSVToolStripMenuItem.Name = "newCSVToolStripMenuItem";
            this.newCSVToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.newCSVToolStripMenuItem.Text = "New CSV";
            this.newCSVToolStripMenuItem.Click += new System.EventHandler(this.newCSVToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthsToolStripMenuItem,
            this.yearsToolStripMenuItem});
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.compareToolStripMenuItem.Text = "Compare";
            // 
            // monthsToolStripMenuItem
            // 
            this.monthsToolStripMenuItem.Name = "monthsToolStripMenuItem";
            this.monthsToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.monthsToolStripMenuItem.Text = "Months";
            this.monthsToolStripMenuItem.Click += new System.EventHandler(this.monthsToolStripMenuItem_Click);
            // 
            // yearsToolStripMenuItem
            // 
            this.yearsToolStripMenuItem.Name = "yearsToolStripMenuItem";
            this.yearsToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.yearsToolStripMenuItem.Text = "Years";
            this.yearsToolStripMenuItem.Click += new System.EventHandler(this.yearsToolStripMenuItem_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem});
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.graphToolStripMenuItem.Text = "Graph";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(111, 26);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CSV|*.csv|All files|*.*";
            this.openFileDialog1.Title = "Select file to import";
            // 
            // cmbAccount
            // 
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(17, 70);
            this.cmbAccount.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(200, 24);
            this.cmbAccount.TabIndex = 6;
            this.cmbAccount.SelectedValueChanged += new System.EventHandler(this.cmbAccount_SelectedValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 955);
            this.Controls.Add(this.cmbAccount);
            this.Controls.Add(this.lblTotalAmounts);
            this.Controls.Add(this.lblTotals);
            this.Controls.Add(this.cmbDateSelect);
            this.Controls.Add(this.dgTransactions);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Budget";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgTransactions;
		private System.Windows.Forms.ComboBox cmbDateSelect;
		private System.Windows.Forms.Label lblTotals;
		private System.Windows.Forms.Label lblTotalAmounts;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newCSVToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem monthsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem yearsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem duplicateCheckToolStripMenuItem;
		private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcolDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcolAmount;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcolCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcolDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcolNote;
    }
}

