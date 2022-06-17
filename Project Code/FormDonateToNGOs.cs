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
    public partial class FormDonateToNGOs : Form
    {
        Form parentForm;
        public FormDonateToNGOs(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormN1NGO newForm = new FormN1NGO(this);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormN2NGO newForm = new FormN2NGO(this);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormN3NGO newForm = new FormN3NGO(this);
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormN4NGO newForm = new FormN4NGO(this);
            newForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormN5NGO newForm = new FormN5NGO(this);
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormS1NGO newForm = new FormS1NGO(this);
            newForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormS2NGO newForm = new FormS2NGO(this);
            newForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormS3NGO newForm = new FormS3NGO(this);
            newForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormS4NGO newForm = new FormS4NGO(this);
            newForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormS5NGO newForm = new FormS5NGO(this);
            newForm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Global.currUName != null && Global.currUNumber != null)
            {
                FormDonateMedicines newForm = new FormDonateMedicines(this);
                newForm.Show();
            }
            else
            {
                FormConfirmMedicines newForm = new FormConfirmMedicines(this);
                newForm.Show();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Global.currUName != null && Global.currUNumber != null)
            {
                FormDonateOxyCylinders newForm = new FormDonateOxyCylinders(this);
                newForm.Show();
            }
            else
            {
                FormConfirmOxyCylinders newForm = new FormConfirmOxyCylinders(this);
                newForm.Show();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (Global.currUName != null && Global.currUNumber != null)
            {
                FormDonateOxiMaskFS newForm = new FormDonateOxiMaskFS(this);
                newForm.Show();
            }
            else
            {
                FormConfirmOxiMaskFS newForm = new FormConfirmOxiMaskFS(this);
                newForm.Show();
            }
        }

    }
}
