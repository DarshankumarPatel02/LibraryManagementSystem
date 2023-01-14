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
    public partial class editlib : Form
    {
        public editlib()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void editlib_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet10.Librarian' table. You can move, or remove it, as needed.
            this.librarianTableAdapter.Fill(this.database1DataSet10.Librarian);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == string.Empty) && (textBox2.Text == string.Empty) && (textBox3.Text == string.Empty) && (textBox4.Text == string.Empty) && (textBox5.Text == string.Empty) && (textBox5.Text == string.Empty))
            {
                MessageBox.Show("Enter Details to perform Edit operation!!!!!!");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to update these Librarian?", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\users\\darshan\\documents\\visual studio 2010\\Projects\\LMS\\LMS\\Database1.mdf;Integrated Security=True;User Instance=True");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Librarian where ID='" + textBox6.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid ID!!!!!!!");
                    }
                    else
                    {
                        da = new SqlDataAdapter("update Librarian set Name='" + textBox1.Text + "',MobileNumber='" + textBox2.Text + "',Address='" + textBox3.Text + "',WorkingHour='" + textBox4.Text + "',Password='" + textBox5.Text + "' where ID='" + textBox6.Text + "'", con);
                        da.Fill(dt);
                      //  this.Hide();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                   
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox6.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addlib al = new addlib();
            al.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            viewlib vl = new viewlib();
            vl.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dellib dl = new dellib();
            dl.Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
    }
}
