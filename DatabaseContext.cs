using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Clase6_Dependencias.DataAccess
{
    public class DatabaseContext
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new MySqlConnection(_connectionString);
                    _connection.Open();
                }
                else if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public List<T> Query<T>(string sql, object parameters = null)
        {
            return Connection.Query<T>(sql, parameters).AsList();
        }

        public T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            return Connection.QueryFirstOrDefault<T>(sql, parameters);
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
