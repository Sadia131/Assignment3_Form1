using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_3
{
   
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JKE11J9\\SQLEXPRESS;Initial Catalog=Lab;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Username");
            }

            if (this.textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Password");
            }

            if (this.textBox2.Text.Length == 0 || this.textBox2.Text.Length==0)
            {
                MessageBox.Show("All fields are necessary");
            }


            String uname = textBox1.Text.ToString();
            String pass = textBox2.Text.ToString();
            con.Open();
            string query = "Select * from Users where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {

                MessageBox.Show("Wrong Username or password");
            }
            else
                MessageBox.Show(" Successfully Entered" + uname);

            Form2 f = new Form2();
            f.Show();
            this.Hide();


            reader.Close();
            con.Close();


        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



    }
}
