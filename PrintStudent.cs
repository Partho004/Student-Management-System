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
using DGVPrinterHelper;

namespace myproject
{
    public partial class PrintStudent : Form
    {
        Student student = new Student();
        DGVPrinter printer = new DGVPrinter();
        
        public PrintStudent()
        {
            InitializeComponent();
        }

        private void PrintStudent_Load(object sender, EventArgs e)
        {
            showData(new MySqlCommand("SELECT * FROM `student`"));
        }

        
        public void showData(MySqlCommand command)
        {
            DataGridView_student.ReadOnly = true;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            DataGridView_student.DataSource = student.GetStudentList(new MySqlCommand("SELECT * FROM student"));

            
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
           
            string selectQuery;
            if (radioButton_all.Checked)
            {
                selectQuery = "SELECT* FROM `student`";
            }
            else if (radioButton_male.Checked)
            {
                selectQuery = "SELECT * FROM `student` WHERE `Gender`='Male'";
            }
            else
            {
                selectQuery = "SELECT * FROM `student` WHERE `Gender`='Female'";
            }
            showData(new MySqlCommand(selectQuery));
        }

        private void button_print_Click(object sender, EventArgs e)
        {
           
            printer.Title = "PS Academy Students list";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "foxlearn";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_student);
        }
    }
}
