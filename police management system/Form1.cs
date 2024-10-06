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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = USMAN\SQLEXPRESS; Initial Catalog = POLICE MANAGEMENT; Integrated Security = True");
        SqlDataAdapter adpt;
        DataTable dt;


        public Form1()
        {
            InitializeComponent();
            display();
         }



        public void addinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into victim(victim_id,victim_cnic,victim_name,victim_fname,victim_contact,victim_age) Values('" + Convert.ToInt32(textBox1.Text) + "','" + Convert.ToInt32(textBox2.Text) + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Convert.ToInt32(textBox5.Text) + "','" + Convert.ToInt32(textBox6.Text) + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }



        public void deleteinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from victim Where  victim_id='" + Convert.ToInt32(textBox1.Text) + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void update_info()
        {

            con.Open();
            SqlCommand cmd =new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update victim Set victim_name='" + textBox3.Text + "',victim_fname='" + textBox4.Text + "',victim_cnic='"+Convert.ToInt32(textBox2.Text)+ "',victim_contact='" + Convert.ToInt32(textBox2.Text) + "',victim_age='" + Convert.ToInt32(textBox2.Text) + "'    where victim_id='" + Convert.ToInt32(textBox1.Text) + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void cleardata()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";


        }

        public void display()
        {
            dt = new DataTable();
            con.Open();
            adpt = new SqlDataAdapter("select * from victim ", con);
        adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addinfo();
            display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update_info();
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
            Form2 F = new Form2();
            F.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
