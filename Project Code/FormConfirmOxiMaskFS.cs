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
    public partial class FormConfirmOxiMaskFS : Form
    {
        int flag = 0;
        Form parentForm;
        public FormConfirmOxiMaskFS(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String read = "SELECT * FROM [Users$]";
                    OleDbCommand readCmd = new OleDbCommand(read, con);
                    OleDbDataReader r = readCmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (textBox1.Text == r[0].ToString() && textBox2.Text == r[5].ToString() && textBox3.Text == r[1].ToString())
                        {
                            flag = 1;
                            Global.userName = r[0].ToString();
                            Global.userMobNo = r[1].ToString();
                            Global.donateWhat = "OxiMFS";
                            this.Close();
                            FormUserLogin newForm = new FormUserLogin(this);
                            newForm.Show();
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        MessageBox.Show("User not registered.");
                        this.Close();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("You need to enter name, mobile number and password to verify.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
