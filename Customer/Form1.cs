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

namespace Customer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source =RAYSOFT; Initial Catalog = Sharpner; Persist Security Info=True;User ID = sa; Password=RaySmartSoft");


        //grid connectivity 
        void populate()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM Customer";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                UserGV.DataSource = ds.Tables[0];
                Con.Close();
            }

            catch
            {

            }

        }


        //form clear method

        public void ClearCrystal()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void UserGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

             //add button
        public void button1_Click(object sender, EventArgs e)
        {


            try
            {


                Con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Customer (CusID,CusName,CusTel,Age,AdvPayment) VALUES(@CusID, @CusName, @CusTel, @Age, @AdvPayment )", Con);


                cmd.Parameters.AddWithValue("@CusID", textBox1.Text);
                cmd.Parameters.AddWithValue("@CusName", textBox2.Text);
                cmd.Parameters.AddWithValue("@CusTel", textBox3.Text);
                cmd.Parameters.AddWithValue("@Age", textBox4.Text);
                cmd.Parameters.AddWithValue("@AdvPayment", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User SuccessFully Added", "Adding User");


            }

            catch
            {
                // MessageBox.Show(ex.Message, "Alert");

                MessageBox.Show("User Adding Failed!");

            }

            finally
            {
                Con.Close();
                populate();
                ClearCrystal();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }

