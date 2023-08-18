using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    internal class CRUD
    {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\92332\Desktop\WPF\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True";
        bool connection_stataus;
        string user;
        
        public bool Check_status()
        {
            SqlConnection cursor = new SqlConnection(connection);

            try
            {
                cursor.Open();
                connection_stataus = true;
                return connection_stataus;
            }
            catch 
            {
                connection_stataus = false;
                return connection_stataus;
            }
        }
        public void Insert_Data(int Id, string Name, string Email, int Age, string Password)
        {
            
            SqlConnection cursor = new SqlConnection(connection);
            cursor.Open();
            if (Select.usertype == "Admin")
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO ADMIN VALUES (@ID,@NAME,@EMAIL,@AGE,@PASSWORD)", cursor);
                cmd1.Parameters.AddWithValue("@ID", Id);
                cmd1.Parameters.AddWithValue("@NAME", Name);
                cmd1.Parameters.AddWithValue("@EMAIL", Email);
                cmd1.Parameters.AddWithValue("@AGE", Age);
                cmd1.Parameters.AddWithValue("@PASSWORD", Password);
                cmd1.ExecuteNonQuery();
                cursor.Close(); 
                MessageBox.Show("Admin Register Successfull");
            }
            else if(Select.usertype == "User")
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO RUSER VALUES (@ID,@NAME,@EMAIL,@AGE,@PASSWORD)", cursor);
                cmd1.Parameters.AddWithValue("@ID", Id);
                cmd1.Parameters.AddWithValue("@NAME", Name);
                cmd1.Parameters.AddWithValue("@EMAIL", Email);
                cmd1.Parameters.AddWithValue("@AGE", Age);
                cmd1.Parameters.AddWithValue("@PASSWORD", Password);
                cmd1.ExecuteNonQuery();
                cursor.Close();
                MessageBox.Show("User Register Successfull");
            }
        }
        
        public void Update_Data(string Name, string Email, int Age,string Password)
        {
           
            SqlConnection cursor = new SqlConnection(connection);
            cursor.Open();

            if (Select.usertype == "Admin")
            {
                SqlCommand cmd = new SqlCommand("UPDATE ADMIN SET EMAIL=@EMAIL, AGE=@AGE, PASSWORD=@PASSWORD WHERE NAME=@NAME", cursor);

                cmd.Parameters.AddWithValue("@NAME",Name);
                cmd.Parameters.AddWithValue("@EMAIL", Email);
                cmd.Parameters.AddWithValue("@AGE", Age);
                cmd.Parameters.AddWithValue("@PASSWORD", Password);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Data Successfully Updated.");
                cursor.Close() ;
            }
            else if (Select.usertype == "User")
            {
                SqlCommand cmd = new SqlCommand("UPDATE RUSER SET EMAIL=@EMAIL, AGE=@AGE, PASSWORD=@PASSWORD WHERE NAME=@NAME", cursor);
                cmd.Parameters.AddWithValue("@NAME", Name);
                cmd.Parameters.AddWithValue("@EMAIL", Email);
                cmd.Parameters.AddWithValue("@AGE", Age);
                cmd.Parameters.AddWithValue("@PASSWORD", Password);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Data Successfully Updated.");
                cursor.Close();
            }
            
        }
        public void Delete_Data(string Name)
        {

            SqlConnection cursor = new SqlConnection(connection);
            cursor.Open();

            if (Select.usertype == "Admin")
            {
                SqlCommand cmd = new SqlCommand("DELETE ADMIN WHERE NAME=@NAME", cursor);
                cmd.Parameters.AddWithValue("@NAME", Name);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Data Remove Successfully");
                cursor.Close();
            }
            else if (Select.usertype == "User")
            {
                SqlCommand cmd = new SqlCommand("DELETE RUSER WHERE NAME=@NAME", cursor);
                cmd.Parameters.AddWithValue("@NAME", Name);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Data Remove Successfully");
                cursor.Close();
            }

        }
        public void Login(string Name, string Password)
        {
            SqlConnection cursor = new SqlConnection(connection);
            SqlCommand cmd;
            SqlDataReader dr;
            
            if (Select.usertype == "Admin")
            {
                cursor.Open();
                cmd = new SqlCommand("SELECT * FROM ADMIN WHERE ADMIN.NAME=@NAME AND ADMIN.PASSWORD=@PASSWORD", cursor);
                cmd.Parameters.AddWithValue("@NAME", Name);
                cmd.Parameters.AddWithValue("@PASSWORD", Password);
                dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    MessageBox.Show("Admin Login Successfull");
                    Admin form = new Admin();
                    form.Info(Name);
                    form.Show();
                    
                    cursor.Close();
                }
                else
                {
                    MessageBox.Show("Admin Login Failed");
                    cursor.Close();
                }

            }
            else if (Select.usertype == "User")
            {
                cursor.Open();
                cmd = new SqlCommand("SELECT * FROM RUSER WHERE RUSER.NAME=@NAME AND RUSER.PASSWORD=@PASSWORD", cursor);
                cmd.Parameters.AddWithValue("@NAME", Name);
                cmd.Parameters.AddWithValue("@PASSWORD", Password);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("User Login Successfull");
                    cursor.Close();
                    User form = new User();
                    form.Info(Name);
                    form.Show();
                }
                else
                {
                    MessageBox.Show("User Login Failed");
                    cursor.Close();
                }


                /*cmd1.ExecuteNonQuery();*/

            }
        }
    }
}
