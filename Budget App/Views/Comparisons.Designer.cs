namespace Budget_App.Views
{
	partial class Comparisons
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
            this.dgCompare = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgCompare)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCompare
            // 
            this.dgCompare.AllowUserToAddRows = false;
            this.dgCompare.AllowUserToDeleteRows = false;
            this.dgCompare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCompare.Location = new System.Drawing.Point(17, 16);
            this.dgCompare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgCompare.Name = "dgCompare";
            this.dgCompare.ReadOnly = true;
            this.dgCompare.Size = new System.Drawing.Size(933, 535);
            this.dgCompare.TabIndex = 0;
            // 
            // Comparisons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 566);
            this.Controls.Add(this.dgCompare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Comparisons";
            this.Text = "Comparisons";
            ((System.ComponentModel.ISupportInitialize)(this.dgCompare)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgCompare;
	}
}