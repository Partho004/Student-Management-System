using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace myproject
{
    public partial class CourseForm : Form
    {
        private readonly Course course = new Course();

        public CourseForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Cname.Text) || string.IsNullOrEmpty(textBox_Chour.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string cName = textBox_Cname.Text;
                int chr;
                if (!int.TryParse(textBox_Chour.Text, out chr))
                {
                    MessageBox.Show("Please enter a valid number for hours.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string desc = textBox_description.Text;

                if (course.InsertCourse(cName, chr, desc)) 
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("New course inserted successfully.", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to insert course.", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Cname.Clear();
            textBox_Chour.Clear();
            textBox_description.Clear();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void showData()
        {
            DataGridView_course.DataSource = course.GetCourse();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
