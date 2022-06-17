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
    public partial class FormImageHealthCard : Form
    {
        public static FormImageHealthCard instance;
        public Label lab1;
        public Label lab2;
        public Label lab9;
        public Label lab14;
        public Label lab15;
        public Label lab16;
        public Label lab17;
        public Label lab18;
        public Label lab19;
        public Label lab20;
        public Label lab21;
        public Label lab22;
        public Label lab23;
        public Label lab24;
        Form parentForm;
       
        public FormImageHealthCard(Form form)
        {
            InitializeComponent();
            instance = this;
            lab9 = label9;
            lab14 = label14;
            lab15 = label15;
            lab16 = label16;
            lab17 = label17;
            lab18 = label18;
            lab19 = label19;
            lab20 = label20;
            lab21 = label21;
            lab22 = label22;
            lab23 = label23;
            lab24 = label24;
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
