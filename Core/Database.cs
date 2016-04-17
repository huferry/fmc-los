using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Los.Core
{
    public class DatabaseSettings
    {
        static internal DatabaseSettings current = new DatabaseSettings();

        public string Host = "localhost";
        public string User = "";
        public string Password = "";
        public string Database = "";

        static public void SetSettings(DatabaseSettings settings)
        {
            current = settings;
        }

        static public string GetHost()
        {
            return current.Host;
        }

        static public string GetDatabase()
        {
            return current.Database;
        }
    }

    public class Database
    {
        private MySqlConnection connection;
        private string host = "";
        private string user =  ""; 
        private string passwoord = "";
        private string database = "";

        private Database()
        {
            host = DatabaseSettings.current.Host;
            user = DatabaseSettings.current.User;
            passwoord = DatabaseSettings.current.Password;
            database = DatabaseSettings.current.Database;

            connection = new MySqlConnection(
                            string.Format("Database={0};Data Source={1}; User Id={2}; password={3}", database, host, user, passwoord));
            try
            {
                connection.Open();
            }
            catch
            {
                //
            }
        }

        static private Database instance = new Database();

        static public IEnumerable<DataRow> Select(string cmd)
        {
            var table = new DataTable();
            var adapter = new MySqlDataAdapter(cmd, instance.connection);            
            adapter.Fill(table);            
            return table.Rows.Cast<DataRow>();
        }

        static public int Execute(string command, IEnumerable<DbParameter> parameters)
        {
            var cmd = new MySqlCommand(command, instance.connection);
            if (parameters != null)
            {
                foreach (MySqlParameter p in parameters.Cast<MySqlParameter>())
                    cmd.Parameters.Add(p);
            }
            return cmd.ExecuteNonQuery();
        }

        static public DbParameter CreateParameter(string name, object value)
        {
            return new MySqlParameter(name, value);
        }

        static public bool Check()
        {
            try
            {
                var conn = instance.connection;
                return (conn.State == ConnectionState.Open); 
            }
            catch
            {
                return false;
            }
        }

    }
}
