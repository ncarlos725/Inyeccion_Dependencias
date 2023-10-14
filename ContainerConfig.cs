using Autofac;
using Clase6_Dependencias;
using Clase6_Dependencias.DataAcces;
using Clase6_Dependencias.DataAccess;
using Clase6_Dependencias.Interfaces;

public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        // Registrar la implementación de DAOUsuarios para la interfaz IDataUsuario
        builder.RegisterType<DAOUsuario>().As<IDataUsuario>();


        // Registrar la implementación de UsuariosManager
        builder.RegisterType<UsuariosManager>();

        // Registrar la implementación de DatabaseContext con la cadena de conexión
        builder.Register(c => new DatabaseContext("Server=localhost;Database=extrados;Uid=root;Pwd=alanMandy94$;"))
               .As<DatabaseContext>()
               .InstancePerLifetimeScope();

        // ...otros registros que puedas tener

        builder.RegisterType<DAOUsuario>()
        .As<IDataUsuario>()
        .WithParameter("connectionString", "Server=localhost;Database=extrados;Uid=root;Pwd=alanMandy94$;");

        return builder.Build();
    }
}
