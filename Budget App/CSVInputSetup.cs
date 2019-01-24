using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Budget_App
{
    public partial class CSVInputSetup : Form
    {
        public CSVInputSetup()
        {
            InitializeComponent();
        }

        public CSVInputSetup(string filename)
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader(filename))
            {

            }
        }

        private void txtDelimiter_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

        }
    }
}
