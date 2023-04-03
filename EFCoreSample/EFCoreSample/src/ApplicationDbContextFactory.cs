using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace EFCoreSample.src
{
    internal class ApplicationDbContextFactory
    {
        private readonly Lazy<IConfiguration> configuration = 
            new Lazy<IConfiguration>(AppConfiguration.GetConfiguration());
        private readonly bool isLogging;

        public ApplicationDbContextFactory(bool isLogging = true) {
            this.isLogging = isLogging;
        }

        public ApplicationDbContext Create()
        {
            var connectionString = configuration.Value.GetConnectionString("Default")
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
