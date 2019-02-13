using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Budget_App.Views
{
    public partial class CSVInputSetup : Form
    {
        private List<string> lines = new List<string>();

        public CSVInputSetup()
        {
            InitializeComponent();
        }

        public CSVInputSetup(string filename)
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader(filename))
            {
                string line = string.Empty;
                while(!string.IsNullOrEmpty(line = sr.ReadLine()) && lines.Count < 6)
                {
                    lines.Add(line);
                }
            }

            UpdateGridView();
        }

        private void txtDelimiter_TextChanged(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void UpdateGridView()
        {
            dgvInputSetup.AutoGenerateColumns = true;
            List<string[]> splitLines = lines.Select(l => l.Split(new string[] { txtDelimiter.Text }, StringSplitOptions.None)).ToList();
            dgvInputSetup.DataSource = splitLines;
            dgvInputSetup.Refresh();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            // Save the ImportSpec
        }
    }
}
