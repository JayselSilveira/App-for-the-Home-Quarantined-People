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
    public partial class FormAdminNGO : Form
    {
        bool button1Clicked = false;
        public static string to;

        Form parentForm;
        public FormAdminNGO(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String qry = "SELECT * FROM [NGODonorsMed$]";
                    OleDbDataAdapter ad = new OleDbDataAdapter(qry, con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("NGOName = '{0}'", comboBox3.SelectedItem);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String qry = "SELECT * FROM [NGODonorsOC$]";
                    OleDbDataAdapter ad = new OleDbDataAdapter(qry, con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                    (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("NGOName = '{0}'", comboBox3.SelectedItem);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String qry = "SELECT * FROM [NGODonorsOMF$]";
                    OleDbDataAdapter ad = new OleDbDataAdapter(qry, con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds);
                    dataGridView3.DataSource = ds.Tables[0];
                    (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = string.Format("NGOName = '{0}'", comboBox3.SelectedItem);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                button1Clicked = true;
            }
            else
            {
                MessageBox.Show("Please select an NGO name!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null && button1Clicked)
            {
                try
                {
                    string from, messagebody, pass;
                    from = "homequarantineapp@gmail.com";
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(from);
                    message.Subject = "Donor Information";
                    string data = string.Empty;
                    string data1 = string.Empty;
                    string data2 = string.Empty;
                    string data3 = string.Empty;
                    string data4 = string.Empty;
                    string data5 = string.Empty;
                    string data6 = string.Empty;
                    string data7 = string.Empty;

                    if (comboBox3.SelectedItem.ToString() == "Asha Charitable Trust")
                    {
                        to = "ngohotelhospital@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Asha Charitable Trust")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Asha Charitable Trust")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Asha Charitable Trust")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }

                    if (comboBox3.SelectedItem.ToString() == "Amar Bharati Gram Vikas Sanstha")
                    {
                        to = "AmarBharatiGramVikasSanstha@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Amar Bharati Gram Vikas Sanstha")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Amar Bharati Gram Vikas Sanstha")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Amar Bharati Gram Vikas Sanstha")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }

                    if (comboBox3.SelectedItem.ToString() == "Green Triangle Society")
                    {
                        to = "GreenTriangleSociety@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Green Triangle Society")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Green Triangle Society")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Green Triangle Society")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }

                    if (comboBox3.SelectedItem.ToString() == "Margaret Bosco Bal Sonvstha")
                    {
                        to = "MargaretBoscoBalSonvstha@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Margaret Bosco Bal Sonvstha")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Margaret Bosco Bal Sonvstha")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Margaret Bosco Bal Sonvstha")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }

                    if (comboBox3.SelectedItem.ToString() == "Mother Earth")
                    {
                        to = "MotherEarth@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Mother Earth")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Mother Earth")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Mother Earth")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }

                    if (comboBox3.SelectedItem.ToString() == "Agnel Charities")
                    {
                        to = "AgnelCharities@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Agnel Charities")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Agnel Charities")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Agnel Charities")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }

                    if (comboBox3.SelectedItem.ToString() == "Gram Vikas Kendra")
                    {
                        to = "GramVikasKendra@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Gram Vikas Kendra")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Gram Vikas Kendra")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Gram Vikas Kendra")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }

                    if (comboBox3.SelectedItem.ToString() == "Community Resource Foundation")
                    {
                        to = "CommunityResourceFoundation@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Community Resource Foundation")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Community Resource Foundation")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Community Resource Foundation")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }

                    if (comboBox3.SelectedItem.ToString() == "Gomantak Rashtra Bhasha Vidyapith")
                    {
                        to = "GomantakRashtraBhashaVidyapith@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Gomantak Rashtra Bhasha Vidyapith")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Gomantak Rashtra Bhasha Vidyapith")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Gomantak Rashtra Bhasha Vidyapith")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }

                    if (comboBox3.SelectedItem.ToString() == "Presentation Society")
                    {
                        to = "PresentationSociety@gmail.com";

                        OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con1.Open();
                        String read1 = "SELECT * FROM [NGODonorsMed$]";
                        OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                        OleDbDataReader r1 = readCmd1.ExecuteReader();
                        while (r1.Read())
                        {
                            if (r1[7].ToString() == "Presentation Society")
                            {
                                data1 = r1[0].ToString();
                                data2 = r1[1].ToString();
                                data3 = r1[2].ToString();
                                data4 = r1[3].ToString();
                                data5 = r1[4].ToString();
                                data6 = r1[5].ToString();
                                data7 = r1[6].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nMedicine Name: " + data4 + "\nQuantity: " + data5 + "\nDate of Manufacture: " + data6 + "\nDate of Expiry: " + data7 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con1.Close();

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [NGODonorsOC$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();
                        while (r2.Read())
                        {
                            if (r2[6].ToString() == "Presentation Society")
                            {
                                data1 = r2[0].ToString();
                                data2 = r2[1].ToString();
                                data3 = r2[2].ToString();
                                data4 = r2[3].ToString();
                                data5 = r2[4].ToString();
                                data6 = r2[5].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nFull or Empty: " + data4 + "\nQuantity: " + data5 + "\nCapacity: " + data6 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con2.Close();

                        OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con3.Open();
                        String read3 = "SELECT * FROM [NGODonorsOMF$]";
                        OleDbCommand readCmd3 = new OleDbCommand(read3, con3);
                        OleDbDataReader r3 = readCmd3.ExecuteReader();
                        while (r3.Read())
                        {
                            if (r3[4].ToString() == "Presentation Society")
                            {
                                data1 = r3[0].ToString();
                                data2 = r3[1].ToString();
                                data3 = r3[2].ToString();
                                data4 = r3[3].ToString();
                                data = data + "Donor Name: " + data1 + "\nMobile Number: " + data2 + "\nType: " + data3 + "\nQuantity: " + data4 + '\n' + System.Environment.NewLine + "";
                            }
                        }
                        con3.Close();

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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("NGO Name should be entered and the View button should be clicked to mail the info.");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHomepage newForm = new FormHomepage(this);
            newForm.Show();
        }
    }
}