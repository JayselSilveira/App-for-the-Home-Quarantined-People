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
    public partial class FormUserRegister : Form
    {
        String HNo;
        Form parentForm;
        public FormUserRegister(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrEmpty(textBox6.Text) && comboBox1.SelectedItem != null && comboBox3.SelectedItem != null && comboBox2.SelectedItem != null && comboBox4.SelectedItem != null)
            {
                System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (textBox3.Text.Length > 0)
                {
                    if (!rEMail.IsMatch(textBox3.Text))
                    {
                        MessageBox.Show("Invalid Email format.", "Error", MessageBoxButtons.OK);
                        textBox3.SelectAll();
                    }
                    else
                    {
                        try
                        {
                            OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                            con.Open();
                            HNo = "H.No. ";
                            String sql = "INSERT INTO [Users$]([Name], MobileNumber, Address, BloodGroup, EmailId, [Password], Age) VALUES(@Name, @MobileNumber, '" + HNo + textBox4.Text + ", " + textBox8.Text + ", " + textBox9.Text + ", " + comboBox1.SelectedItem + ", " + comboBox3.SelectedItem + ", " + comboBox2.SelectedItem + ", " + textBox5.Text + "' , @BloodGroup, @EmailId, @Password, @Age)";
                            OleDbCommand cmd = new OleDbCommand(sql, con);
                            cmd.Parameters.Add(new OleDbParameter("@Name", textBox1.Text));
                            cmd.Parameters.Add(new OleDbParameter("@MobileNumber", textBox2.Text));
                            cmd.Parameters.Add(new OleDbParameter("@BloodGroup", comboBox4.SelectedItem));
                            cmd.Parameters.Add(new OleDbParameter("@EmailId", textBox3.Text));
                            cmd.Parameters.Add(new OleDbParameter("@Password", textBox7.Text));
                            cmd.Parameters.Add(new OleDbParameter("@Age", textBox6.Text));
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("You have been successfully registered!");
                            this.Close();
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
                MessageBox.Show("All fields should be filled!");
            }
        }

        private void FormPatientRegister_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox4.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
