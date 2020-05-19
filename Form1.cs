using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KP_School
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //เปลี่ยนหน้า
            this.Hide();
            signup s = new signup();
            s.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {  
            string sql = "SELECT * FROM data WHERE USERNAME ='" + textBox1.Text + "'AND PASSWORD='" + textBox2.Text + "'";
            MySqlConnection con = new MySqlConnection("host=localhost;user=kati;password=123456;database=data");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            if (textBox1.Text == "admin" && textBox2.Text== "111" )
            {
                this.Hide();
                Main k = new Main(textBox1.Text);
                k.Show();
            }
            
            //ดึงข้อมูลการ login จาก myadmin
          
            else if (reader.Read())
            {
                // เปลี่ยนไปหน้าถัดไป
                this.Hide();
                membercs k = new membercs(textBox1.Text);
                k.Show();
            }
            else
            {
                //ถ้าลืมใส่จะ error ต้องใส่ทุกช่อง
                if (textBox1.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username to Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox2.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password to Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("This Username Or Password Doesn't Exists", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
