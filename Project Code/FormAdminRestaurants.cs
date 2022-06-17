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
    public partial class FormAdminRestaurants : Form
    {
        int flag = 0, ConfUp = 0;
        public static string to;
        Form parentForm;
        public FormAdminRestaurants(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void FormAdminRestaurants_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                con.Open();
                String qry = "SELECT * FROM [RestCustomers$]";
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

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHomepage newForm = new FormHomepage(this);
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAdminRestCheckElig newForm = new FormAdminRestCheckElig(this);
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) && comboBox3.SelectedItem != null)
            {
                try
                {
                    string from, messagebody, pass;
                    from = "homequarantineapp@gmail.com";
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(from);
                    message.Subject = "Order through Home Quarantined App";
                    string data = string.Empty;
                    string data1 = string.Empty;
                    string data2 = string.Empty;
                    string data3 = string.Empty;
                    string data4 = string.Empty;
                    string data5 = string.Empty;
                    string data6 = string.Empty;

                    to = "ngohotelhospital@gmail.com";

                    OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                    con1.Open();
                    String read1 = "SELECT * FROM [RestCustomers$]";
                    OleDbCommand readCmd1 = new OleDbCommand(read1, con1);
                    OleDbDataReader r1 = readCmd1.ExecuteReader();
                    
                    while (r1.Read())
                    {
                        if (comboBox3.SelectedItem.ToString() == r1[4].ToString() && textBox4.Text == r1[1].ToString() && r1[6].ToString() == "Yes")
                        {
                            flag = 1;
                            ConfUp = 1;
                            data1 = r1[0].ToString();
                            data2 = r1[1].ToString();
                            data3 = r1[2].ToString();
                            data4 = r1[3].ToString();
                            data5 = r1[4].ToString();
                            data6 = r1[5].ToString();
                            data = "Customer Name: " + data1 + "\nMobile Number: " + data2 + "\nAddress: " + data3 + "\nEmail ID: " + data4 + "\nRestaurant Name: " + data5 + "\nMeal: " + data6 + "";
                        }
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (flag == 1)
                {
                    try
                    {
                        string from, messagebody, pass;
                        from = "homequarantineapp@gmail.com";
                        MailMessage message = new MailMessage();
                        message.From = new MailAddress(from);
                        message.Subject = "Order through Home Quarantined App";
                        string data = string.Empty;
                        string data1 = string.Empty;
                        string data2 = string.Empty;
                        string data3 = string.Empty;
                        string data4 = string.Empty;
                        string data5 = string.Empty;
                        string data6 = string.Empty;
                        string data7 = string.Empty;

                        OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                        con2.Open();
                        String read2 = "SELECT * FROM [RestCustomers$]";
                        OleDbCommand readCmd2 = new OleDbCommand(read2, con2);
                        OleDbDataReader r2 = readCmd2.ExecuteReader();

                        while (r2.Read())
                        {
                            if (textBox4.Text == r2[1].ToString() && r2[3].ToString() != "No")
                            {
                                to = r2[3].ToString();
                                break;
                            }
                        }

                        messagebody = "Your order has been placed successfully.\nThe selected restaurant will contact you for further procedures.\n\nThank You!";
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (ConfUp == 1)
                    {
                        try
                        {
                            OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 12.0;");
                            con.Open();
                            String sql = "UPDATE [RestCustomers$] SET EmailId = @EmailId, Confirmation = @Confirmation WHERE MobileNumber = @MobileNumber";
                            OleDbCommand cmd = new OleDbCommand(sql, con);
                            cmd.Parameters.Add(new OleDbParameter("@EmailId", "Ordered"));
                            cmd.Parameters.Add(new OleDbParameter("@Confirmation", "No"));
                            cmd.Parameters.Add(new OleDbParameter("@MobileNumber", textBox4.Text));
                            String read = "SELECT * FROM [RestCustomers$]";
                            OleDbCommand readCmd = new OleDbCommand(read, con);
                            OleDbDataReader r = readCmd.ExecuteReader();
                            while (r.Read())
                            {
                                if (textBox4.Text == r[1].ToString() && r[6].ToString() == "Yes")
                                {
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    break;
                                }
                            }
                            MessageBox.Show("Order placed successfully!");
                            textBox4.Text = String.Empty;
                            comboBox3.SelectedItem = null;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kindly re-check the details!");
                }
            }
            else
            {
                MessageBox.Show("You need to enter the customer name and select a restaurant.");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
