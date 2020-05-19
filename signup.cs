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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Connect cl = new Connect();
            MySqlCommand command = new MySqlCommand("INSERT INTO `data`(`USERNAME`, `PASSWORD`) VALUES (@usn, @pass) ", cl.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUser.Text ;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPass.Text ;
            String user = textBoxUser.Text;
            String pass = textBoxPass.Text;
            String con = textBoxConPass.Text;
           
            if (user.Trim().Equals("") || pass.Trim().Equals("") || con.Trim().Equals(""))
            {
                MessageBox.Show("ERROR", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            {
                if (pass == con)
                {
                    // open connection
                    cl.openConnection();
                    if (checkUsername())
                    {
                        MessageBox.Show("This username isn't available.Create new user. ");
                    }
                    else
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Account Create");
                            this.Hide();
                            Form1 s = new Form1();
                            s.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Error");
                }
            }

            
           

            //close
            cl.closeConnection();
        }

        //เช็ค user ไม่ให้ซ้ำ
        public Boolean checkUsername()
        {
            Connect cl = new Connect();
            string username = textBoxUser.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM  `data` WHERE `USERNAME` = @usn ", cl.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void label4_Enter(object sender, EventArgs e)
        {

        }

        private void label4Close_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Leave(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBoxUser_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
