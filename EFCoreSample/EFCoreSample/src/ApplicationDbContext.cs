using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace EFCoreSample.src
{
    internal class ApplicationDbContext : DbContext
    {
        private readonly StreamWriter? logStream;
        private readonly string connectionString;

        internal DbSet<User> Users { get; set; } = null!;
        //public DbSet<User> Users => Set<User>();

        public ApplicationDbContext() : this(false)
        {
        }

        public ApplicationDbContext(bool isLogging, string? connectionString = null)
        {
            if (connectionString is not null)
            {
                this.connectionString = connectionString;
            }
            else
            {
                var configuration = AppConfiguration.GetConfiguration();
                this.connectionString = configuration.GetConnectionString("Default") ?? throw new NullReferenceException("Cannot get connection string");
            }

            if (isLogging)
            {
                logStream = new("efcore.log", true);
            }
            
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            if (logStream is not null)
            {
                optionsBuilder.LogTo(logStream.WriteLine, new [] { RelationalEventId.CommandExecuted });
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            logStream?.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            if (logStream is not null)
            {
                await logStream.DisposeAsync();
            }
        }

    }
}
