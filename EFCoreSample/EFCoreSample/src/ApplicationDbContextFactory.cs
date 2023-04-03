using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace EFCoreSample.src
{
    internal static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create(bool isLogging = true)
        {
            var configuration = AppConfiguration.GetConfiguration();
            var connectionString = configuration.GetConnectionString("Default")
                ?? throw new NullReferenceException("Cannot get connection string");

            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(connectionString);

            StreamWriter? logStream = null;
            if (isLogging)
            {
                logStream = new StreamWriter("efcore.log", true);
                optionsBuilder.LogTo(logStream.WriteLine, new[] { RelationalEventId.CommandExecuted });
            }

            return new ApplicationDbContext(optionsBuilder.Options, logStream);
        }

    }
}
