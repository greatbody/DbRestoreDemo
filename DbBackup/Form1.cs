using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbBackup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            var dbRestorer = new DbBackUpManager(@"Data Source=WH-SUNR01\SUNSOFT_OPEN;User ID=sa;Password=wintel");
            dbRestorer.backupDb("SunSoft_Share");
            dbRestorer.Dispose();
            MessageBox.Show("backup down", "hi");
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            var dbRestorer = new DbBackUpManager(@"Data Source=WH-SUNR01\SUNSOFT_OPEN;User ID=sa;Password=wintel");
            dbRestorer.restoreDb("SunSoft_Share");
            dbRestorer.Dispose();
            MessageBox.Show("restore down", "hi");
        }
    }
}
