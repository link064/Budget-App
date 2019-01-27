using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Budget_App.Models
{
	public class TransactionItem : ModelBase<TransactionItem>
	{
        #region Properties
        private string _account;
		public string Account
		{
			get
			{
				return _account;
			}
			set
			{
				_account = value;
			}
		}

		private DateTime _transDate;
		public DateTime TransDate
		{
			get
			{
				return _transDate;
			}
			set
			{
				_transDate = value;
			}
		}

		private decimal _amount;
		public decimal Amount
		{
			get
			{
				return _amount;
			}
			set
			{
				_amount = value;
			}
		}

		private decimal _balance;
		public decimal Balance
		{
			get
			{
				return _balance;
			}
			set
			{
				_balance = value;
			}
		}

		private string _category;
		public string Category
		{
			get
			{
				return _category;
			}
			set
			{
				_category = value;
			}
		}

		private string _description;
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		private string _memo;
		public string Memo
		{
			get
			{
				return _memo;
			}
			set
			{
				_memo = value;
			}
		}

		private string _notes;
		public string Notes
		{
			get
			{
				return _notes;
			}
			set
			{
				_notes = value;
			}
		}

		private TransactionTypes _transType;
		public TransactionTypes TransType
		{
			get
			{
				return _transType;
			}
			set
			{
				_transType = value;
			}
		}
        #endregion

        #region Methods
        public static TransactionItem ImportItem(string line, string header, bool isMaster = false)
        {
            TransactionItem item = new TransactionItem();
            // Hack to determine which bank this is
            //"Status","Date","Description","Debit","Credit"
            if (header.Contains("\"Status\",\"Date\",\"Description\",\"Debit\",\"Credit\""))
                item.ReadCitiLine(line);
            //account,date,amount,balance,category,description,memo,notes
            else if (header.Contains("account,date,amount,balance,category,description,memo,notes") || isMaster)
                item.ReadLine(line);
            else
                throw new Exception("Unknown account type file detected. Check that the header line hasn't changed");

            return item;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != this.GetType())
                return false;

            TransactionItem item = (TransactionItem)obj;

            return string.Equals(this.Account, item.Account, StringComparison.CurrentCultureIgnoreCase) &&
                   this.Amount == item.Amount &&
                   this.Balance == item.Balance &&
                   this.TransDate == item.TransDate;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                Account,
                TransDate.ToString("M/d/yyyy"),
                Amount > 0 ? "$" + Amount : "($" + Amount * -1 + ")",
                Balance > 0 ? "$" + Balance : "($" + Balance * -1 + ")",
                Category,
                Description,
                Memo,
                Notes,
                TransType.ToString());
        }

        public void ReadLine(string line)
        {
            string[] cols = line.Split(',');
            if (cols.Length < 8 || cols.Length > 9)
                throw new ArgumentException("Invalid line length");

            Account = cols[0];
            TransDate = DateTime.Parse(cols[1]);
            Amount = StringToDecimal(cols[2]);
            Balance = StringToDecimal(cols[3]);
            Category = cols[4];
            Description = cols[5];
            Memo = cols[6];
            Notes = cols[7];
            TransType = cols.Length == 9 ? (TransactionTypes)Enum.Parse(typeof(TransactionTypes), cols[8]) : TransactionTypes.Unselected;

            if (TransType == TransactionTypes.Unselected)
                TransType = CategoryMatch.GetType(Memo, Description);

            if (TransType == TransactionTypes.Unselected && Description.Contains("Check Withdrawal") && Amount < 0)
                TransType = TransactionTypes.Bill;
        }

        private void ReadCitiLine(string line)
        {
            string[] cols = line.Split(new string[] { "\",\"" }, StringSplitOptions.None).Select(s => s.Trim('"').Replace(",", "")).ToArray();
            if (cols.Length != 5)
                throw new ArgumentException("Invalid Citi line length - " + line);

            Account = "CITI";
            TransDate = DateTime.Parse(cols[1]);

            string debit = string.Format("({0})", string.IsNullOrEmpty(cols[3]) ? "0" : cols[3]);
            string credit = string.IsNullOrEmpty(cols[4]) ? "0" : cols[4];
            Amount = StringToDecimal(debit) + StringToDecimal(credit); // Citi splits out the debit and credit columns

            Balance = 0m; // Citi doesn't include balance -- problematic...
            Category = ""; // Citi doesn't include category
            Description = cols[2];
            Memo = cols[2]; // Citi doesn't have a memo column so we'll duplicate memo
            Notes = cols[0]; // Using status as notes - could change
            TransType = CategoryMatch.GetType(Memo, Description);
        }

        private static decimal StringToDecimal(string item)
        {
            decimal value = 1;
            string itemValue = item.Replace("$", "").Replace(",", "");
            if (item.Contains("(") && item.Contains(")")) // value is negative
            {
                value = -1;
                itemValue = itemValue.Replace("(", "").Replace(")", "");
            }

            return decimal.Parse(itemValue) * value;
        }
        #endregion

        public enum TransactionTypes
		{
			Bill,
			Entertainment,
			Gas,
			Groceries,
			Income,
			Other,
			Unselected
		}
	}
}
