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
using System.Data.Sql;
using System.Windows.Forms.ComponentModel;


namespace ManageLog
{
    public partial class ManageLog : Form
    {
        public ManageLog()
        {
            InitializeComponent();
        }


        //initializing the sql coonection
        SqlConnection Con = new SqlConnection(@"Data Source =RAYSOFT; Initial Catalog = Sharpner; Persist Security Info=True;User ID = sa; Password=RaySmartSoft");


        //grid connectivity 
        void populate()
        {
            try
            {
                Con.Open();
                string myQuery = "SELECT Uname,UFullName,Password,Telephone FROM Userinfo2 where Isactive=1";
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }


        //add button
        public void button1_Click(object sender, EventArgs e)
        {


            try
            {


                Con.Open();
        
                SqlCommand cmd = new SqlCommand("INSERT INTO Userinfo2 (UName,UFullName,Password,Telephone) VALUES(@UName, @UFullName, @Password, @Telephone)", Con);

              
                cmd.Parameters.AddWithValue("@UName", textBox1.Text);
                cmd.Parameters.AddWithValue("@UFullName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                cmd.Parameters.AddWithValue("@Telephone", textBox4.Text);
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

       

        private void ManageLog_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        //delete button
        private void button3_Click(object sender, EventArgs e)
        {



            if (textBox4.Text == "")
            {

                MessageBox.Show("Enter users phone number");

            }
           else
            {
                Con.Open();
                string myQuery = "UPDATE Userinfo2 set IsActive=0 where Telephone ='" + textBox4.Text + "';";
                SqlCommand cmd = new SqlCommand(myQuery, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Deleted!","Delete");
                
                Con.Close();

                populate();
                ClearCrystal();


            }

        }


        //get grid values to text fields 
         public void UserGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
           
            textBox1.Text = UserGV.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = UserGV.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = UserGV.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = UserGV.SelectedRows[0].Cells[3].Value.ToString();
           

        }


        //clear button
        public void button5_Click(object sender, EventArgs e)
        {
            ClearCrystal();
        }


        //edit button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                Con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Userinfo2 SET @UName='"+textBox1+"',@UFullName='"+textBox2+"',@Password='"+textBox3+"', @Telephone='"+textBox4+"' WHERE @Telephone='"+textBox4+"';)", Con);

                cmd.Parameters.AddWithValue("@UName", textBox1.Text);
                cmd.Parameters.AddWithValue("@UFullName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                cmd.Parameters.AddWithValue("@Telephone", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User SuccessFully Modified", "User Modifier");
               

            }

            catch
            {
                

                MessageBox.Show("User Modifying Failed!");

            }

            finally
            {
                 Con.Close();
                populate();

                ClearCrystal();
            }

        }
    }
    }

    

