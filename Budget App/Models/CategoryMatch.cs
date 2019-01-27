using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_App.Models
{
    public class CategoryMatch : ModelBase<CategoryMatch>
    {
        public string MatchString { get; set; }

        public TransactionItem.TransactionTypes MatchType { get; set; }

        public static TransactionItem.TransactionTypes GetType(string memo, string description)
        {
            try
            {
                return GetCollection()
                    .Find(c => memo.IndexOf(c.MatchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                               description.IndexOf(c.MatchString, StringComparison.OrdinalIgnoreCase) >= 0)
                    .FirstOrDefault()?.MatchType ?? 
                    TransactionItem.TransactionTypes.Unselected;
            }
            catch
            {
                return TransactionItem.TransactionTypes.Unselected;
            }
        }
    }
}
