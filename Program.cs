using Autofac;
using Clase6_Dependencias;
using Clase6_Dependencias.Interfaces;
using System;

//-> crear una clase "UsuariosManager"
//-> esta clase debe tener un método "pubic string ObtenerListadoDeUsuarios", el cual debe devolver un listado de los nombres de los usuarios, ordenado por Edad,
//separado por coma, ejemplo: "jorge,natalia,jose,julieta"
//->la clase "UsuariosManager" debe utilizar el DAO programado en el ejercicio anterior
//-> la clase "UsuariosManager" debe tener inyección de dependencia sobre este DAO
//-> la inyección de dependencias debe estar programada utilizando un contenedor, como ninject o autofac.

public class Program
{
    private static IContainer Container { get; set; }

    static void Main(string[] args)
    {
        // Configurar el contenedor
        Container = ContainerConfig.Configure();

        // Ejemplo de cómo usar una dependencia resuelta del contenedor
        using (var scope = Container.BeginLifetimeScope())
        {
            var usuariosManager = scope.Resolve<UsuariosManager>();
            string listadoDeUsuarios = usuariosManager.ObtenerListadoDeUsuarios();

            // Mostrar el resultado en la consola
            Console.WriteLine("Listado de Usuarios: " + listadoDeUsuarios);
        }
    }
}

