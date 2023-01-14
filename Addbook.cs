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
    public partial class Addbook : Form
    {
        public Addbook()
        {
            InitializeComponent();
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to add these Books?", "Edit changes", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                    SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\users\\darshan\\documents\\visual studio 2010\\Projects\\LMS\\LMS\\Database1.mdf;Integrated Security=True;User Instance=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Books(BookID,BookName,BookAuthor,BookPrice) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";        
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            else
            {
                MessageBox.Show("Error");
            }
        }
            
        private void Addbook_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            delBooks db = new delBooks();
            db.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Editbook eb = new Editbook();
            eb.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewBooks vb = new ViewBooks();
            vb.Show();
            this.Hide();
        }
    }
}
