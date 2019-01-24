namespace Budget_App
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputSetup)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(13, 13);
            this.txtDelimiter.MaxLength = 1;
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(17, 20);
            this.txtDelimiter.TabIndex = 0;
            this.txtDelimiter.Text = ",";
            this.txtDelimiter.TextChanged += new System.EventHandler(this.txtDelimiter_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Column Delimiter";
            // 
            // dgvInputSetup
            // 
            this.dgvInputSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputSetup.Location = new System.Drawing.Point(13, 62);
            this.dgvInputSetup.Name = "dgvInputSetup";
            this.dgvInputSetup.Size = new System.Drawing.Size(596, 171);
            this.dgvInputSetup.TabIndex = 2;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(533, 9);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // CSVInputSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 248);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.dgvInputSetup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDelimiter);
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
    }
}