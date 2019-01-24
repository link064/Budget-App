using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_App.Models
{
    public class ImportSpec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Delimiter { get; set; }
        public List<ImportSpecCol> ImportSpecCols { get; set; }
    }

    public class ImportSpecCol
    {
        public int ColIndex { get; set; }
        public string ColDest { get; set; }
    }
}
