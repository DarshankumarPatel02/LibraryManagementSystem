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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == string.Empty) && (textBox2.Text == string.Empty))
            {
                MessageBox.Show("Enter Details!!!!!!");
            }
            else if ((textBox1.Text == string.Empty))
            {
                MessageBox.Show("Enter Username!!!!!");
            }
            else if ((textBox2.Text == string.Empty))
            {
                MessageBox.Show("Enter Password!!!");
            }
            else if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                label3.Text = "Welcome Admin";
                linkLabel1.Text = "Add Librarian";
                linkLabel2.Text = "Edit Librarian";
                linkLabel3.Text = "View Librarian";
                linkLabel4.Text = "Delete Librarian ";
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\users\\darshan\\documents\\visual studio 2010\\Projects\\LMS\\LMS\\Database1.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Librarian where ID='" + textBox1.Text + "' and Password='"+textBox2.Text+"'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Login");
                }
                else 
                {
                    label3.Text = "Welcome Librarian";
                    linkLabel1.Text = "Add Books";
                    linkLabel2.Text = "Edit/Issue Books";
                    linkLabel3.Text = "View Books";
                    linkLabel4.Text = "Delete Books";
                }
            }
       
        }
        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                DialogResult dialogResult = MessageBox.Show("Add Librarian", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    addlib al = new addlib();
                    al.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Something Went Wrong!!!");
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Add Books", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    Addbook ab = new Addbook();
                    ab.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Something Went Wrong!!!");
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                DialogResult dialogResult = MessageBox.Show("Edit Librarian", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    editlib el = new editlib();
                    el.Show();

                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Something Went Wrong During Editing Details");
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Edit Books", "Edit changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    Editbook eb = new Editbook();
                    eb.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Something Went Wrong!!!");
                }
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                DialogResult dialogResult = MessageBox.Show("View Librarian", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    viewlib vl = new viewlib();
                    vl.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Something Went Wrong During Viewing");
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("View Books", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    ViewBooks vb = new ViewBooks();
                    vb.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Something Went Wrong During Viewing");
                }
            }
        }


        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                DialogResult dialogResult = MessageBox.Show("Delete Librarian", " ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dellib dl = new dellib();
                    dl.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Something Went Wrong During Deleting");
                }
            }
            else 
            {
                DialogResult dialogResult = MessageBox.Show("Delete Books", " ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    delBooks db = new delBooks();
                    db.Show();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else
                {
                    MessageBox.Show("Something Went Wrong During Deleting");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You want to Logout?", " ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            else
            {
                MessageBox.Show("Something Went Wrong!!!");
            }
        }

    }
}
