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
    public partial class FormAdminManagement : Form
    {
        Form parentForm;
        public FormAdminManagement(Form form)
        {
            InitializeComponent();
            this.parentForm = form;
        }

        private void FormAdminManagement_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\\HomeQuarantinedApp.xlsx'; Extended Properties = Excel 8.0;");
                con.Open();
                String qry = "SELECT * FROM [Feedback$]";
                OleDbDataAdapter ad = new OleDbDataAdapter(qry, con);
                DataSet ds = new DataSet();
                ad.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            FormHomepage newForm = new FormHomepage(this);
            newForm.Show();
        }
    }
}
