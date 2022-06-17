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
    public partial class FormAdminLogin : Form
    {
        int flag = 0;
        Form parentForm;
        public FormAdminLogin(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && comboBox1.SelectedItem != null)
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();

                    String read = "SELECT * FROM [AdminDetails$]";
                    OleDbCommand readCmd = new OleDbCommand(read, con);
                    OleDbDataReader r = readCmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (textBox1.Text == r[0].ToString() && textBox2.Text == r[1].ToString() && comboBox1.SelectedItem.ToString() == r[2].ToString())
                        {
                            flag = 1;
                            Global.isALoggedIn = 1;
                            this.Close();
                            if (comboBox1.SelectedItem.ToString() == "NGO")
                            {
                                Global.isAdNGO = 1;
                                FormAdminNGO newForm = new FormAdminNGO(this);
                                newForm.Show();
                                con.Close();
                                break;

                            }
                            if (comboBox1.SelectedItem.ToString() == "Restaurants")
                            {
                                Global.isAdRestaurants = 1;
                                FormAdminRestaurants newForm = new FormAdminRestaurants(this);
                                newForm.Show();
                                con.Close();
                                break;
                            }
                            if (comboBox1.SelectedItem.ToString() == "Hospitals")
                            {
                                Global.isAdHospitals = 1;
                                FormAdminHospitals newForm = new FormAdminHospitals(this);
                                newForm.Show();
                                con.Close();
                                break;
                            }
                            if (comboBox1.SelectedItem.ToString() == "Management")
                            {
                                Global.isAdManagement = 1;
                                FormAdminManagement newForm = new FormAdminManagement(this);
                                newForm.Show();
                                con.Close();
                                break;
                            }
                            this.Close();
                        }
                    }
                    if (flag == 0)
                    {
                        MessageBox.Show("Invalid Credentials.");
                        textBox1.Text = String.Empty;
                        textBox2.Text = String.Empty;
                        comboBox1.SelectedItem = null;
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
            FormAdminReset newForm = new FormAdminReset(this);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAdminForgot newForm = new FormAdminForgot(this);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHomepage newForm = new FormHomepage(this);
            newForm.Show();
        }

        private void FormAdminLogin_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}
