using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;

namespace Mini_Project_1
{
    public partial class FormAdminHospitals : Form
    {
        public static string to;
        Form parentForm;
        public FormAdminHospitals(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void FormAdminHospitals_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                con.Open();
                String qry = "SELECT * FROM [PlasmaDonors$]";
                OleDbDataAdapter ad = new OleDbDataAdapter(qry, con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string from, messagebody, pass;
            from = "homequarantineapp@gmail.com";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.Subject = "Donor Information";
            to = "ngohotelhospital@gmail.com";

            string data = string.Empty;
            string data1 = string.Empty;
            string data2 = string.Empty;
            string data3 = string.Empty;
            string data4 = string.Empty;
            string data5 = string.Empty;

            OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
            con1.Open();
            String read1 = "SELECT * FROM [PlasmaDonors$]";
            OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
            OleDbDataReader r1 = readCmd1.ExecuteReader();
            while (r1.Read())
            {
                data1 = r1[0].ToString();
                data2 = r1[1].ToString();
                data3 = r1[2].ToString();
                data4 = r1[3].ToString();
                data5 = r1[4].ToString();
                data = data + "Donor Name: " + data1 + "\nAge: " + data2 + "\nSex: " + data3 + "\nBlood Group: " + data4 + "\nMobile Number: " + data5 + '\n' + System.Environment.NewLine + "";
            }
            con1.Close();

            messagebody = data;
            message.Body = messagebody;
            message.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            pass = "homequarantine";
            message.To.Add(to);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            smtp.Send(message);
            MessageBox.Show("Info mailed successfully.");

            FormAdminsOfHospitals newForm = new FormAdminsOfHospitals(this);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHomepage newForm = new FormHomepage(this);
            newForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUploadECards newForm = new FormUploadECards(this);
            newForm.Show();
        }
    }
}
