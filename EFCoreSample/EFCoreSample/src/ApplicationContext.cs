using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.src
{
    internal class ApplicationContext : DbContext
    {
        private string? connectionString;

        public DbSet<User> Users { get; set; } = null!;
        //public DbSet<User> Users => Set<User>();

        public ApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
