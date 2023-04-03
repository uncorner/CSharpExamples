using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreSample.src
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            ApplicationDbContextFactory dbContextFactory = new(false);
            return dbContextFactory.Create();
        }

    }
}
