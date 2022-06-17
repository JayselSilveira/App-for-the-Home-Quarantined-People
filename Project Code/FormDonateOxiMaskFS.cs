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
    public partial class FormDonateOxiMaskFS : Form
    {
        Form parentForm;
        public FormDonateOxiMaskFS(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (!string.IsNullOrEmpty(textBox2.Text) && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String sql = "INSERT INTO [NGODonorsOMF$](PatientName, MobileNumber, Type, Quantity, NGOName) VALUES(@PatientName, @MobileNumber, @Type, @Quantity, @NGOName)";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    if (Global.userName != string.Empty && Global.userMobNo != string.Empty)
                    {
                        Global.userName = Global.currUName;
                        Global.userMobNo = Global.currUNumber;
                    }
                    cmd.Parameters.Add(new OleDbParameter("@PatientName", Global.userName));
                    cmd.Parameters.Add(new OleDbParameter("@MobileNumber", Global.userMobNo));
                    cmd.Parameters.Add(new OleDbParameter("@Type", comboBox2.SelectedItem));
                    cmd.Parameters.Add(new OleDbParameter("@Quantity", textBox2.Text));
                    cmd.Parameters.Add(new OleDbParameter("@NGOName", comboBox3.SelectedItem));
                    cmd.ExecuteNonQuery();
                    textBox2.Text = String.Empty;
                    comboBox2.SelectedItem = null;
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

        private void FormDonateOxiMaskFS_Load(object sender, EventArgs e)
        {
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
    }
}
