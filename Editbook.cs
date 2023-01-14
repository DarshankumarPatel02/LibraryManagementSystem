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
    public partial class Editbook : Form
    {
        public Editbook()
        {
            InitializeComponent();
        }

        private void Editbook_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet16.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.database1DataSet16.Books);
            // TODO: This line of code loads data into the 'database1DataSet15.Books' table. You can move, or remove it, as needed.
         //   this.booksTableAdapter1.Fill(this.database1DataSet15.Books);
            // TODO: This line of code loads data into the 'database1DataSet13.Books' table. You can move, or remove it, as needed.
        //
            
            
            
            
            
            
            
            
            
            
            
            
            //this.booksTableAdapter.Fill(this.database1DataSet13.Books);
            // TODO: This line of code loads data into the 'database1DataSet9.Books' table. You can move, or remove it, as needed.
         //   this.booksTableAdapter.Fill(this.database1DataSet9.Books);
            // TODO: This line of code loads data into the 'database1DataSet7.Books' table. You can move, or remove it, as needed.
          //  this.booksTableAdapter.Fill(this.database1DataSet7.Books);
            // TODO: This line of code loads data into the 'database1DataSet6.Books' table. You can move, or remove it, as needed.
           // this.booksTableAdapter.Fill(this.database1DataSet6.Books);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == string.Empty) && (textBox3.Text == string.Empty) && (textBox4.Text == string.Empty))
            {
                MessageBox.Show("Enter Details to perform Edit operation!!!!!!");
            }
            else if (radioButton1.Checked == true)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to update these BookDetails?", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\users\\darshan\\documents\\visual studio 2010\\Projects\\LMS\\LMS\\Database1.mdf;Integrated Security=True;User Instance=True");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Books where BookID='" + textBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid ID!!!!!!!");
                    }
                    else
                    {
                        da = new SqlDataAdapter("update Books set BookName='" + textBox2.Text + "',BookAuthor='" + textBox3.Text + "',BookPrice='" + textBox4.Text + "',IssueBook='" + true + "',IssueDate='" + dateTimePicker1.Value.Date + "',ReturnDate='" + dateTimePicker2.Value.Date + "',ReturnBook='" + comboBox1.SelectedItem + "' where BookID='" + textBox1.Text + "'", con);
                        da.Fill(dt);
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                        radioButton1.Checked = radioButton2.Checked = false;
                    }
                }
            }
            else if (radioButton2.Checked == true)
            {

                DialogResult dr = MessageBox.Show("Are you sure to update these BookDetails?", "Edit changes", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\users\\darshan\\documents\\visual studio 2010\\Projects\\LMS\\LMS\\Database1.mdf;Integrated Security=True;User Instance=True");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Books where BookID='" + textBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid ID!!!!!!!");
                    }
                    else
                    {
                        da = new SqlDataAdapter("update Books set BookName='" + textBox2.Text + "',BookAuthor='" + textBox3.Text + "',BookPrice='" + textBox4.Text + "',IssueBook='" + false + "',ReturnBook='" + comboBox1.SelectedItem + "' where BookID='" + textBox1.Text + "'", con);
                        da.Fill(dt);
                        this.Hide();
                    }
                }
            }
        } 
            
                
                             

        

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                //dateTimePicker1.Text = row.Cells[6].Value.ToString();
                //dateTimePicker2.Text = row.Cells[7].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            radioButton1.Checked = radioButton1.Checked = false;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.CustomFormat = " "; 
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            //checkBox3.Enabled = true;
           // checkBox4.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
           // checkBox3.Enabled = false;
           // checkBox.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Addbook ab = new Addbook();
            ab.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewBooks vb = new ViewBooks();
            vb.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            delBooks db = new delBooks();
            db.Show();
            this.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }
    }
}
