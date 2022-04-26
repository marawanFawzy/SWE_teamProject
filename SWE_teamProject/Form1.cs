using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;


namespace SWE_teamProject
{
    public partial class Form1 : Form
    {
        OracleDataAdapter adapter;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void load_Click(object sender, EventArgs e)
        {
            string ordb = "Data source=orcl;User Id=scott; Password = tiger; ";
            string cmdstr = "";
            if (voter.Checked)
            {
                cmdstr = "select * from users WHERE FLAG = 0";
            }
            else
            {
                cmdstr = "select * from users WHERE FLAG = 1";
            }
            adapter = new OracleDataAdapter(cmdstr, ordb);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void save_Click(object sender, EventArgs e)
        {
            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }
    }
}
