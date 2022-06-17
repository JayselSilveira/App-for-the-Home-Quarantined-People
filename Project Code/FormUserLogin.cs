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
    public partial class FormUserLogin : Form
    {
        int flag = 0;
        Form parentForm;
        public FormUserLogin(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
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
                        if (textBox1.Text == r[0].ToString() && textBox2.Text == r[5].ToString())
                        {
                            flag = 1;
                            Global.isULoggedIn = 1;
                            Global.currUName = r[0].ToString();
                            Global.currUNumber = r[1].ToString();
                            Global.currUAddress = r[2].ToString();
                            Global.currUEmailId = r[4].ToString();
                            this.Close();
                            if (Global.donateWhat == "Med")
                            {
                                FormDonateMedicines newForm = new FormDonateMedicines(this);
                                newForm.Show();
                            }
                            else if (Global.donateWhat == "OxyCyl")
                            {
                                FormDonateOxyCylinders newForm = new FormDonateOxyCylinders(this);
                                newForm.Show();
                            }
                            else if (Global.donateWhat == "OxiMFS")
                            {
                                FormDonateOxiMaskFS newForm = new FormDonateOxiMaskFS(this);
                                newForm.Show();
                            }
                            else if (Global.donateWhat == "Plasma")
                            {
                                FormDonorInfoCheck newForm = new FormDonorInfoCheck(this);
                                newForm.Show();
                            }
                            else
                            {
                                FormHomepage newForm = new FormHomepage(this);
                                newForm.Show();
                            }
                            con.Close();
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        MessageBox.Show("Invalid Credentials.");
                        textBox1.Text = String.Empty;
                        textBox2.Text = String.Empty;
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
            FormUserReset newForm = new FormUserReset(this);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormUserForgot newForm = new FormUserForgot(this);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHomepage newForm = new FormHomepage(this);
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormUserRegister newForm = new FormUserRegister(this);
            newForm.Show();
        }
    }
}
