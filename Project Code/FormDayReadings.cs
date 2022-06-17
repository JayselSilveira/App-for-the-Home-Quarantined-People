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
    public partial class FormDayReadings : Form
    {
        Form parentForm;
        public FormDayReadings(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDayReadings_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                con.Open();

                String read = "SELECT * FROM [VitalSigns$]";
                OleDbCommand readCmd = new OleDbCommand(read, con);
                OleDbDataReader r1 = readCmd.ExecuteReader();
                while (r1.Read())
                {
                    label1.Text = "Morning";
                    if (label1.Text == r1[0].ToString())
                    {
                        label2.Text = r1[1].ToString();
                        label3.Text = r1[2].ToString();
                        label7.Text = r1[3].ToString();

                        this.Controls.Add(label2);
                        this.Controls.Add(label3);
                        this.Controls.Add(label7);
                    }
                }
                r1.Close();
                OleDbDataReader r2 = readCmd.ExecuteReader();
                while (r2.Read())
                {
                    label8.Text = "Afternoon";
                    if (label8.Text == r2[0].ToString())
                    {
                        label12.Text = r2[1].ToString();
                        label14.Text = r2[2].ToString();
                        label15.Text = r2[3].ToString();

                        this.Controls.Add(label12);
                        this.Controls.Add(label14);
                        this.Controls.Add(label15);
                    }
                }
                r2.Close();
                OleDbDataReader r3 = readCmd.ExecuteReader();
                while (r3.Read())
                {
                    label16.Text = "Night";
                    if (label16.Text == r3[0].ToString())
                    {
                        label20.Text = r3[1].ToString();
                        label21.Text = r3[2].ToString();
                        label22.Text = r3[3].ToString();

                        this.Controls.Add(label20);
                        this.Controls.Add(label21);
                        this.Controls.Add(label22);
                    }
                }
                r3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
