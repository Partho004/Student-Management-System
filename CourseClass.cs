using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace myproject
{
    internal class Course
    {
        readonly DBConnect connect = new DBConnect();

        public bool InsertCourse(string cName, int hr, string desc)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `course`(`CourseName`, `CourseHour`, `Description`) VALUES (@cn,@ch,@desc)", connect.GetConnection);
            command.Parameters.AddWithValue("@cn", cName);
            command.Parameters.AddWithValue("@ch", hr);
            command.Parameters.AddWithValue("@desc", desc);

            connect.OpenConnection();
            int rowsAffected = command.ExecuteNonQuery();
            connect.CloseConnection();

            return rowsAffected == 1;
        }

        public DataTable GetCourse(MySqlCommand command = null)
        {
            if (command == null)
            {
                
                command = new MySqlCommand("SELECT * FROM `course`", connect.GetConnection);
            }

            DataTable table = new DataTable();

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                adapter.Fill(table);
            }

            return table;
        }

        public List<int> GetEnrolledCoursesForStudent(int studentId)
        {
            
            return new List<int>(); 
        }

        public bool UpdateCourse(int courseId, string newName, int newHours, string newDescription)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `course` SET `CourseName` = @cn, `CourseHour` = @ch, `Description` = @desc WHERE `CourseId` = @id", connect.GetConnection);
            command.Parameters.AddWithValue("@cn", newName);
            command.Parameters.AddWithValue("@ch", newHours);
            command.Parameters.AddWithValue("@desc", newDescription);
            command.Parameters.AddWithValue("@id", courseId);

            connect.OpenConnection();
            int rowsAffected = command.ExecuteNonQuery();
            connect.CloseConnection();

            return rowsAffected == 1;
        }

        public bool DeleteCourse(int courseId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `course` WHERE `CourseId` = @id", connect.GetConnection);
            command.Parameters.AddWithValue("@id", courseId);

            connect.OpenConnection();
            int rowsAffected = command.ExecuteNonQuery();
            connect.CloseConnection();

            return rowsAffected == 1;
        }
    }
}
