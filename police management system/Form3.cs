using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql; 
using System.Data.SqlClient;

namespace police_management_system
{
    public partial class Form3 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=USMAN\SQLEXPRESS;Initial Catalog=POLICE MANAGEMENT;Integrated Security=True");
        SqlDataAdapter adpt;
        DataTable dt;


        public Form3()
        {
            InitializeComponent();
            display();
        }

        public void addinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText= "Insert into witnesss(witness_id,witness_name,witness_cnic) Values('"+Convert.ToInt32(textBox1.Text)+"','"+textBox2.Text+"','" +Convert.ToInt32(textBox3.Text)+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void deleteinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from witnesss where witness_id='" + Convert.ToInt32(textBox1.Text) + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void updateinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update  witnesss Set witness_name='" + textBox2.Text + "',witness_cnic='" + Convert.ToInt32(textBox3.Text) + "'    where witness_id='" + Convert.ToInt32(textBox1.Text) + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void cleardata()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public void display()
        {
            dt = new DataTable();
            con.Open();
            adpt = new SqlDataAdapter("select * from witnesss ", con);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addinfo();
            display();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateinfo();
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteinfo();
            display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 F = new Form4();
            F.Show();
        }
    }
}
