using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Select : Form
    {
        public Select()
        {
            InitializeComponent();
        }
        static public string usertype;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                usertype = radioButton1.Text;
                /*MessageBox.Show(usertype);*/
            }
            else if(radioButton2.Checked)
            {
                usertype = radioButton2.Text;
                /*MessageBox.Show(usertype);*/
            }
            Form1 form = new Form1();
            form.Show();
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
