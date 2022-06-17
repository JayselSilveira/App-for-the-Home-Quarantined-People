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
    public partial class FormAdminReset : Form
    {
        int flag = 0;
        Form parentForm;
        public FormAdminReset(Form form)
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
                    String sql = "UPDATE [AdminDetails$] SET [Password] = @Password WHERE Username = @Username";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.Add(new OleDbParameter("@Password", textBox3.Text));
                    cmd.Parameters.Add(new OleDbParameter("@Username", textBox1.Text));

                    String read = "SELECT * FROM [AdminDetails$]";
                    OleDbCommand readCmd = new OleDbCommand(read, con);
                    OleDbDataReader r = readCmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (textBox1.Text == r[0].ToString() && textBox2.Text == r[1].ToString())
                        {
                            flag = 1;
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Your password has been changed.");
                            this.Close();
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        MessageBox.Show("Invalid Current Credentials.");
                        textBox1.Text = String.Empty;
                        textBox2.Text = String.Empty;
                        textBox3.Text = String.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("All fields should be filled!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormAdminForgot newForm = new FormAdminForgot(this);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
