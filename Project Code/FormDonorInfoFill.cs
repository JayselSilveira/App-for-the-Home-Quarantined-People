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
    public partial class FormDonorInfoFill : Form
    {
        Form parentForm;
        public FormDonorInfoFill(Form form)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Sex = "";
            if (radioButton1.Checked)
            {
                Sex = radioButton1.Text;
            }

            if (radioButton2.Checked)
            {
                Sex = radioButton2.Text;
            }
            if (Sex != "" && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && comboBox4.SelectedItem != null && !string.IsNullOrEmpty(textBox3.Text))
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String sql = "INSERT INTO [PlasmaDonors$]([Name], Age, Sex, BloodGroup, MobileNumber) VALUES(@Name, @Age, @Sex, @BloodGroup, @MobileNumber)";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.Add(new OleDbParameter("@Name", textBox1.Text));
                    cmd.Parameters.Add(new OleDbParameter("@Age", textBox2.Text));
                    cmd.Parameters.Add(new OleDbParameter("@Sex", Sex));
                    cmd.Parameters.Add(new OleDbParameter("@BloodGroup", comboBox4.SelectedItem));
                    cmd.Parameters.Add(new OleDbParameter("@MobileNumber", textBox3.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Application submitted successfully!");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
