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

namespace OrderManager
{
    public partial class OrderManager : Form
    {
        public OrderManager()
        {
            InitializeComponent();
        }


        SqlConnection Con = new SqlConnection(@"Data Source =RAYSOFT; Initial Catalog = Sharpner; Persist Security Info=True;User ID = sa; Password=RaySmartSoft");



        public void populate()
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

        public void populateproduct()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM Product";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                GvView2.DataSource = ds.Tables[0];
                Con.Close();
            }

            catch
            {

            }

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

        }




        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void UserGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = UserGV.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populate();
            populateproduct();
            fillsearchcombo();
    
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void GvView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT * FROM Product where ProDes='" + comboBox1.SelectedValue.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(myQuery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                GvView2.DataSource = ds.Tables[0];
                Con.Close();
            }

            catch
            {

            }

        }

    }
}

