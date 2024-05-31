using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Infrastructure.Data
{
    public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            // Configurar el DbContext para tiempo de diseño
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

            // Obtener el path base del proyecto de inicio (Diaspora.Api)
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\Diaspora.Api"));

            // Obtener la configuración desde appsettings.json y el entorno actual
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DiasporaDatabase");
            var databaseVersion = configuration["DatabaseVersion"];

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(databaseVersion));

            return new DBContext(optionsBuilder.Options);
        }
    }
}
