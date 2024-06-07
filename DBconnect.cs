using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace myproject
{
    class DBConnect
    {
        MySqlConnection connect = new MySqlConnection("datasource=localhost;port=3306;username=partho;password=root1234;database=studentdb");

        public MySqlConnection GetConnection
        {
            get { return connect; }
        }

        public void OpenConnection()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();
        }

        public void CloseConnection()
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
    }
}
