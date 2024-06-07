using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace myproject
{
    internal class Student
    {
        private readonly DBConnect connect = new DBConnect();

        public bool InsertStudent(string fname, string lname, DateTime bdate, string gender, string phone, string address, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student`(`StdFirstName`, `StdLastName`, `Birthdate`, `Gender`, `Phone`, `Address`, `Photo`) VALUES(@fn, @ln, @bd, @gd, @ph, @adr, @img)", connect.GetConnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

            connect.OpenConnection();
            bool success = command.ExecuteNonQuery() == 1;
            connect.CloseConnection();
            return success;
        }

        public DataTable GetStudentList(MySqlCommand command)
        {
            command.Connection = connect.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public string GetStudentCountByCourseAndGender(string courseName, string gender)
        {
            using (var connection = connect.GetConnection)
            {
                string query = "SELECT COUNT(*) FROM student INNER JOIN score ON score.StudentId = student.StdId WHERE score.CourseName = @courseName AND student.Gender = @gender";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@courseName", courseName);
                command.Parameters.AddWithValue("@gender", gender);

                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();

                return result != null ? result.ToString() : "0";
            }
        }

        public string GetStudentCount(string gender)
        {
            MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) FROM student WHERE `Gender`='{gender}'", connect.GetConnection);
            connect.OpenConnection();
            string count = command.ExecuteScalar().ToString();
            connect.CloseConnection();
            return count;
        }
     


        public DataTable SearchStudent(string searchData)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student` WHERE CONCAT(`StdFirstName`,`StdLastName`,`Address`) LIKE '%" + searchData + "%'", connect.GetConnection);
            return GetStudentList(command);
        }

        public bool UpdateStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `student` SET `StdFirstName`=@fn,`StdLastName`=@ln,`Birthdate`=@bd,`Gender`=@gd,`Phone`=@ph,`Address`=@adr,`Photo`=@img WHERE  `StdId`= @id", connect.GetConnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

            connect.OpenConnection();
            bool success = command.ExecuteNonQuery() == 1;
            connect.CloseConnection();
            return success;
        }

        public bool DeleteStudent(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `student` WHERE `StdId`=@id", connect.GetConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            connect.OpenConnection();
            bool success = command.ExecuteNonQuery() == 1;
            connect.CloseConnection();
            return success;
        }

        public DataTable GetList(MySqlCommand command)
        {
            command.Connection = connect.GetConnection;
            return GetStudentList(command);
        }
    }
}

