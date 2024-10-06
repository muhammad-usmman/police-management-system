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
   
    
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=USMAN\SQLEXPRESS;Initial Catalog=POLICE MANAGEMENT;Integrated Security=True");
        SqlDataAdapter adpt;
        DataTable dt;

        public Form2()
        {
            InitializeComponent();
            display();
        }

        public void addinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText= "Insert into accused(accused_id,accused_name,accused_fname,accused_cnic,accused_age) Values('"+Convert.ToInt32(textBox1.Text)+"','"+textBox2.Text+"','"+textBox3.Text+"','"+Convert.ToInt32(textBox4.Text)+"','"+Convert.ToInt32(textBox5.Text)+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void deleteinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from accused where accused_id='"+Convert.ToInt32(textBox1.Text)+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void updateinfo()
        {


            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update  accused set accused_name='"+textBox2.Text+ "',accused_fname='"+textBox3.Text+ "',accused_cnic='"+Convert.ToInt32(textBox4.Text)+ "',accused_age'"+Convert.ToInt32(textBox5.Text) + "'    where accused_id='" + Convert.ToInt32(textBox1.Text) + "'";
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
         }

        public void display()
        {
            dt = new DataTable();
            con.Open();
            adpt = new SqlDataAdapter("select * from accused ", con);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            addinfo();
            display();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteinfo();
            display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 F = new Form3();
            F.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateinfo();
            display();
        }
    }
}
