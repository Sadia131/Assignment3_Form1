using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Assignment_3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lab"].ConnectionString);
            con.Open();
            string q = "Delete from Adds where Name='" + textBox1.Text + "' ";
            SqlCommand command = new SqlCommand(q, con);
            command.ExecuteNonQuery();
            con.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Lab"].ConnectionString);
            c.Open();
            string query = "Select * from Adds where Name='" + textBox2.Text + "'";
            SqlCommand command = new SqlCommand(query, c);
            SqlDataReader reader = command.ExecuteReader();
            List<Class1> list = new List<Class1>();
            while (reader.Read())
            {
                Class1 cw = new Class1();
                cw.Name = reader["Name"].ToString();
                cw.Date = reader["Date"].ToString();
                cw.Pictures = reader["Pictures"].ToString();
                cw.Description = reader["Description"].ToString();

                list.Add(cw);
            }
            c.Close();
            dataGridView1.DataSource = list;
            reader.Close();

        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
