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
    public partial class delBooks : Form
    {
        public delBooks()
        {
            InitializeComponent();
        }

        private void delBooks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet18.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.database1DataSet18.Books);
            // TODO: This line of code loads data into the 'database1DataSet14.Books' table. You can move, or remove it, as needed.
       //     this.booksTableAdapter.Fill(this.database1DataSet14.Books);
            // TODO: This line of code loads data into the 'database1DataSet11.Books' table. You can move, or remove it, as needed.
       //     this.booksTableAdapter.Fill(this.database1DataSet11.Books);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "false")
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\users\\darshan\\documents\\visual studio 2010\\Projects\\LMS\\LMS\\Database1.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                DialogResult dialogResult = MessageBox.Show("Delete Data", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlDataAdapter da = new SqlDataAdapter("delete from Books where BookID='" + textBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Data Deleted!!");
                        textBox1.Clear();
                    }
                }
                else if (dialogResult == DialogResult.No)
                    {
                    }
            }
            else
            {
                MessageBox.Show("ISSUED BOOK cannnot be deleted!!!!!!!");
            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[4].Value.ToString();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
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
            ViewBooks vb = new ViewBooks();
            vb.Show();
            this.Hide();
        }
    }
}
