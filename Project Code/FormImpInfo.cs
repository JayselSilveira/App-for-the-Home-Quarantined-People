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
    public partial class FormImpInfo : Form
    {
        Form parentForm;
        public FormImpInfo(Form form)
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
            FormInfoCovid newForm = new FormInfoCovid(this);
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormInfoVaccinationCentres newForm = new FormInfoVaccinationCentres(this);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormInfoQuarantineCentres newForm = new FormInfoQuarantineCentres(this);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormInfoOxygenFactories newForm = new FormInfoOxygenFactories(this);
            newForm.Show();
        }
    }
}
