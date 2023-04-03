using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.src
{
    internal class ApplicationDbContext : DbContext
    {
        private readonly StreamWriter? logStream;
        
        public DbSet<User> Users { get; set; } = null!;
        //public DbSet<User> Users => Set<User>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            StreamWriter? logStream) : base(options)
        {
            this.logStream = logStream;
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
