namespace Budget_App.Views
{
    partial class Search
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgcolDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcolAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcolCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgcolDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcolMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTransactions
            // 
            this.dgTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcolDate,
            this.dgcolAmount,
            this.dgcolCategory,
            this.dgcolDescription,
            this.dgcolMemo});
            this.dgTransactions.Location = new System.Drawing.Point(16, 97);
            this.dgTransactions.Margin = new System.Windows.Forms.Padding(4);
            this.dgTransactions.Name = "dgTransactions";
            this.dgTransactions.Size = new System.Drawing.Size(760, 514);
            this.dgTransactions.TabIndex = 1;
            this.dgTransactions.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgTransactions_ColumnHeaderMouseClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(16, 47);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(345, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Terms - comma separated";
            // 
            // dgcolDate
            // 
            this.dgcolDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgcolDate.HeaderText = "Date";
            this.dgcolDate.Name = "dgcolDate";
            this.dgcolDate.ReadOnly = true;
            this.dgcolDate.Width = 67;
            // 
            // dgcolAmount
            // 
            this.dgcolAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.dgcolAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgcolAmount.HeaderText = "Amount";
            this.dgcolAmount.Name = "dgcolAmount";
            this.dgcolAmount.ReadOnly = true;
            this.dgcolAmount.Width = 85;
            // 
            // dgcolCategory
            // 
            this.dgcolCategory.HeaderText = "Category";
            this.dgcolCategory.Name = "dgcolCategory";
            this.dgcolCategory.ReadOnly = true;
            // 
            // dgcolDescription
            // 
            this.dgcolDescription.HeaderText = "Description";
            this.dgcolDescription.Name = "dgcolDescription";
            // 
            // dgcolNote
            // 
            this.dgcolMemo.HeaderText = "Memo";
            this.dgcolMemo.Name = "dgcolNote";
            this.dgcolMemo.ReadOnly = true;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 626);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgTransactions);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTransactions;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcolDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcolAmount;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcolCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcolDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcolMemo;
    }
}