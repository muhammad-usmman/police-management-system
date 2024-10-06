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
    public partial class Form7 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=USMAN\SQLEXPRESS;Initial Catalog=POLICE MANAGEMENT;Integrated Security=True");
        SqlDataAdapter adpt;
        DataTable dt;

        public Form7()
        {
            InitializeComponent();
            display();
        }

        public void addinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into crime_register(crime_id,crime_name,date_of_offence,date_of_report,status,arrested,witness_id,victim_id,oficer_id,accused_id,complainer_id) Values('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "','" + Convert.ToInt32(textBox3.Text) +"','"+Convert.ToInt32(textBox4.Text)+"','"+textBox5.Text+"','"+textBox6.Text+"','"+Convert.ToInt32(textBox7.Text)+ "','" + Convert.ToInt32(textBox8.Text) + "','" + Convert.ToInt32(textBox9.Text) + "','" + Convert.ToInt32(textBox10.Text) + "','" + Convert.ToInt32(textBox11.Text) + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void deleteinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from crime_register Where  crime_id='" + Convert.ToInt32(textBox1.Text) + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void update_info()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update crime_register Set crime_name='" +textBox2.Text+"',date_of_offence'"+textBox3.Text+"',date_of_report='"+textBox4.Text+"', status='"+textBox5.Text+"',arrested='"+textBox6.Text+ "',witness_id='" + Convert.ToInt32(textBox7.Text) + "',victim_id='" + Convert.ToInt32(textBox8.Text) + "',oficer_id='" + Convert.ToInt32(textBox9.Text) + "',accused_id='" + Convert.ToInt32(textBox10.Text) + "',complainer_id='" + Convert.ToInt32(textBox11.Text) + "'where crime_id='" + Convert.ToInt32(textBox1.Text) + "'";
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
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            

        }

        public void display()
        {
            dt = new DataTable();
            con.Open();
            adpt = new SqlDataAdapter("select * from crime_register ", con);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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
            Form1 F = new Form1();
            F.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
