using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace myproject
{
    public partial class EnrollCourseForm : Form
    {

        readonly DBConnect connect = new DBConnect();
        internal Course course = new Course();
        private readonly Student student = new Student();
        public EnrollCourseForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void EnrollCourseFom_Load(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT StdId FROM student";

            using (MySqlConnection connection = connect.GetConnection)
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable students = new DataTable();
                        adapter.Fill(students);

                        ComboBox1_SelectStudent.DataSource = students;
                        ComboBox1_SelectStudent.DisplayMember = "StdId";
                        ComboBox1_SelectStudent.ValueMember = "StdId";
                    }
                }
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        { 
            DataTable courses = course.GetCourse();

            ComboBox2_SelectCourse.DataSource = courses;
            ComboBox2_SelectCourse.DisplayMember = "CourseName";
            ComboBox2_SelectCourse.ValueMember = "CourseId";

        }
    }
}
