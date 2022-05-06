using Oracle.DataAccess.Client;
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

namespace SWE_teamProject
{
    public partial class Form2 : Form
    {
        string ordb = "Data source=orcl1;User Id=hr; Password=hr;";
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            load_cmb();
        }

        public void load_cmb()
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "SELECT SSN FROM USERS WHERE FLAG=1 ";
            c.CommandType = CommandType.Text;
            OracleDataReader dr = c.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["SSN"]);
            }
            dr.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "SELECT USER_NAME,AGE,STATMENT FROM USERS WHERE SSN=:id";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id",long.Parse(comboBox1.SelectedItem.ToString()));
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["USER_NAME"].ToString();
                textBox2.Text = dr["AGE"].ToString();
                textBox3.Text = dr["STATMENT"].ToString();
            }
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT SSN FROM USERS WHERE SSN=:id AND PASS=:pass ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", long.Parse(textBox4.Text.ToString()));
            cmd.Parameters.Add("pass", textBox5.Text.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                insert_vote();
            }
            else
            {
                MessageBox.Show("Check Your SSN Or Password");
            }
            dr.Close();
        }
        public void insert_vote()
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "INSERT INTO VOTE VALUES(:VOTE_ID,:VOTER_SSN,:CANDIDATE_SSN,:E_ID)";
           // c.CommandType = CommandType.Text;
            c.Parameters.Add("CANDIDATE_SSN",long.Parse(comboBox1.SelectedItem.ToString()));
            c.Parameters.Add("VOTER_SSN",long.Parse(textBox4.Text.ToString()));
            c.Parameters.Add("VOTE_ID",long.Parse(textBox8.Text.ToString()));
            c.Parameters.Add("E_ID", 1);
            try
            {
                int r = c.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("You Voted");
                }
            }
            catch
            {
                MessageBox.Show("Try Agine Later");
            }
            
        }
        // pepeol voted
        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "SELECTMULTIPLEROW";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("users_voted", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader rd = c.ExecuteReader();
            while(rd.Read())
            {
                comboBox2.Items.Add(rd["USER_NAME"]);
            }
            rd.Close();
        }
        //candidate votes
        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "SELECTONEROW";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("ssn", long.Parse(textBox6.Text));
            c.Parameters.Add("voted", OracleDbType.Int16,ParameterDirection.Output);
            c.ExecuteNonQuery();
            try
            {
                textBox7.Text = c.Parameters["voted"].Value.ToString();
            }
            catch
            {
                textBox7.Text = "ERROR";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}
