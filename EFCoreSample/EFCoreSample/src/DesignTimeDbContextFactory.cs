using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreSample.src
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args) =>
            ApplicationDbContextFactory.Create(false);

    }
}
