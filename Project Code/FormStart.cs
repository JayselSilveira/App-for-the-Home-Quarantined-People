﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mini_Project_1
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormDescription newForm = new FormDescription(this);
            newForm.Show();
        }
    }
}
