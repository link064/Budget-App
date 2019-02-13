namespace Budget_App.Views
{
    partial class CSVInputSetup
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
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInputSetup = new System.Windows.Forms.DataGridView();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cbHasHeader = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputSetup)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(17, 16);
            this.txtDelimiter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDelimiter.MaxLength = 1;
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(21, 22);
            this.txtDelimiter.TabIndex = 0;
            this.txtDelimiter.Text = ",";
            this.txtDelimiter.TextChanged += new System.EventHandler(this.txtDelimiter_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(44, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Column Delimiter";
            // 
            // dgvInputSetup
            // 
            this.dgvInputSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputSetup.Location = new System.Drawing.Point(17, 76);
            this.dgvInputSetup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvInputSetup.Name = "dgvInputSetup";
            this.dgvInputSetup.Size = new System.Drawing.Size(795, 210);
            this.dgvInputSetup.TabIndex = 2;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(711, 11);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 28);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cbHasHeader
            // 
            this.cbHasHeader.AutoSize = true;
            this.cbHasHeader.Location = new System.Drawing.Point(130, 18);
            this.cbHasHeader.Name = "cbHasHeader";
            this.cbHasHeader.Size = new System.Drawing.Size(106, 21);
            this.cbHasHeader.TabIndex = 4;
            this.cbHasHeader.Text = "Has Header";
            this.cbHasHeader.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(536, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(168, 22);
            this.txtName.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(484, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name";
            // 
            // CSVInputSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 305);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cbHasHeader);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dgvInputSetup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDelimiter);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CSVInputSetup";
            this.Text = "CSV Input Setup";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputSetup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInputSetup;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.CheckBox cbHasHeader;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
    }
}