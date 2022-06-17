using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mini_Project_1
{
    public partial class FormDonorInfoCheck : Form
    {
        Form parentForm;
        public FormDonorInfoCheck(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string GB1 = "";
            if (radioButton1.Checked)
            {
                GB1 = radioButton1.Text;
            }

            if (radioButton2.Checked)
            {
                GB1 = radioButton2.Text;
            }

            string GB2 = "";
            if (radioButton4.Checked)
            {
                GB2 = radioButton4.Text;
            }

            if (radioButton3.Checked)
            {
                GB2 = radioButton3.Text;
            }

            string GB3 = "";
            if (radioButton6.Checked)
            {
                GB3 = radioButton6.Text;
            }

            if (radioButton5.Checked)
            {
                GB3 = radioButton5.Text;
            }

            string GB4 = "";
            if (radioButton8.Checked)
            {
                GB4 = radioButton8.Text;
            }

            if (radioButton7.Checked)
            {
                GB4 = radioButton7.Text;
            }

            string GB5 = "";
            if (radioButton10.Checked)
            {
                GB5 = radioButton10.Text;
            }

            if (radioButton9.Checked)
            {
                GB5 = radioButton9.Text;
            }

            string GB6 = "";
            if (radioButton12.Checked)
            {
                GB6 = radioButton12.Text;
            }

            if (radioButton11.Checked)
            {
                GB6 = radioButton11.Text;
            }

            string GB7 = "";
            if (radioButton14.Checked)
            {
                GB7 = radioButton14.Text;
            }

            if (radioButton13.Checked)
            {
                GB7 = radioButton13.Text;
            }

            string GB8 = "";
            if (radioButton16.Checked)
            {
                GB8 = radioButton16.Text;
            }

            if (radioButton15.Checked)
            {
                GB8 = radioButton15.Text;
            }

            if (GB1 != "" && GB2 != "" && GB4 != "" && GB5 != "" && GB6 != "" && GB7 != "" && GB8 != "" && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                if (GB8 == "F")
                {
                    if (GB3 != "")
                    {
                        if (GB1 == "YES" && GB2 == "YES" && (int.Parse(textBox1.Text) >= 18 && int.Parse(textBox1.Text) <= 60) && int.Parse(textBox2.Text) >= 50 && GB3 == "NO" && GB4 == "NO" && int.Parse(textBox3.Text) <= 140 && (int.Parse(textBox4.Text) >= 60 && int.Parse(textBox4.Text) <= 90) && GB5 == "NO" && GB6 == "NO" && GB7 == "NO")
                        {
                            this.Close();
                            FormDonorInfoFill newForm = new FormDonorInfoFill(this);
                            newForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("You cannot donate plasma.");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fields should not be left blank!");
                    }
                }
                else
                {
                    if (GB1 == "YES" && GB2 == "YES" && (int.Parse(textBox1.Text) >= 18 && int.Parse(textBox1.Text) <= 60) && int.Parse(textBox2.Text) >= 50 && GB4 == "NO" && int.Parse(textBox3.Text) <= 140 && (int.Parse(textBox4.Text) >= 60 && int.Parse(textBox4.Text) <= 90) && GB5 == "NO" && GB6 == "NO" && GB7 == "NO")
                    {
                        this.Close();
                        FormDonorInfoFill newForm = new FormDonorInfoFill(this);
                        newForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("You cannot donate plasma.");
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Fields should not be left blank!");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
