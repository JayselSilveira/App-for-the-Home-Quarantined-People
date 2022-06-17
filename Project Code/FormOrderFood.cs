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
    public partial class FormOrderFood : Form
    {
        Form parentForm;
        public FormOrderFood(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Global.currUName != null && Global.currUNumber != null)
            {
                if (comboBox3.SelectedItem != null && comboBox1.SelectedItem != null)
                {
                    Global.restName = comboBox3.SelectedItem.ToString();
                    Global.meal = comboBox1.SelectedItem.ToString();
                    FormMailCertificate newForm = new FormMailCertificate(this);
                    newForm.Show();
                }
                else
                {
                    MessageBox.Show("Select a restaurant name and meal to proceed!");
                }
            }
            else
            {
                FormUserLogin newForm = new FormUserLogin(this);
                newForm.Show();
            }
        }
    }
}
