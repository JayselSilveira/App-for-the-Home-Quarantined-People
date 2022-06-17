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
    public partial class FormDonateMedicines : Form
    {
        Form parentForm;
        public FormDonateMedicines(Form form)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && dateTimePicker1.Value != null && dateTimePicker2.Value != null && comboBox3.SelectedItem != null)
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String sql = "INSERT INTO [NGODonorsMed$](PatientName, MobileNumber, Type, [Name], Quantity, DateOfManufacture, DateOfExpiry, NGOName) VALUES(@PatientName, @MobileNumber, @Type, @Name, @Quantity, @DOM, @DOE, @NGOName)";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    if (Global.userName != string.Empty && Global.userMobNo != string.Empty)
                    {
                        Global.userName = Global.currUName;
                        Global.userMobNo = Global.currUNumber;
                    }
                    cmd.Parameters.Add(new OleDbParameter("@PatientName", Global.userName));
                    cmd.Parameters.Add(new OleDbParameter("@MobileNumber", Global.userMobNo));
                    cmd.Parameters.Add(new OleDbParameter("@Type", label2.Text));
                    cmd.Parameters.Add(new OleDbParameter("@Name", textBox1.Text));
                    cmd.Parameters.Add(new OleDbParameter("@Quantity", textBox2.Text));
                    cmd.Parameters.Add(new OleDbParameter("@DOM", dateTimePicker1.Value.Date.ToString()));
                    cmd.Parameters.Add(new OleDbParameter("@DOE", dateTimePicker2.Value.Date.ToString()));
                    cmd.Parameters.Add(new OleDbParameter("@NGOName", comboBox3.SelectedItem));
                    cmd.ExecuteNonQuery();
                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;
                    comboBox3.SelectedItem = null;
                    con.Close();
                    MessageBox.Show("Thanks for donating!");
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDonateMedicines_Load(object sender, EventArgs e)
        {
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}
