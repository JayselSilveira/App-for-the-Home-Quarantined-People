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
    public partial class FormHomepage : Form
    {
        Form parentForm;
        public FormHomepage(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormActiveCases newForm = new FormActiveCases(this);
            newForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormDonatePlasma newForm = new FormDonatePlasma(this);
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormBuyEssentials newForm = new FormBuyEssentials(this);
            newForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormDonateToNGOs newForm = new FormDonateToNGOs(this);
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormUserRegister newForm = new FormUserRegister(this);
            newForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Global.isULoggedIn == 0)
            {
                FormUserLogin newForm = new FormUserLogin(this);
                newForm.Show();
                this.Close();
            }
            if (Global.isULoggedIn == 1)
            {
                Global.isULoggedIn = 0;
                Global.currUName = null;
                Global.currUNumber = null;
                MessageBox.Show("Logged out successfully!");
                button12.Text = "LOGIN";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormCheckVitalSigns newForm = new FormCheckVitalSigns(this);
            newForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Global.isALoggedIn == 0)
            {
                FormAdminLogin newForm = new FormAdminLogin(this);
                newForm.Show();
            }
            if (Global.isALoggedIn == 1)
            {
                if (Global.isAdNGO == 1)
                {
                    FormAdminNGO newForm = new FormAdminNGO(this);
                    newForm.Show();
                } 
                if (Global.isAdRestaurants == 1)
                {
                    FormAdminRestaurants newForm = new FormAdminRestaurants(this);
                    newForm.Show();
                }
                if (Global.isAdHospitals == 1)
                {
                    FormAdminHospitals newForm = new FormAdminHospitals(this);
                    newForm.Show();
                }
                if (Global.isAdManagement == 1)
                {
                    FormAdminManagement newForm = new FormAdminManagement(this);
                    newForm.Show();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FormFeedback newForm = new FormFeedback(this);
            newForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormImpInfo newForm = new FormImpInfo(this);
            newForm.Show();
        }

        private void FormHomepage_Load(object sender, EventArgs e)
        {
            if (Global.isULoggedIn == 0)
            {
                button12.Text = "LOGIN";
            }
            if (Global.isULoggedIn == 1)
            {
                button12.Text = "LOGOUT";
            }
            if (Global.isALoggedIn == 0)
            {
                button14.Visible = false;
            }
            if (Global.isALoggedIn == 1)
            {
                button14.Visible = true;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Global.isALoggedIn = 0;
            MessageBox.Show("Logged out successfully!");
            button14.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormPrecautionaryTest newForm = new FormPrecautionaryTest(this);
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormOrderFood newForm = new FormOrderFood(this);
            newForm.Show();
        }
    }
}
