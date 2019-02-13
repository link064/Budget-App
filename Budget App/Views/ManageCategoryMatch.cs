using Budget_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Budget_App.Views
{
    public partial class ManageCategoryMatch : Form
    {
        public ManageCategoryMatch()
        {
            InitializeComponent();
            dgcolMatchType.DataSource = Enum.GetValues(typeof(TransactionItem.TransactionTypes)); //TransactionType.GetNames();
            dgCategoryMatch.AutoGenerateColumns = false;
            dgCategoryMatch.DataSource = CategoryMatch.GetCollection().FindAll().OrderBy(c => c.MatchString).ToList();
            dgCategoryMatch.Refresh();
        }
    }
}
