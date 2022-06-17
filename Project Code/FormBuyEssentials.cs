using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.OleDb;

namespace Mini_Project_1
{
    public partial class FormBuyEssentials : Form
    {
        Form parentForm;
        public FormBuyEssentials(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.pharmeasy.in");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.apollopharmacy.in");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.wellnessforever.com");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.medlife.com");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.practo.com");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.1mg.com");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.flipkart.com/mylab-coviself-covid-19-rapid-antigen-self-test-kit/p/itm4d34ea09cad97");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://assets.publishing.service.gov.uk/government/uploads/system/uploads/attachment_data/file/957271/COVID-19-self-test-instructions.pdf");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
