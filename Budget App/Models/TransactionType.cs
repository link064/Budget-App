using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_App.Models
{
    public class TransactionType : ModelBase<TransactionType>
    {
        public string Name { get; set; }

        public static List<string> GetNames()
        {
            var names = GetCollection().FindAll().Select(t => t.Name).ToList();
            if (!names.Contains("Unselected"))
                names.Insert(0, "Unselected");
            return names;
        }
    }
}
