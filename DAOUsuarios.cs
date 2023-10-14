using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using Clase6_Dependencias.Interfaces; // Asegúrate de importar el espacio de nombres de la interfaz.

namespace Clase6_Dependencias.DataAcces
{
    public class DAOUsuario : IDataUsuario // Implementa la interfaz.
    {
        private readonly string connectionString;

        public DAOUsuario(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Usuario> ObtenerListaDeUsuarios()
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                string consulta = "SELECT Id_user, Nombre_user, Edad_user FROM Usuarios";
                List<Usuario> usuarios = dbConnection.Query<Usuario>(consulta).AsList();
                return usuarios;
            }
        }
    }
}
