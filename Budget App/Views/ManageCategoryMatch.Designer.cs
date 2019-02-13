namespace Budget_App.Views
{
    partial class ManageCategoryMatch
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
            this.dgCategoryMatch = new System.Windows.Forms.DataGridView();
            this.dgcolMatchText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcolMatchType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategoryMatch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCategoryMatch
            // 
            this.dgCategoryMatch.AllowUserToAddRows = false;
            this.dgCategoryMatch.AllowUserToDeleteRows = false;
            this.dgCategoryMatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCategoryMatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCategoryMatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcolMatchText,
            this.dgcolMatchType});
            this.dgCategoryMatch.Location = new System.Drawing.Point(13, 13);
            this.dgCategoryMatch.Name = "dgCategoryMatch";
            this.dgCategoryMatch.RowTemplate.Height = 24;
            this.dgCategoryMatch.Size = new System.Drawing.Size(649, 342);
            this.dgCategoryMatch.TabIndex = 0;
            // 
            // dgcolMatchText
            // 
            this.dgcolMatchText.DataPropertyName = "MatchString";
            this.dgcolMatchText.HeaderText = "Match Text";
            this.dgcolMatchText.Name = "dgcolMatchText";
            // 
            // dgcolMatchType
            // 
            this.dgcolMatchType.DataPropertyName = "MatchType";
            this.dgcolMatchType.FillWeight = 50F;
            this.dgcolMatchType.HeaderText = "Match Type";
            this.dgcolMatchType.Name = "dgcolMatchType";
            this.dgcolMatchType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgcolMatchType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ManageCategoryMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 519);
            this.Controls.Add(this.dgCategoryMatch);
            this.MaximizeBox = false;
            this.Name = "ManageCategoryMatch";
            this.Text = "ManageCategoryMatch";
            ((System.ComponentModel.ISupportInitialize)(this.dgCategoryMatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCategoryMatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcolMatchText;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgcolMatchType;
    }
}