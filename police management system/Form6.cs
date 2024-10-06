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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = USMAN\SQLEXPRESS; Initial Catalog = POLICE MANAGEMENT; Integrated Security = True");
        SqlDataAdapter adpt;
        DataTable dt;

        public Form6()
        {
            InitializeComponent();
            display();
        }

        public void addinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into police_station(police_station_id,police_station_name,police_station_district,police_station_city,police_station_oficer_id,police_station_crime_id) Values('" + Convert.ToInt32(textBox1.Text) + "','" + Convert.ToInt32(textBox2.Text) + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Convert.ToInt32(textBox5.Text) + "','" + Convert.ToInt32(textBox6.Text) + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }



        public void deleteinfo()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Delete from police_station Where  police_station_id='" + Convert.ToInt32(textBox1.Text) + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            cleardata();
        }

        public void update_info()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update police_station Set police_station_name='" +textBox2.Text+ "',city='" + textBox4.Text + "',district='" + textBox3.Text + "',oficer_id='" +Convert.ToInt32( textBox5.Text) + "'where police_station_id='" + Convert.ToInt32(textBox6.Text) + "'";
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
            adpt = new SqlDataAdapter("select * from police_station ", con);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            addinfo();
            cleardata();
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
            Form7 F = new Form7();
            F.Show();
        }
    }
}
