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
    public partial class FormActiveCases : Form
    {
        private Timer tmr;
        private int scrll { get; set; }
        Form parentForm;
        public FormActiveCases(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.bing.com/search?q=goa+covid+cases+tracker&qs=n&form=QBRE&sp=-1&pq=goa+covid+cases+tracker&sc=0-23&sk=&cvid=87D9115316F34612A41CDEFD259F96BD");
            webBrowser2.Navigate("https://www.bing.com/search?q=goa+covid+cases+tracker&qs=n&form=QBRE&sp=-1&pq=goa+covid+cases+tracker&sc=0-23&sk=&cvid=87D9115316F34612A41CDEFD259F96BD");
            webBrowser3.Navigate("https://www.bing.com/search?q=goa+covid+cases+tracker&qs=n&form=QBRE&sp=-1&pq=goa+covid+cases+tracker&sc=0-23&sk=&cvid=87D9115316F34612A41CDEFD259F96BD");

            tmr = new Timer();
            tmr.Tick += new EventHandler(this.TimerTick);
            tmr.Interval = 100;
            tmr.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            ScrollLabel();
        }

        private void ScrollLabel()
        {
            string strString = "         STOPPING   THE   SPREAD   STARTS   WITH   YOU         STOPPING   THE   SPREAD   STARTS   WITH   YOU         STOPPING   THE   SPREAD   STARTS   WITH   YOU";
            scrll = scrll + 1;
            int i = strString.Length - scrll;
            if (i < 84)
            {
                scrll = 0;
            }
            string str = strString.Substring(scrll, 84);
            label3.Text = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 
