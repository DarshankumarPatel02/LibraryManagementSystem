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
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet17.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.database1DataSet17.Books);
            // TODO: This line of code loads data into the 'database1DataSet12.Books' table. You can move, or remove it, as needed.
           // this.booksTableAdapter.Fill(this.database1DataSet12.Books);
            // TODO: This line of code loads data into the 'database1DataSet8.Books' table. You can move, or remove it, as needed.
           // this.booksTableAdapter.Fill(this.database1DataSet8.Books);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\users\\darshan\\documents\\visual studio 2010\\Projects\\LMS\\LMS\\Database1.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Books", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.EndEdit();
            dataGridView1.Parent.Refresh();
            dataGridView1.Refresh();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Addbook ab = new Addbook();
            ab.Show();
            this.Hide();
        
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Editbook eb = new Editbook();
            eb.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            delBooks db = new delBooks();
            db.Show();
            this.Hide();
        }

    }
}
