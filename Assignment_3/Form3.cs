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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Lab"].ConnectionString);
            cn.Open();
            string q = "Insert Into Adds(Name,Pictures,Description)" + "Values('" + textBox1.Text + "','"  + textBox2.Text + "','" + textBox3.Text + "')";
            SqlCommand cm = new SqlCommand(q, cn);

            cm.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Successfully Added!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }
    }
}
