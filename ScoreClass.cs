using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myproject
{
    class ScoreClass
    {
        DBConnect connect = new DBConnect();
        
        public bool insertScore(int stdid, string courName, double scor, string desc)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `score`(`StudentId`, `CourseName`, `Score`, `Description`) VALUES (@stid,@cn,@sco,@desc)", connect.GetConnection);
        
            command.Parameters.Add("@stid", MySqlDbType.Int32).Value = stdid;
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = courName;
            command.Parameters.Add("@sco", MySqlDbType.Double).Value = scor;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            connect.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseConnection();
                return true;
            }
            else
            {
                connect.CloseConnection();
                return false;
            }
        }
        
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

     
        public bool checkScore(int stdId, string cName)
        {
            DataTable table = getList(new MySqlCommand("SELECT * FROM `score` WHERE `StudentId`= '" + stdId + "' AND `CourseName`= '" + cName + "'"));
            if (table.Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }
        
        public bool updateScore(int stdid,string scn, double scor, string desc)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `score` SET `Score`=@sco,`Description`=@desc WHERE `StudentId`=@stid AND `CourseName`=@scn", connect.GetConnection);
          
            command.Parameters.Add("@scn", MySqlDbType.VarChar).Value = scn;
            command.Parameters.Add("@stid", MySqlDbType.Int32).Value = stdid;
            command.Parameters.Add("@sco", MySqlDbType.Double).Value = scor;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            connect.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseConnection();
                return true;
            }
            else
            {
                connect.CloseConnection();
                return false;
            }
        }
       
        public bool deleteScore(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `score` WHERE `StudentId`=@id", connect.GetConnection);

          
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            connect.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseConnection();
                return true;
            }
            else
            {
                connect.CloseConnection();
                return false;
            }
        }
    }
}
