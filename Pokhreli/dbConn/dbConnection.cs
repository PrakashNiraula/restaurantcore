using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pokhreli.dbConn
{
    public class dbConnection
    {
        MySqlConnection conn;
        public dbConnection()
        {
           conn = new MySqlConnection("server = 140.238.204.76; user id= root; password =aefa8991baba5c1e; database = hms; persistsecurityinfo = False;");
          // conn = new MySqlConnection("server = localhost; user id= root; password =; database = hms; persistsecurityinfo = False;");
        }
        public DataTable GetDataTable(string query)
        {

            DataTable dt;
            MySqlDataReader dr;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                cmd.Connection = conn;
                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(dataReader);
                dataReader.Close();
                return dataTable;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }

        }
        public int ExecuteQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {

                cmd.Connection = conn;
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }
        public string ExecuteScalar(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {

                cmd.Connection = conn;
                cmd.Connection.Open();
                return Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                return "0";
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }
        }

    }
}
