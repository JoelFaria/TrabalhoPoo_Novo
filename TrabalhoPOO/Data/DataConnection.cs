using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TrabalhoPOO.Data
{
    public sealed class DataConnection
    {
        private static DataConnection _instance;
        private static readonly object _lock = new object();
        private SqlConnection _connection;

        private readonly string _connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private DataConnection()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public static DataConnection Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (_lock)
                    {
                        if(_instance == null)
                        {
                            _instance = new DataConnection();
                        }
                    }
                }
                return _instance;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public void Open()
        {
            if(_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void Close() 
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }
    }
}
