using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LMS
{
    public partial class viewlib : Form
    {
        public viewlib()
        {
            InitializeComponent();
        }

        private void viewlib_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Librarian' table. You can move, or remove it, as needed.
            this.librarianTableAdapter.Fill(this.database1DataSet1.Librarian);
            label1.Text = "ALL LIBRARIAN DETAILS";
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\users\\darshan\\documents\\visual studio 2010\\Projects\\LMS\\LMS\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Librarian", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EndEdit();
            dataGridView1.Parent.Refresh();
            dataGridView1.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void librarianBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addlib al = new addlib();
            al.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editlib el = new editlib();
            el.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dellib dl = new dellib();
            dl.Show();
            this.Hide();
        }
    }
}
