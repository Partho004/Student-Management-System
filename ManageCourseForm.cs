using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myproject
{
    public partial class ManageCourseForm : Form
    {
        internal Course course = new Course();
        public ManageCourseForm()
        {
            InitializeComponent();
        }

        private void ManageCourseForm_Load(object sender, EventArgs e)
        {
            showData();

        }
        private void showData()
        {
            DataGridView_course.DataSource = course.GetCourse();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_id.Clear();
            textBox_Cname.Clear();
            textBox_Chour.Clear();
            textBox_description.Clear();
        }
          
        private void button_Update_Click(object sender, EventArgs e)
        {
            if (textBox_Cname.Text == "" || textBox_Chour.Text == "" || textBox_id.Text.Equals(""))
            {
                MessageBox.Show("Need Course data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(textBox_id.Text);
                string cName = textBox_Cname.Text;
                int chr = Convert.ToInt32(textBox_Chour.Text);
                string desc = textBox_description.Text;


                if (course.UpdateCourse(id, cName, chr, desc))
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("course update successfuly", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error-Course not Edit", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text.Equals(""))
            {
                MessageBox.Show("Need Course Id", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(textBox_id.Text);
                    if (course.DeleteCourse(id))
                    {
                        showData();
                        button_clear.PerformClick();
                        MessageBox.Show("course Deleted", "Removed Course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Removed Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView_course_Click(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_course.CurrentRow.Cells[0].Value.ToString();
            textBox_Cname.Text = DataGridView_course.CurrentRow.Cells[1].Value.ToString();
            textBox_Chour.Text = DataGridView_course.CurrentRow.Cells[2].Value.ToString();
            textBox_description.Text = DataGridView_course.CurrentRow.Cells[3].Value.ToString();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            
            MySqlCommand searchCommand = new MySqlCommand("SELECT * FROM `course` WHERE CONCAT(`CourseName`) LIKE '%" + textBox_search.Text + "%'");

          
            DataGridView_course.DataSource = course.GetCourse(searchCommand);

            textBox_search.Clear();
        }



        private void DataGridView_course_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView_course_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_description_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Chour_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Cname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
