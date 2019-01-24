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
    public partial class Search : Form
    {
        List<TransactionItem> items;
        List<TransactionItem> results;

        #region Testing async
        private MethodDelegate dlgt;

        delegate void MethodDelegate(string text);
        private void SearchFunction(string text)
        {
            results = new List<TransactionItem>();
            string termString = text;
            if (string.IsNullOrEmpty(termString))
            {
                results = items;
            }
            else
            {
                List<string> terms = termString.Split(',').ToList();

                foreach (string term in terms)
                {
                    if (string.IsNullOrEmpty(term))
                        continue;

                    foreach (TransactionItem item in items)
                    {
                        if (results.Contains(item))
                            continue;

                        if (item.Category.ToLower().Contains(term)
                            || item.Description.ToLower().Contains(term)
                            || item.Memo.ToLower().Contains(term)
                            || item.Notes.ToLower().Contains(term)
                            || item.TransType.ToString().ToLower().Contains(term))
                            results.Add(item);
                    }
                }
            }

            results.Sort(delegate(TransactionItem t1, TransactionItem t2) { return t1.TransDate.CompareTo(t2.TransDate); });

            //dgTransactions.DataSource = results;
        }
        #endregion

        public Search()
        {
            InitializeComponent();
        }

        public Search(List<TransactionItem> items)
        {
            this.items = items;
            InitializeComponent();
            this.results = this.items;
            dgTransactions.AutoGenerateColumns = false;
            dgcolAmount.DataPropertyName = "Amount";
            dgcolDate.DataPropertyName = "TransDate";
            dgcolCategory.DataSource = Enum.GetValues(typeof(TransactionItem.TransactionTypes));
            dgcolCategory.DataPropertyName = "TransType";
            dgcolNote.DataPropertyName = "Memo";
            dgTransactions.DataSource = results;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            results = new List<TransactionItem>();
            string termString = txtSearch.Text;
            if (string.IsNullOrEmpty(termString))
            {
                results = items;
            }
            else
            {
                List<string> terms = termString.Split(',').ToList();

                foreach (string term in terms)
                {
                    if (string.IsNullOrEmpty(term))
                        continue;

                    foreach (TransactionItem item in items)
                    {
                        if (results.Contains(item))
                            continue;

                        if (item.Category.ToLower().Contains(term)
                            || item.Description.ToLower().Contains(term)
                            || item.Memo.ToLower().Contains(term)
                            || item.Notes.ToLower().Contains(term)
                            || item.TransType.ToString().ToLower().Contains(term))
                            results.Add(item);
                    }
                }
            }

            results.Sort(delegate(TransactionItem t1, TransactionItem t2) { return t1.TransDate.CompareTo(t2.TransDate); });

            dgTransactions.DataSource = results;
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
    }
}
