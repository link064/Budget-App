using Budget_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Budget_App
{
	public partial class Comparisons : Form
	{
		public Comparisons()
		{
			InitializeComponent();
		}

		public Comparisons(List<TransactionItem> items, List<string> comparators)
		{
			InitializeComponent();

			DataTable dt = new DataTable();
			dt.Columns.Add("Date");
			foreach (TransactionItem.TransactionTypes types in Enum.GetValues(typeof(TransactionItem.TransactionTypes)))
				dt.Columns.Add(types.ToString());
			dt.Columns.Add("Total");

			foreach (string compare in comparators)
			{
				DataRow row = dt.NewRow();
				row["Date"] = compare;
				decimal total = 0;
				foreach (TransactionItem.TransactionTypes types in Enum.GetValues(typeof(TransactionItem.TransactionTypes)))
				{
					decimal subtotal = 0;
					foreach (TransactionItem item in items)
						if (item.TransDate.ToString("MMM yyyy").Contains(compare) && item.TransType == types)
							subtotal += item.Amount;
					total += subtotal;
					row[types.ToString()] = subtotal;
				}
				row["Total"] = total;
				dt.Rows.Add(row);
			}

			dgCompare.DataSource = dt;
		}
	}
}
