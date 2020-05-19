using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KP_School
{
    public partial class membercs : Form
    {
        CLIENT client = new CLIENT();
        public membercs(String text)
        {
            InitializeComponent();
            txt.Text = text;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void membercs_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClients();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
