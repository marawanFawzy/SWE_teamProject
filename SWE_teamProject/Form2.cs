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
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.CommandText = "SELECT USER_NAME,AGE,STATMENT FROM USERS WHER SSN=:id AND FLAG=:f ";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id", int.Parse(comboBox1.SelectedItem.ToString()));
            c.Parameters.Add("f", 1);

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
            bool flag = false;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT SSN,PASS FROM USERS WHER SSN=:id AND PASS=:pass ";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", int.Parse(textBox4.Text.ToString()));
            cmd.Parameters.Add("pass", textBox5.Text.ToString());
            int rcmd = cmd.ExecuteNonQuery();
            if (rcmd != 0)
            {
                flag = true;
            }

            if (flag)
            {
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "INSERT INTO VOTE VALUE(:VOTE_ID,:VOTER_SSN,:CANDIDATE_SSN,:E_ID)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("CANDIDATE_SSN", int.Parse(comboBox1.SelectedItem.ToString()));
                c.Parameters.Add("VOTER_SSN", int.Parse(textBox4.Text.ToString()));
                c.Parameters.Add("VOTE_ID", 55555);///////////////////////
                c.Parameters.Add("E_ID", 22222);//////////////////////////

                int r = c.ExecuteNonQuery();
                if (r != 0)
                {
                    MessageBox.Show("You Voted");
                }
            }
            else
            {
                MessageBox.Show("Check Your SSN Or Password");
            }
        }
        // pepeol voted
        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "SELECTMULTIPLEROW";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("users", OracleDbType.RefCursor, ParameterDirection.Output);
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
            c.Parameters.Add("ssn", int.Parse(textBox6.Text));
           // c.Parameters.Add("ssn", OracleDbType.Int16, ParameterDirection.Input);/////////////////////////////
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
    }
}
