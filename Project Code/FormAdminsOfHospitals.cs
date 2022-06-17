using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;  
using System.IO;
using System.Reflection;
using System.Net.Mime;

namespace Mini_Project_1
{
    public partial class FormAdminsOfHospitals : Form
    {
        Form parentForm;
        public FormAdminsOfHospitals(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                FormMailImage newForm = new FormMailImage(this);
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Donor ID and name should be entered.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
