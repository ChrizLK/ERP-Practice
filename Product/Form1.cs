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

namespace Product
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

//sql connecton db 
        SqlConnection Con = new SqlConnection(@"Data Source =RAYSOFT; Initial Catalog = Sharpner; Persist Security Info=True;User ID = sa; Password=RaySmartSoft");



//category fill 
        public void fillcategory()
        {

            string query = "Select * from Category";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;

            try
            {
                Con.Open();

                DataTable dtc = new DataTable();
                dtc.Columns.Add("CatName", typeof (string));
                rdr = cmd.ExecuteReader();
                dtc.Load(rdr);
                comboBox1.ValueMember = "CatName";
                comboBox1.DataSource = dtc;
               

            }

            catch
            {
                

            }

            finally
            {

                Con.Close();

            }

       //search combo 

        }

        public void fillsearchcombo()
        {

            string query = "Select * from Category where CatID>0";
            SqlCommand cmd2 = new SqlCommand(query, Con);
            SqlDataReader rdr;

            try
            {
                Con.Open();

                DataTable dtc = new DataTable();
                dtc.Columns.Add("CatName", typeof(string));
                rdr = cmd2.ExecuteReader();
                dtc.Load(rdr);
                comboBox2.ValueMember = "CatName";
                comboBox2.DataSource = dtc;
              
            }

            catch
            {


            }

            finally
            {

                Con.Close();

            }

        }



        public void filterbycategory()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM Product where ProDes='" + comboBox2.SelectedValue.ToString()+"'";
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




        //grid connectivity 
        public void populate()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM Product";
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void UserGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            populate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillcategory();
            populate();
            fillsearchcombo();
        }

        //add button
        public void button1_Click(object sender, EventArgs e)
        {


            try
            {


                Con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Product (ProID,ProName,Qty,Price,ProDes) VALUES(@ProID, @ProName, @Qty, @Price, @ProDes)", Con);


                cmd.Parameters.AddWithValue("@ProID", textBox1.Text);
                cmd.Parameters.AddWithValue("@ProName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Qty", textBox3.Text);
                cmd.Parameters.AddWithValue("@Price", textBox4.Text);
                cmd.Parameters.AddWithValue("@ProDes", comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product SuccessFully Added", "Adding User");


            }

            catch
            {
                // MessageBox.Show(ex.Message, "Alert");

                MessageBox.Show("User Adding Failed! Add Valid Inputs","Failed");

            }

            finally
            {
                Con.Close();
                populate();
                ClearCrystal();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearCrystal();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            filterbycategory();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
