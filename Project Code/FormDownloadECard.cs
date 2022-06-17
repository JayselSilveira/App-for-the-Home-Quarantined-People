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
    public partial class FormDownloadECard : Form
    {
        Form parentForm;
        public FormDownloadECard(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void FormDownloadECard_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FormUploadECards.Logo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG(*.JPG)|*.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
                MessageBox.Show("E-Health Card successfully downloaded!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
