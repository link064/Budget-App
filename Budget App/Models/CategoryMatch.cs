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

        private static List<CategoryMatch> _matches;
        public static TransactionItem.TransactionTypes GetType(string value)
        {
            try
            {
                if (_matches == null)
                    _matches = GetCollection().FindAll().ToList();
                return _matches.FirstOrDefault(c => value.IndexOf(c.MatchString, StringComparison.OrdinalIgnoreCase) >= 0)?.MatchType ?? 
                    TransactionItem.TransactionTypes.Unselected;
            }
            catch
            {
                return TransactionItem.TransactionTypes.Unselected;
            }
        }

        public static void ResetCategoriesCache()
        {
            _matches = null;
        }
    }
}
