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
    public partial class FormDonatePlasma : Form
    {
        Form parentForm;
        public FormDonatePlasma(Form form)
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
            if (Global.currUName != null && Global.currUNumber != null)
            {
                FormDonorInfoCheck newForm = new FormDonorInfoCheck(this);
                newForm.Show();
            }
            else
            {
                FormConfirmPlasma newForm = new FormConfirmPlasma(this);
                newForm.Show();
            }
        }

        private void FormDonatePlasma_Load(object sender, EventArgs e)
        {
            if (Global.isULoggedIn == 1 && Global.uploaded == 1 && Global.donorNumb == Global.currUNumber)
            {
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Global.uploaded == 1)
            {
                FormDownloadECard newForm = new FormDownloadECard(this);
                newForm.Show();
            }
            else
            {
                MessageBox.Show("E-Health Card not generated!");
            }
        }
    }
}
