using EFCoreSample.src;
using Microsoft.Extensions.Configuration;


internal class Program
{
    private static IConfiguration configuration = null!;

    private static void Main(string[] args)
    {
        configuration = GetAppSettingsFile();
        var connString = configuration.GetConnectionString("Default");
        if (connString is null)
        {
            throw new NullReferenceException("Default connection string is empty");
        }

        using (ApplicationContext db = new(connString))
        {
            var user1 = new User { Name = "Tom", Age = 33 };
            var user2 = new User { Name = "Alice", Age = 26 };

            db.Users.AddRange(user1, user2);
            db.SaveChanges();
        }

        using (ApplicationContext db = new(connString))
        {
            var users = db.Users.ToList();
            Console.WriteLine("Users list:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
        }
    }

    private static IConfiguration GetAppSettingsFile()
    {
        var builder = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        return builder.Build();
    }
}