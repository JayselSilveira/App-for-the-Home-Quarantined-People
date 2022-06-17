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

namespace Mini_Project_1
{
    public partial class FormMailImage : Form
    {
        Form parentForm;
        public FormMailImage(Form form)
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
            if (File.Exists("D://HomeQuarantinedApp/Nia_Sharma's E-Health Card"))
            {
                string fileName = Path.GetFileName("D://HomeQuarantinedApp/Nia_Sharma's E-Health Card");
                label4.Text += fileName + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
            {
                using (MailMessage mm = new MailMessage(textBox4.Text.Trim(), textBox1.Text.Trim()))
                {
                    mm.Subject = textBox2.Text;
                    mm.Body = textBox3.Text;
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
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    MessageBox.Show("Email sent successfully!", "Message");
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
