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

namespace myproject
{
    public partial class EnrollForm : Form
    {
        
        public EnrollForm()
        {
            InitializeComponent();
        }

        private void EnrollForm_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void textBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
