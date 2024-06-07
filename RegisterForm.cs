using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace myproject
{
    public partial class RegisterForm : Form
    {
        private readonly Student student = new Student();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            ShowStudentTable();
        }

        private void ShowStudentTable()
        {
            DataGridView_student.DataSource = student.GetStudentList(new MySqlCommand("SELECT * FROM `student`")); 
            FormatImageColumn();
        }

        private void FormatImageColumn()
        {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_student.Image = Image.FromFile(opf.FileName);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Verify())
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string fname = textBox_Fname.Text;
                string lname = textBox_Lname.Text;
                DateTime bdate = dateTimePicker1.Value;
                string phone = textBox_phone.Text;
                string address = textBox_address.Text;
                string gender = radioButton_male.Checked ? "Male" : "Female";

                int age = DateTime.Now.Year - bdate.Year;
                if (age < 10 || age > 100)
                {
                    MessageBox.Show("The student age must be between 10 and 100", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MemoryStream ms = new MemoryStream();
                pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                byte[] img = ms.ToArray();

                if (student.InsertStudent(fname, lname, bdate, gender, phone, address, img))
                {
                    ShowStudentTable();
                    MessageBox.Show("New student added successfully.", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("File error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Verify()
        {
            string phonePattern = @"^\d{11}$"; 

            if (string.IsNullOrEmpty(textBox_Fname.Text) ||
                string.IsNullOrEmpty(textBox_Lname.Text) ||
                string.IsNullOrEmpty(textBox_phone.Text) ||
                string.IsNullOrEmpty(textBox_address.Text) ||
                pictureBox_student.Image == null)
            {
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox_phone.Text, phonePattern))
            {
                MessageBox.Show("The phone number must be exactly 11 digits.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void ClearFields()
        {
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
            radioButton_male.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox_student.Image = null;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
