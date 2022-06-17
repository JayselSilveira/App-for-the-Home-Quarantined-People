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
    public partial class FormAdminRestCheckElig : Form
    {
        int flag = 0;
        Form parentForm;
        public FormAdminRestCheckElig(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormAdminRestaurants newForm = new FormAdminRestaurants(this);
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Confirmation = "";
            if (radioButton1.Checked)
            {
                Confirmation = "Yes";
            }

            if (radioButton2.Checked)
            {
                Confirmation = "No";
            }

            if (!string.IsNullOrEmpty(textBox4.Text) && Confirmation != "")
            {
                System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (textBox4.Text.Length > 0)
                {
                    if (!rEMail.IsMatch(textBox4.Text))
                    {
                        MessageBox.Show("Invalid Email format.", "Error", MessageBoxButtons.OK);
                        textBox4.SelectAll();
                    }
                    else
                    {
                        try
                        {
                            OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                            con.Open();
                            String sql = "UPDATE [RestCustomers$] SET Confirmation = @Confirmation WHERE EmailId = @EmailId";
                            OleDbCommand cmd = new OleDbCommand(sql, con);
                            cmd.Parameters.Add(new OleDbParameter("@Confirmation", Confirmation));
                            cmd.Parameters.Add(new OleDbParameter("@EmailId", textBox4.Text));
                            String read = "SELECT * FROM [RestCustomers$]";
                            OleDbCommand readCmd = new OleDbCommand(read, con);
                            OleDbDataReader r = readCmd.ExecuteReader();
                            while (r.Read())
                            {
                                if (textBox4.Text == r[3].ToString())
                                {
                                    flag = 1;
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    MessageBox.Show("Submitted successfully!");
                                    this.Close();
                                    FormAdminRestaurants newForm = new FormAdminRestaurants(this);
                                    newForm.Show();
                                    break;
                                }
                            }
                            if (flag == 0)
                            {
                                MessageBox.Show("Kindly re-check the mail!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Fields should not be left blank!");
            }
        }
    }
}
