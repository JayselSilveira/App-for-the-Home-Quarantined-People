using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mini_Project_1
{
    public partial class FormUploadECards : Form
    {
        public static Image Logo = null;
        Form parentForm;
        public FormUploadECards(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
            pictureBox1.AllowDrop = true;

            this.AllowDrop = true;
            pictureBox1.DragOver += new DragEventHandler(pictureBox1_DragOver);
            pictureBox1.DragDrop += new DragEventHandler(pictureBox1_DragDrop);
            this.DragOver += new DragEventHandler(pictureBox1_DragOver);
            this.DragDrop += new DragEventHandler(pictureBox1_DragDrop);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Global.uploaded = 1;
                Global.isClicked = 1;
                Global.donorNumb = textBox1.Text;
                Logo = pictureBox1.Image;
                if (Global.isClicked == 1 && Global.isDropped == 1)
                {
                    MessageBox.Show("E-Health Card successfully uploaded!");
                }
                else
                {
                    MessageBox.Show("You need to select a file!");
                }
            }
            else
            {
                MessageBox.Show("You need to enter the donor's mobile number!");
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fileNames != null && fileNames.Length != 0)
            {
                StringBuilder sb = new StringBuilder("Accepted the following files: ");
                sb.AppendLine();
                Array.ForEach<string>(fileNames, delegate(string fileName) { sb.Append(fileName); sb.AppendLine(); });
                MessageBox.Show(sb.ToString());
            }
            foreach (string pic in ((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                Image img = Image.FromFile(pic);
                pictureBox1.Image = img;
                Global.isDropped = 1;
            } 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
