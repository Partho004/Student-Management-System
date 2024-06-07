using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace myproject
{
    public partial class MainForm : Form
    {
        Student student = new Student();
        Course course = new Course();
        EnrollCourseForm enrollCourseForm = new EnrollCourseForm();



        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            studentCount();
            
            comboBox_course.DataSource = course.GetCourse();
            comboBox_course.DisplayMember = "CourseName";
            comboBox_course.ValueMember = "CourseName";
        }

      
        private void studentCount()
        {
           
            label_totalStd.Text = "Total Students : " + GetTotalStudentCount();
        }

        private string GetTotalStudentCount()
        {
            string maleCount = student.GetStudentCount("Male");
            string femaleCount = student.GetStudentCount("Female");
            return "Male: " + maleCount + ", Female: " + femaleCount;
        }

        private void customizeDesign()
        {
            panel_stdsubmenu.Visible = false;
            panel_courseSubmenu.Visible = false;
            panel_scoreSubmenu.Visible = false;
        }

        private void hideSubmenu()
        {
            panel_stdsubmenu.Visible = false;
            panel_courseSubmenu.Visible = false;
            panel_scoreSubmenu.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            hideSubmenu();
            submenu.Visible = true;
        }

        private void button_std_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_stdsubmenu);
        }

        private void button_registration_Click(object sender, EventArgs e)
        {
            openChildForm(new RegisterForm());
            hideSubmenu();
        }

        private void button_manageStd_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudentForm());
            hideSubmenu();
        }
        private void button_score_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_courseSubmenu);
        }
        private void button_newScore_Click_1(object sender, EventArgs e)
        {

            openChildForm(new ScoreForm());
            hideSubmenu();
        }

        private void button_manageScore_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageScoreForm());
            hideSubmenu();
        }

        private void button_course_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_courseSubmenu);

        }
       
        private void button_coursePrint_Click(object sender, EventArgs e)
        {

            openChildForm(new EnrollCourseForm());
            hideSubmenu();
        }
        private void button_manageCourse_Click_1(object sender, EventArgs e)
        {
            openChildForm(new ManageCourseForm());
            hideSubmenu();
        }

        private void button_newCourse_Click_1(object sender, EventArgs e)
        {
            openChildForm(new CourseForm());
            hideSubmenu();
        }


        private void button_stdPrint_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintStudent());
            hideSubmenu();
        }

        private void label11_Click(object sender, EventArgs e)
        {
           
        }

        private void label_cmale_Click(object sender, EventArgs e)
        {
            
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            CloseActiveForm();
            panel_main.Controls.Add(panel_cover);
            studentCount();
        }

        private void button_exit_Click_1(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            Hide();
            login.Show();
        }

        private void comboBox_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourse = comboBox_course.Text;
            label_cmale.Text = "Male: " + GetStudentCountByGender(selectedCourse, "Male");
            label_cfemale.Text = "Female: " + GetStudentCountByGender(selectedCourse, "Female");
        }

        private string GetStudentCountByGender(string courseName, string gender)
        {
            return student.GetStudentCountByCourseAndGender(courseName, gender);
        }

        private void openChildForm(Form childForm)
        {
            CloseActiveForm();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void CloseActiveForm()
        {
            if (panel_main.Controls.Count > 0 && panel_main.Controls[0] is Form activeForm)
            {
                activeForm.Close();
                activeForm.Dispose();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_scorePrint_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
