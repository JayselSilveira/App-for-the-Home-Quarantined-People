using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Mini_Project_1
{
    public partial class FormFeedback : Form
    {
        Form parentForm;
        public FormFeedback(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Q1 = "";
            if (radioButton1.Checked)
            {
                Q1 = radioButton1.Text;
            }

            if (radioButton2.Checked)
            {
                Q1 = radioButton2.Text;
            }

            if (radioButton3.Checked)
            {
                Q1 = radioButton3.Text;
            }

            string Q2 = "";
            if (radioButton4.Checked)
            {
                Q2 = radioButton4.Text;
            }

            if (radioButton5.Checked)
            {
                Q2 = radioButton5.Text;
            }

            if (radioButton6.Checked)
            {
                Q2 = radioButton6.Text;
            }
            if (Q1 != "" && Q2 != "" && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String sql = "INSERT INTO [Feedback$](Q1, Q2, Q3, Q4) VALUES(@Q1, @Q2, @Q3, @Q4)";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.Add(new OleDbParameter("@Q1", Q1));
                    cmd.Parameters.Add(new OleDbParameter("@Q2", Q2));
                    cmd.Parameters.Add(new OleDbParameter("@Q3", textBox1.Text));
                    cmd.Parameters.Add(new OleDbParameter("@Q4", textBox2.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thanks for your feedback!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Fields should not be left blank!");
            }
        }
    }
}
