using Budget_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Budget_App
{
	public partial class AddCategoryMatch : Form
	{
		public AddCategoryMatch()
		{
			InitializeComponent();

			cmbTypes.DataSource = Enum.GetValues(typeof(TransactionItem.TransactionTypes));
		}

		public AddCategoryMatch(string headerText, string category)
		{
			InitializeComponent();

			cmbTypes.DataSource = Enum.GetValues(typeof(TransactionItem.TransactionTypes));
			txtCategory.Text = category;
            lblHeaderText.Text = headerText;
		}

		private void cmdAdd_Click(object sender, EventArgs e)
		{
			string text = txtCategory.Text.Replace("\t", "").Trim(); // Remove tabs
			string category = cmbTypes.SelectedItem.ToString();

			if (string.IsNullOrEmpty(text))
				return;

			if (((TransactionItem.TransactionTypes)cmbTypes.SelectedItem) == TransactionItem.TransactionTypes.Unselected)
				if (MessageBox.Show("Are you sure you want to default '" + text + "' as Unselected?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					return;

			using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\CategoryMatching.txt", true))
			{
				sw.WriteLine("{0}\t{1}", text, category);
				sw.Flush();
			}

            TypeMatching.LoadTypes();

			this.Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
