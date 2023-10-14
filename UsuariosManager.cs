using Clase6_Dependencias.DataAccess;
using Clase6_Dependencias.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clase6_Dependencias
{
    public class UsuariosManager
    {
        private readonly IDataUsuario _dataUsuario;
        private readonly DatabaseContext _dbContext;

        public UsuariosManager(IDataUsuario dataUsuario, DatabaseContext dbContex)
        {
            _dataUsuario = dataUsuario;
            _dbContext = dbContex;
        }

        //public string ObtenerListadoDeUsuarios()
        //{
        //    // Obtener la lista de usuarios desde el DAO
        //    List<Usuario> usuarios = _dataUsuario.ObtenerListaDeUsuario();

        //    // Ordenar la lista de usuarios por edad
        //    List<Usuario> usuariosOrdenados = usuarios.OrderBy(u => u.Edad_user).ToList();

        //    // Extraer los nombres de los usuarios
        //    List<string> nombresUsuarios = usuariosOrdenados.Select(u => u.Nombre_user).ToList();

        //    // Combinar los nombres en un solo string separado por comas
        //    string resultado = string.Join(",", nombresUsuarios);

        //    return resultado;
        //}
        public string ObtenerListadoDeUsuarios()
        {
            string consulta = "SELECT User_Nombre FROM usuarios ORDER BY User_Edad";
            var usuarios = _dbContext.Query<string>(consulta); // Esto asume que el campo User_Nombre es de tipo string en la base de datos.

            // Formatear los nombres de usuario separados por coma
            string listado = string.Join(",", usuarios);

            return listado;
        }


    }
}

