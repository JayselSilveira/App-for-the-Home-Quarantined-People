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
    public partial class FormPrecautionaryTest : Form
    {
        private Timer tmr;
        private int scrll { get; set; }

        Form parentForm;
        public FormPrecautionaryTest(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked || checkedListBox1.GetItemCheckState(1) == CheckState.Checked || checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
            {
                MessageBox.Show("Based on your symptoms, you may need urgent medical care. Please go to the nearest hospital or call your health care provider or hotline for advice.");
                this.Close();
            }
            else if (checkedListBox1.GetItemCheckState(3) == CheckState.Checked)
            {
                MessageBox.Show("Please stay home and self isolate. If you need to leave your house or have someone near you, wear a medical mask to avoid infecting others.");
                this.Close();
            }
            else if (checkedListBox1.GetItemCheckState(4) == CheckState.Checked)
            {
                MessageBox.Show("Isolate yourself for few weeks, wear a mask if you really need to go out.");
                this.Close();
            }
            else
            {
                MessageBox.Show("You're safe for now... Avoid going out or wear a mask while going out and get vaccinated when you are eligible.");
                this.Close();
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            ScrollLabel();
        }

        private void ScrollLabel()
        {
            String strStg = "        These results are not guaranteed     It's always advised to seek medical help        These results are not guaranteed     It's always advised to seek medical help";
            scrll = scrll + 1;
            int o = strStg.Length-scrll;
            if(o<77)
            {
                scrll = 0;
            }
            string str = strStg.Substring(scrll, 77);
            label1.Text = str;
        }

        private void FormPrecautionaryTest_Load(object sender, EventArgs e)
        {
            tmr = new Timer();
            tmr.Tick += new EventHandler(this.TimerTick);
            tmr.Interval = 100;
            tmr.Start();
        }
    }
}
