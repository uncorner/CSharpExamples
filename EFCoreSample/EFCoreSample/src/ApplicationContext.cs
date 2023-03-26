using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.src
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreSample;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EFCoreSample;Trusted_Connection=True;TrustServerCertificate=true;");
        }

    }
}
