using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KP_School
{
    public partial class Main : Form
    {
        CLIENT client = new CLIENT();
        public Main(string text)
        {
            InitializeComponent();
            txt.Text = text;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClients();
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void neww_Click(object sender, EventArgs e)
        {

        }

        private void txt_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = client.getClients();
        }

        private void update_Click(object sender, EventArgs e)
        {

        }

        private void edit_Click(object sender, EventArgs e)
        {
           


        }


        private void delete_Click(object sender, EventArgs e)
        {
            


        }

        private void neww_Click_1(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //แก้ไขข้อมูล
            txtidd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtlname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtid.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtkana.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txttel.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

       

        private void txtkana_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtkana_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtemail.Text,pattern))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(this.txtemail, "Please provide valid Mail address");
            }
        }

        private void txtidd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                errorProvider2.SetError(this.txtid, "Please Enter Number");
                
            }
            else
            {

                errorProvider2.Clear();
            }
            
        }

        private void txttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                errorProvider3.SetError(this.txttel, "Please Enter Number");
            }
            else
            {
                
                errorProvider3.SetError(this.txttel, "");
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char cha = e.KeyChar;
            if (!char.IsLetter(cha)&& cha !=8)
            {
                e.Handled = true;
                errorProvider4.SetError(this.txtname, "Please Enter Name");
            }
            else
            {
                errorProvider4.Clear();
                
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chh = e.KeyChar;
            if (!char.IsLetter(chh) && chh != 8)
            {
                e.Handled = true;
                errorProvider5.SetError(this.txtlname, "Please Enter Lastname");
            }
            else
            {
               errorProvider5.Clear();

            }
        }

        private void txtidd_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String name = txtname.Text;
            String lname = txtlname.Text;
            String id = txtid.Text;
            String kana = txtkana.Text;
            String tel = txttel.Text;
            String email = txtemail.Text;

            if (name.Trim().Equals("") || lname.Trim().Equals("") || id.Trim().Equals("") || kana.Trim().Equals("") || tel.Trim().Equals("") || email.Trim().Equals(""))
            {
                MessageBox.Show("ERROR", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Boolean insertClient = client.insertClient(name, lname, id, kana, tel, email);

                if (insertClient)
                {
                    txtidd.Text = "";
                    txtname.Text = "";
                    txtlname.Text = "";
                    txtid.Text = "";
                    txtkana.Text = "";
                    txttel.Text = "";
                    txtemail.Text = "";
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("SAVED", "Add client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR", "Add client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int idd;
            String name = txtname.Text;
            String lname = txtlname.Text;
            String id = txtid.Text;
            String kana = txtkana.Text;
            String tel = txttel.Text;
            String email = txtemail.Text;
            

            try
            {
                idd = Convert.ToInt32(txtidd.Text);
                if (name.Trim().Equals("") || lname.Trim().Equals("") || id.Trim().Equals("") || kana.Trim().Equals("") || tel.Trim().Equals("") || email.Trim().Equals(""))
                {
                    MessageBox.Show("ERROR", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    Boolean insertClient = client.editClient(idd, name, lname, id, kana, tel, email);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = client.getClients();
                        MessageBox.Show("EDIT Successed", "EDIT client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "EDIT client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Convert.ToString(txtidd.Text);

                if (client.removeClient(id))
                {
                    txtidd.Text = "";
                    txtname.Text = "";
                    txtlname.Text = "";
                    txtid.Text = "";
                    txtkana.Text = "";
                    txttel.Text = "";
                    txtemail.Text = "";
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Deleted Successful", "Delete client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR Not Delete", "Delete client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtidd.Text = "";
            txtname.Text = "";
            txtlname.Text = "";
            txtid.Text = "";
            txtkana.Text = "";
            txttel.Text = "";
            txtemail.Text = "";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
