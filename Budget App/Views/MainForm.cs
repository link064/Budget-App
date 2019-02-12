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
	public partial class MainForm : Form
	{
        public const string DATEFORMAT = "MMM yyyy";

		public MainForm()
		{
			InitializeComponent();
            ImportCategoryMatching(); // Legacy support
            InitGrids();
		}
				
		#region Events
		private void Form1_Resize(object sender, EventArgs e)
		{
			// TODO: resize components to fit
		}

		private void cmbDateSelect_SelectedValueChanged(object sender, EventArgs e)
		{
            var list = TransactionItem.GetCollection()
                .Find(t => t.TransDate.ToString(DATEFORMAT).Equals(cmbDateSelect.SelectedItem)
                    && (cmbAccount.SelectedItem.ToString() == t.Account || cmbAccount.SelectedItem.ToString() == "All Accounts"))
                .OrderBy(t => t.TransDate)
                .ToList();
			dgTransactions.DataSource = list;

			CalculateTotals(lblTotalAmounts, list);
		}

		private void cmbAccount_SelectedValueChanged(object sender, EventArgs e)
		{
			string selectedDate = (cmbDateSelect.DataSource == null) ? string.Empty : cmbDateSelect.SelectedItem.ToString();
			
			GetDates();

			if (string.IsNullOrEmpty(selectedDate))
				return;

            if (((List<string>)cmbDateSelect.DataSource).Contains(selectedDate))
                cmbDateSelect.SelectedItem = selectedDate;
            else
                cmbDateSelect.SelectedIndex = 0;
		}

		private void newCSVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				List<TransactionItem> newItems = new List<TransactionItem>();
                string account = string.Empty;
                DateTime lastDate = DateTime.MinValue;

				using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
				{
                    string headerLine = sr.ReadLine();
                    string line = string.Empty;
					while (!string.IsNullOrEmpty(line = sr.ReadLine()))
					{
                        while (line.Where(c => c == '"').Count() % 2 == 1) // Read until all quotes are matched
                            line += sr.ReadLine();
                        TransactionItem item = null;
                        try
                        {
                            item = TransactionItem.ImportItem(line, headerLine);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("File import aborted: \r\n{0}\r\n{1}", ex.Message, line));
                            return;
                        }
                        if (item.TransDate > lastDate)
                            lastDate = item.TransDate;
                        if (string.IsNullOrEmpty(account))
                            account = item.Account;
                        if (TransactionItem.GetCollection().Exists(t => t.Equals(item)))
                            continue;
						newItems.Add(item);
					}
                    TransactionItem.GetCollection().InsertBulk(newItems);
				}

                BackupTransactionFile(openFileDialog1.FileName, account, lastDate);

				InitGrids();
			}
		}

		private void dgTransactions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			CalculateTotals(lblTotalAmounts, (List<TransactionItem>)dgTransactions.DataSource);
            TransactionItem.GetCollection().Update(((TransactionItem)dgTransactions.Rows[e.RowIndex].DataBoundItem));
		}

		private void dgTransactions_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			TransactionItem t = ((List<TransactionItem>)dgTransactions.DataSource)[e.RowIndex];
			sb.AppendLine("Do you want to add a category match for this item?");
			sb.AppendLine();
			sb.AppendLine("Account: " + t.Account);
			sb.AppendLine("Amount: " + t.Amount);
			sb.AppendLine("Balance: " + t.Balance);
			sb.AppendLine("Category: " + t.Category);
			sb.AppendLine("Description: " + t.Description);
			sb.AppendLine("Memo: " + t.Memo);
			sb.AppendLine("Notes: " + t.Notes);
			sb.AppendLine("Date: " + t.TransDate.ToShortDateString());
			sb.AppendLine("Type: " + t.TransType.ToString());

            AddToCategoryMatch(sb.ToString(), t.Memo);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
            TransactionItem.CloseDatabase();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void monthsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Comparisons comp = new Comparisons((List<string>)cmbDateSelect.DataSource);
			comp.Show();
		}

		private void yearsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<string> dates = TransactionItem.GetCollection().FindAll().Select(i => i.TransDate.ToString("yyyy")).Distinct().ToList();

			Comparisons comp = new Comparisons(dates);
			comp.Show();
		}

		private void duplicateCheckToolStripMenuItem_Click(object sender, EventArgs e)
		{
            // TODO: Is this still needed?
			//List<TransactionItem> newItems = new List<TransactionItem>();
			//foreach (TransactionItem item in items)
			//{
			//	bool found = false;
			//	foreach (TransactionItem check in newItems)
			//		if (item.Equals(check))
			//			found = true;

			//	if (!found)
			//		newItems.Add(item);
			//}

			//items = newItems;

			GetAccounts();
			GetDates();
		}

		int sortDate = 1, sortAmount = 0, sortCategory = 0, sortNote = 0;
		private void dgTransactions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			List<TransactionItem> filteredList = (List<TransactionItem>)dgTransactions.DataSource;
			switch (e.ColumnIndex)
			{
				case 0: //Date
					if (sortDate == 0)
						sortDate = -1;
					sortDate *= -1; // Negate the current sort
					sortAmount = 0;
					sortCategory = 0;
					sortNote = 0;
					filteredList.Sort(delegate(TransactionItem t1, TransactionItem t2) { return t1.TransDate.CompareTo(t2.TransDate) * sortDate; });
					break;
				case 1: //Amount
					if (sortAmount == 0)
						sortAmount = -1;
					sortAmount *= -1;
					sortDate = 0;
					sortCategory = 0;
					sortNote = 0;
					filteredList.Sort(delegate(TransactionItem t1, TransactionItem t2) { return t1.Amount.CompareTo(t2.Amount) * sortAmount; });
					break;
				case 2: //Category
					if (sortCategory == 0)
						sortCategory = -1;
					sortCategory *= -1;
					sortDate = 0;
					sortAmount = 0;
					sortNote = 0;
					filteredList.Sort(delegate(TransactionItem t1, TransactionItem t2) { return t1.TransType.CompareTo(t2.TransType) * sortCategory; });
					break;
				case 3: //Note
					if (sortNote == 0)
						sortNote = -1;
					sortNote *= -1;
					sortDate = 0;
					sortAmount = 0;
					sortCategory = 0;
					filteredList.Sort(delegate(TransactionItem t1, TransactionItem t2) { return t1.Memo.CompareTo(t2.Memo) * sortNote; });
					break;
				default:
					return;
			}
			dgTransactions.DataSource = filteredList;
			dgTransactions.Refresh();
		}         
		#endregion

		#region Functions
		private void InitGrids()
		{
			dgTransactions.AutoGenerateColumns = false;
            dgcolCategory.DataSource = Enum.GetValues(typeof(TransactionItem.TransactionTypes)); //TransactionType.GetNames();

			GetAccounts();
			GetDates();
		}

		private void GetDates()
		{
            var dates = TransactionItem.GetCollection()
                .Find(i => i.Account == cmbAccount.SelectedItem.ToString() || cmbAccount.SelectedItem.ToString() == "All Accounts")
                .OrderByDescending(i => i.TransDate)
                .Select(i => i.TransDate.ToString(DATEFORMAT))
                .Distinct()
                .ToList();

            if (dates.Count == 0)
                dates.Add(DateTime.Now.ToString(DATEFORMAT));

            cmbDateSelect.DataSource = dates;
            cmbDateSelect.SelectedIndex = 0;
        }

		private void GetAccounts()
		{
			List<string> accounts = TransactionItem.GetCollection().FindAll().Select(i => i.Account).Distinct().ToList();
            accounts.Insert(0, "All Accounts");
			cmbAccount.DataSource = accounts;
            cmbAccount.SelectedIndex = 0;
		}

		private void CalculateTotals(Label label, List<TransactionItem> list)
		{
			// Figure out which transaction types we have
			List<TransactionItem.TransactionTypes> transTypes = new List<TransactionItem.TransactionTypes>();
			foreach (TransactionItem item in list)
				if (!transTypes.Contains(item.TransType))
					transTypes.Add(item.TransType);
			transTypes.Sort();

			// Reset the label
			label.Text = string.Empty;
			decimal total = 0;
			foreach (TransactionItem.TransactionTypes trans in transTypes) // Go through our list of transaction types
			{
				decimal subtotal = 0;
				foreach (TransactionItem item in list)
					if (item.TransType.ToString() == trans.ToString())
						subtotal += item.Amount;
				total += subtotal;
				label.Text += trans.ToString() + ": " + subtotal + Environment.NewLine;
			}
			label.Text += "__________________________" + Environment.NewLine;
			label.Text += "Total: " + total;
		}

		private void AddToCategoryMatch(string headerText, string category = "")
		{
			AddCategoryMatch match = new AddCategoryMatch(headerText, category);
			match.Show();
            match.FormClosed += new FormClosedEventHandler(Match_FormClosed);            
		}

        void Match_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<TransactionItem> filteredList = (List<TransactionItem>)dgTransactions.DataSource;

            foreach (TransactionItem trans in TransactionItem.GetCollection().Find(t => t.TransType == TransactionItem.TransactionTypes.Unselected))
            {
                var newType = CategoryMatch.GetType(trans.ToString());
                if (newType != trans.TransType)
                {
                    trans.TransType = newType;
                    TransactionItem.GetCollection().Update(trans);
                }
            }

            foreach (TransactionItem trans in filteredList.Where(f => f.TransType == TransactionItem.TransactionTypes.Unselected))
            {
                trans.TransType = CategoryMatch.GetType(trans.ToString());
            }
            // Reset the view   
            dgTransactions.DataSource = filteredList;
            dgTransactions.Refresh();
        }

        private void dgTransactions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Eventually we'll want to cast unknown types to Unselected
            //foreach(DataGridViewRow row in dgTransactions.Rows)
            //{
            //    if (!((List<string>)dgcolCategory.DataSource).Contains(row.Cells[2].Value))
            //        row.Cells[2].Value = "Unselected";
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedList = dgTransactions.SelectedRows.Cast<DataGridViewRow>().Select(r => (TransactionItem)r.DataBoundItem).ToList();
            var selectString = string.Join("\r\n", selectedList.Select(s => s.ToString()));
            if (MessageBox.Show(string.Format("Are you sure you want to delete:\r\n{0}", selectString), "Row delete confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TransactionItem.GetCollection().Delete(t => selectedList.Exists(s =>  s.Id == t.Id));
            }

            InitGrids();
        }

        private void BackupTransactionFile(string fileName, string account, DateTime lastDate)
        {
            string backupDirPath = Directory.GetCurrentDirectory() + "\\Trans backups";
            if (!Directory.Exists(backupDirPath))
                Directory.CreateDirectory(backupDirPath);

            string fileType = "Transactions";
            if (account.Contains("S01")) // savings
                fileType = "Savings " + fileType;
            else if (account.Contains("CITI")) // Citi card
                fileType = "Citi " + fileType;
            else if (account.Contains("Category"))
                fileType = account;


            string backupFile = Path.Combine(backupDirPath,
                            string.Format("{0} {1}.csv", fileType, lastDate.ToString("yyyy-MM-dd")));

            int i = 1;
            string backupFile2 = backupFile;
            while (File.Exists(backupFile2))
            {
                backupFile2 = backupFile.Replace(".csv", "(" + i++ + ").csv");
            }
            backupFile = backupFile2;

            File.Move(fileName, backupFile);
        }

        private void ImportCategoryMatching()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\CategoryMatching.txt"))
            {
                using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\CategoryMatching.txt"))
                {
                    List<CategoryMatch> matches = new List<CategoryMatch>();
                    string line;
                    while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                    {
                        string[] itemType = line.Split('\t');
                        if (itemType.Length != 2)
                            continue;
                        try
                        {
                            matches.Add(new CategoryMatch()
                            {
                                MatchString = itemType[0],
                                MatchType = (TransactionItem.TransactionTypes)Enum.Parse(typeof(TransactionItem.TransactionTypes), itemType[1])
                            });
                        }
                        catch { MessageBox.Show(line, "Item incorrectly set up: " + line); }
                    }

                    CategoryMatch.GetCollection().InsertBulk(matches);

                    foreach (TransactionItem trans in TransactionItem.GetCollection().Find(t => t.TransType == TransactionItem.TransactionTypes.Unselected))
                    {
                        var newType = CategoryMatch.GetType(trans.ToString());
                        if (newType != trans.TransType)
                        {
                            trans.TransType = newType;
                            TransactionItem.GetCollection().Update(trans);
                        }
                    }
                }

                BackupTransactionFile(Environment.CurrentDirectory + "\\CategoryMatching.txt", "Category Matching", DateTime.Now);
            }
        }
		#endregion		        

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BalanceGraph graph = new BalanceGraph();
            graph.GeneratePointsLists(GraphPeriod.Monthly);
            graph.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
        }
	}    
}
