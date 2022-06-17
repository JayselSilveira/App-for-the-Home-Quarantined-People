using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Data.OleDb;

namespace Mini_Project_1
{
    public partial class FormMailCertificate : Form
    {
        Form parentForm;
        public FormMailCertificate(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (File.Exists("D://HomeQuarantinedApp/Covid Positive Certificate"))
            {
                string fileName = Path.GetFileName("D://HomeQuarantinedApp/Covid Positive Certificate");
                label4.Text += fileName + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
            {
                using (MailMessage mm = new MailMessage(textBox4.Text.Trim(), "homequarantineapp@gmail.com".Trim()))
                {
                    mm.Subject = "Covid Positive Certificate";
                    mm.Body = "Covid Positive Certificate of " + Global.currUName + "";
                    foreach (string filePath in openFileDialog1.FileNames)
                    {
                        if (File.Exists(filePath))
                        {
                            string fileName = Path.GetFileName(filePath);
                            mm.Attachments.Add(new Attachment(filePath));
                        }
                    }
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(textBox4.Text.Trim(), textBox5.Text.Trim());
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    MessageBox.Show("Email sent successfully!", "Message");
                    this.Close();
                }
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String sql = "INSERT INTO [RestCustomers$]([Name], MobileNumber, Address, EmailId, RestaurantName, Meal) VALUES(@Name, @MobileNumber, @Address, @EmailId, @RestaurantName, @Meal)";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.Add(new OleDbParameter("@Name", Global.currUName));
                    cmd.Parameters.Add(new OleDbParameter("@MobileNumber", Global.currUNumber));
                    cmd.Parameters.Add(new OleDbParameter("@Address", Global.currUAddress));
                    cmd.Parameters.Add(new OleDbParameter("@EmailId", Global.currUEmailId));
                    cmd.Parameters.Add(new OleDbParameter("@RestaurantName", Global.restName));
                    cmd.Parameters.Add(new OleDbParameter("@Meal", Global.meal));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Order submitted successfully! Kindly wait for the confirmation. If you do not get a confirmation mail within 2 hours, it means that you are ineligible.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
