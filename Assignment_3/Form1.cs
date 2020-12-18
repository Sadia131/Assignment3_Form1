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
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-DU8KD96\\SQLEXPRESS;Initial Catalog=Diaries;Integrated Security=True;Pooling=False");
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
            String qry = "";
        SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM [dbo].[Login] Where [dbo].[Login].[UserName] = '" + textBox1.Text + "' and  [dbo].[Login].Password = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Valid User" + uname);

            }
            else
                MessageBox.Show("Invalid User" + uname);




        }


    }
}
