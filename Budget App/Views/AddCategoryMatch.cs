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

namespace Budget_App.Views
{
	public partial class AddCategoryMatch : Form
	{
		public AddCategoryMatch()
		{
			InitializeComponent();

			cmbTypes.DataSource = Enum.GetValues(typeof(TransactionItem.TransactionTypes));
		}

		public AddCategoryMatch(string headerText, string category) : this()
		{
			txtCategory.Text = category;
            lblHeaderText.Text = headerText;
		}

		private void cmdAdd_Click(object sender, EventArgs e)
		{
			string text = txtCategory.Text.Replace("\t", "").Trim(); // Remove tabs (relic of tab-delimited file structure)
			TransactionItem.TransactionTypes category = (TransactionItem.TransactionTypes)cmbTypes.SelectedItem;

			if (string.IsNullOrEmpty(text))
				return;

			if (((TransactionItem.TransactionTypes)cmbTypes.SelectedItem) == TransactionItem.TransactionTypes.Unselected)
				if (MessageBox.Show("Are you sure you want to default '" + text + "' as Unselected?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					return;

            CategoryMatch.GetCollection().Insert(new CategoryMatch { MatchString = text, MatchType = category });

			this.Close();
		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
