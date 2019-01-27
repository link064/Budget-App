using Budget_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Budget_App.Views
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();

            dgTransactions.AutoGenerateColumns = false;
            dgcolAmount.DataPropertyName = "Amount";
            dgcolDate.DataPropertyName = "TransDate";
            dgcolCategory.DataSource = Enum.GetValues(typeof(TransactionItem.TransactionTypes));
            dgcolCategory.DataPropertyName = "TransType";
            dgcolDescription.DataPropertyName = "Description";
            dgcolMemo.DataPropertyName = "Memo";

            TxtSearch_TextChanged(null, null);
        }
        
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var results = TransactionItem.GetCollection().FindAll().ToList();

            List<string> terms = (txtSearch.Text ?? string.Empty).Split(',').Where(t => !string.IsNullOrEmpty(t)).ToList();
            if (terms.Count > 0)
                results = results.Where(trans => terms.Any(term =>
                    FindTerm(term, trans.Category, trans.Description, trans.Memo, trans.Notes, trans.TransType.ToString()))).ToList();

            results.Sort(delegate (TransactionItem t1, TransactionItem t2) { return t1.TransDate.CompareTo(t2.TransDate); });

            results = results.Take(100).ToList();

            dgTransactions.DataSource = results;
        }
        
        int sortDate = 1, sortAmount = 0, sortCategory = 0, sortNote = 0;
        private void DgTransactions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private bool FindTerm(string term, params string[] values)
        {
            const StringComparison c = StringComparison.OrdinalIgnoreCase;

            if (string.IsNullOrEmpty(term))
                return false;

            foreach(string value in values)
            {
                if (!string.IsNullOrEmpty(value) && value.IndexOf(term, c) >= 0)
                    return true;
            }

            return false;
        }
    }
}
