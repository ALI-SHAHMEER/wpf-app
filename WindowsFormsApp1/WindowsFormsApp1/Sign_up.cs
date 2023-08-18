using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Sign_up : Form
    {
 
        CRUD obj = new CRUD();
        
            

        public Sign_up()
        {
            InitializeComponent();
        }

        private void Sign_up_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int id, age;
            string name, email, password;
            name = textBox1.Text;
            id = int.Parse(textBox2.Text);
            email = textBox3.Text;
            age = int.Parse(textBox4.Text);
            password = textBox5.Text;


            obj.Insert_Data(id,name,email,age,password);
            /*MessageBox.Show(obj.Check_status().ToString());*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
