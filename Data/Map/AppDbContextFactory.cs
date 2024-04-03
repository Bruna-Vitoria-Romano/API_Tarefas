using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace API_Tarefas.Data.Map
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<SistemaTarefasDBContext>
    {
        public SistemaTarefasDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Criando o DbContextOptionsBuilder manualmente
            var builder = new DbContextOptionsBuilder<SistemaTarefasDBContext>();
            // cria a connection string. 
            // requer a connectionstring no appsettings.json
            var connectionString = configuration.GetConnectionString("DataBase");
            builder.UseSqlServer(connectionString);

            // Cria o contexto
            return new SistemaTarefasDBContext(builder.Options);
        }
    }
}
