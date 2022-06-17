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
    public partial class FormCheckVitalSigns : Form
    {
        Form parentForm;
        public FormCheckVitalSigns(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String sql = "UPDATE [VitalSigns$] SET BodyTemperature = @BodyTemperature, OxygenLevel = @OxygenLevel, PulseRate = @PulseRate WHERE TimeOfDay = @TimeOfDay";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.Add(new OleDbParameter("@BodyTemperature", textBox1.Text));
                    cmd.Parameters.Add(new OleDbParameter("@OxygenLevel", textBox2.Text));
                    cmd.Parameters.Add(new OleDbParameter("@PulseRate", textBox3.Text));
                    cmd.Parameters.Add(new OleDbParameter("@TimeOfDay", "Morning"));

                   cmd.ExecuteNonQuery();
                   con.Close();

                   if (!(int.Parse(textBox1.Text) > 99) && !(int.Parse(textBox2.Text) <= 94) && !((int.Parse(textBox3.Text) <= 95) && (int.Parse(textBox3.Text) >= 100)))
                   {
                       MessageBox.Show("Your condition is good. Take care!");
                       this.Close();
                   }
                   else
                   {
                       MessageBox.Show("Your condition is deteriorating. Get admitted at the earliest!");
                       this.Close();
                   }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("You need to enter all the morning readings to check.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text))
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String sql = "UPDATE [VitalSigns$] SET BodyTemperature = @BodyTemperature, OxygenLevel = @OxygenLevel, PulseRate = @PulseRate WHERE TimeOfDay = @TimeOfDay";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.Add(new OleDbParameter("@BodyTemperature", textBox4.Text));
                    cmd.Parameters.Add(new OleDbParameter("@OxygenLevel", textBox5.Text));
                    cmd.Parameters.Add(new OleDbParameter("@PulseRate", textBox6.Text));
                    cmd.Parameters.Add(new OleDbParameter("@TimeOfDay", "Afternoon"));

                    cmd.ExecuteNonQuery();
                    con.Close();

                    if (!(int.Parse(textBox4.Text) > 99) && !(int.Parse(textBox5.Text) <= 94) && !((int.Parse(textBox6.Text) <= 95) && (int.Parse(textBox6.Text) >= 100)))
                    {
                        MessageBox.Show("Your condition is good. Take care!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Your condition is deteriorating. Get admitted at the earliest!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("You need to enter all the afternoon readings to check.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrEmpty(textBox9.Text))
            {
                try
                {
                    OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                    con.Open();
                    String sql = "UPDATE [VitalSigns$] SET BodyTemperature = @BodyTemperature, OxygenLevel = @OxygenLevel, PulseRate = @PulseRate WHERE TimeOfDay = @TimeOfDay";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.Parameters.Add(new OleDbParameter("@BodyTemperature", textBox7.Text));
                    cmd.Parameters.Add(new OleDbParameter("@OxygenLevel", textBox8.Text));
                    cmd.Parameters.Add(new OleDbParameter("@PulseRate", textBox9.Text));
                    cmd.Parameters.Add(new OleDbParameter("@TimeOfDay", "Night"));

                    cmd.ExecuteNonQuery();
                    con.Close();

                    if (!(int.Parse(textBox7.Text) > 99) && !(int.Parse(textBox8.Text) <= 94) && !((int.Parse(textBox9.Text) <= 95) && (int.Parse(textBox9.Text) >= 100)))
                    {
                        MessageBox.Show("Your condition is good. Take care!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Your condition is deteriorating. Get admitted at the earliest!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("You need to enter all the night readings to check.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            FormDayReadings newForm = new FormDayReadings(this);
            newForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                con1.Open();
                String sql1 = "UPDATE [VitalSigns$] SET BodyTemperature = @BodyTemperature, OxygenLevel = @OxygenLevel, PulseRate = @PulseRate WHERE TimeOfDay = @TimeOfDay";
                OleDbCommand cmd1 = new OleDbCommand(sql1, con1);
                cmd1.Parameters.Add(new OleDbParameter("@BodyTemperature", '0'));
                cmd1.Parameters.Add(new OleDbParameter("@OxygenLevel", '0'));
                cmd1.Parameters.Add(new OleDbParameter("@PulseRate", '0'));
                cmd1.Parameters.Add(new OleDbParameter("@TimeOfDay", "Morning"));
                cmd1.ExecuteNonQuery();
                con1.Close();
                OleDbConnection con2 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                con2.Open();
                String sql2 = "UPDATE [VitalSigns$] SET BodyTemperature = @BodyTemperature, OxygenLevel = @OxygenLevel, PulseRate = @PulseRate WHERE TimeOfDay = @TimeOfDay";
                OleDbCommand cmd2 = new OleDbCommand(sql2, con2);
                cmd2.Parameters.Add(new OleDbParameter("@BodyTemperature", '0'));
                cmd2.Parameters.Add(new OleDbParameter("@OxygenLevel", '0'));
                cmd2.Parameters.Add(new OleDbParameter("@PulseRate", '0'));
                cmd2.Parameters.Add(new OleDbParameter("@TimeOfDay", "Afternoon"));
                cmd2.ExecuteNonQuery();
                con2.Close();
                OleDbConnection con3 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                con3.Open();
                String sql3 = "UPDATE [VitalSigns$] SET BodyTemperature = @BodyTemperature, OxygenLevel = @OxygenLevel, PulseRate = @PulseRate WHERE TimeOfDay = @TimeOfDay";
                OleDbCommand cmd3 = new OleDbCommand(sql3, con3);
                cmd3.Parameters.Add(new OleDbParameter("@BodyTemperature", '0'));
                cmd3.Parameters.Add(new OleDbParameter("@OxygenLevel", '0'));
                cmd3.Parameters.Add(new OleDbParameter("@PulseRate", '0'));
                cmd3.Parameters.Add(new OleDbParameter("@TimeOfDay", "Night"));
                cmd3.ExecuteNonQuery();
                con3.Close();

                MessageBox.Show("Enter your readings for the day.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
