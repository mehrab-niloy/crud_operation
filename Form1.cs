using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crud_operation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-D9TE5JB3\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into crud1 values (@id,@name,@age)", con);
            cmd.Parameters.AddWithValue("@id",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name",textBox2.Text);
            cmd.Parameters.AddWithValue("age", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("successfully saved");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-D9TE5JB3\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update crud1 set name=@name,age=@age where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("age", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("successfully updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-D9TE5JB3\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from crud1 where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("successfully deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-D9TE5JB3\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from crud1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-D9TE5JB3\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into radiocom values (@gender,@city)", con);
            string s;
            if (radioButton1.Checked == true)
                s = "male";
            else
                s = "female";
            cmd.Parameters.AddWithValue("@gender", s);
            cmd.Parameters.AddWithValue("@city",comboBox1.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("inserted");
        }
    }
}
