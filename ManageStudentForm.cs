using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace myproject
{
    public partial class ManageStudentForm : Form
    {
       readonly DBConnect connect = new DBConnect();
        private readonly Student student = new Student();

        public ManageStudentForm()
        {
            InitializeComponent();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            ShowStudentTable();
        }

        private void ShowStudentTable()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM student", connect.GetConnection); 
            DataGridView_student.DataSource = student.GetStudentList(command);
            FormatImageColumn();
        }
        private void FormatImageColumn()
        {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            UpdateStudentDetails();
        }

        private void UpdateStudentDetails()
        {
            DataRow selectedRow = ((DataRowView)DataGridView_student.CurrentRow.DataBoundItem).Row;

            textBox_id.Text = selectedRow["StdId"].ToString();
            textBox_Fname.Text = selectedRow["FirstName"].ToString();
            textBox_Lname.Text = selectedRow["LastName"].ToString();
            dateTimePicker1.Value = (DateTime)selectedRow["BirthDate"];
            radioButton_male.Checked = selectedRow["Gender"].ToString() == "Male";
            textBox_phone.Text = selectedRow["Phone"].ToString();
            textBox_address.Text = selectedRow["Address"].ToString();
            byte[] img = (byte[])selectedRow["Image"];
            MemoryStream ms = new MemoryStream(img);
            pictureBox_student.Image = Image.FromStream(ms);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            ClearStudentDetails();
        }

        private void ClearStudentDetails()
        {
            textBox_id.Clear();
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
            radioButton_male.Checked = true;
            dateTimePicker1.Value = DateTime.Now;
            pictureBox_student.Image = null;
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_student.Image = Image.FromFile(opf.FileName);
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string searchText = textBox_search.Text;
            DataGridView_student.DataSource = student.SearchStudent(searchText);
            FormatImageColumn();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateStudentInformation())
                {
                    int id = Convert.ToInt32(textBox_id.Text);
                    string fname = textBox_Fname.Text;
                    string lname = textBox_Lname.Text;
                    DateTime bdate = dateTimePicker1.Value;
                    string phone = textBox_phone.Text;
                    string address = textBox_address.Text;
                    string gender = radioButton_male.Checked ? "Male" : "Female";
                    MemoryStream ms = new MemoryStream();
                    pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    if (student.UpdateStudent(id, fname, lname, bdate, gender, phone, address, img))
                    {
                        ShowStudentTable();
                        MessageBox.Show("Student data updated", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearStudentDetails();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update student data", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred while updating the student record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateStudentInformation()
        {
            if (string.IsNullOrWhiteSpace(textBox_Fname.Text) ||
                string.IsNullOrWhiteSpace(textBox_Lname.Text) ||
                string.IsNullOrWhiteSpace(textBox_phone.Text) ||
                string.IsNullOrWhiteSpace(textBox_address.Text) ||
                pictureBox_student.Image == null)
            {
                MessageBox.Show("Please fill in all fields and provide a student photo.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            int bornYear = dateTimePicker1.Value.Year;
            int currentYear = DateTime.Now.Year;
            if (currentYear - bornYear < 10 || currentYear - bornYear > 100)
            {
                MessageBox.Show("The student age must be between 10 and 100", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox_id.Text);
                if (MessageBox.Show("Are you sure you want to remove this student", "Remove Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.DeleteStudent(id))
                    {
                        ShowStudentTable();
                        MessageBox.Show("Student Removed", "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearStudentDetails();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred while deleting the student record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void DataGridView_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}
