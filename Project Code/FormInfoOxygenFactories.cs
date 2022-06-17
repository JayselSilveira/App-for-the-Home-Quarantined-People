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
    public partial class FormInfoOxygenFactories : Form
    {
        Form parentForm;
        public FormInfoOxygenFactories(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
    }
}
