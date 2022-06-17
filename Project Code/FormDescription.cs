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
    public partial class FormDescription : Form
    {
        Form parentForm;
        public FormDescription(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormHomepage newForm = new FormHomepage(this);
            newForm.Show();
            this.Close();
        }
    }
}
