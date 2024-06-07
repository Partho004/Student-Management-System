using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace myproject
{
    internal class EnrollCourse
    {
       readonly DBConnect connect = new DBConnect();

        public DataTable GetCourses(MySqlCommand command = null)
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

        public bool EnrollStudentInCourse(int StdId, int CourseId)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `enroll`(`StdId`, `CourseId`) VALUES (@sid, @cid)", connect.GetConnection);
            command.Parameters.AddWithValue("@sid", StdId);
            command.Parameters.AddWithValue("@cid", CourseId);

            connect.OpenConnection();
            int rowsAffected = command.ExecuteNonQuery();
            connect.CloseConnection();

            return rowsAffected == 1;
        }



        public bool IStudentEnrolledInCourse(int StdId, int CourseId)
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM `enroll` WHERE `StdId` = @sid AND `CourseId` = @cid", connect.GetConnection);
            command.Parameters.AddWithValue("@sid", StdId);
            command.Parameters.AddWithValue("@cid", CourseId);

            connect.OpenConnection();
            object result = command.ExecuteScalar();
            connect.CloseConnection();

            return Convert.ToInt32(result) > 0;
        }
    }
}
