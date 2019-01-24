using Budget_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Budget_App
{
	public class TypeMatching
	{
		static Dictionary<string, TransactionItem.TransactionTypes> memoTypes;

		public static void LoadTypes()
		{
			memoTypes = new Dictionary<string, TransactionItem.TransactionTypes>();
			using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\CategoryMatching.txt"))
			{
				string line;
				while (!string.IsNullOrEmpty(line = sr.ReadLine()))
				{
					string[] itemType = line.Split('\t');
					if (itemType.Length != 2)
						continue;
					try { memoTypes.Add(itemType[0], (TransactionItem.TransactionTypes)Enum.Parse(typeof(TransactionItem.TransactionTypes), itemType[1])); }
					catch { System.Windows.Forms.MessageBox.Show(line, "Item incorrectly set up"); }
				}
			}
		}

		public static TransactionItem.TransactionTypes GetType(string memo, string description)
		{
			try
			{
				if (memoTypes == null)
					LoadTypes();
				if (memoTypes.Count == 0)
					LoadTypes();

				foreach (KeyValuePair<string, TransactionItem.TransactionTypes> kvp in memoTypes)
					if (memo.Contains(kvp.Key))
						return kvp.Value;

                foreach (KeyValuePair<string, TransactionItem.TransactionTypes> kvp in memoTypes)
                    if (description.Contains(kvp.Key))
                        return kvp.Value;

				// Not found
				return TransactionItem.TransactionTypes.Unselected;
			}
			catch
			{
				return TransactionItem.TransactionTypes.Unselected;
			}
		}
	}
}
