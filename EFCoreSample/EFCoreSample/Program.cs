using EFCoreSample.src;

internal class Program
{

    private static void Main(string[] args)
    {
        using (var dbContext = CreateAppDbContext())
        {
            var users = dbContext.Users.ToList();
            dbContext.Users.RemoveRange(users);
            dbContext.SaveChanges();
        }

        using (var dbContext = CreateAppDbContext())
        {
            var user1 = new User { Name = "Tom", Age = 33 };
            var user2 = new User { Name = "Alice", Age = 26 };

            dbContext.Users.AddRange(user1, user2);
            dbContext.SaveChanges();
        }

        using (var dbContext = CreateAppDbContext())
        {
            var users = dbContext.Users.ToList();
            Console.WriteLine("Users list:");
            foreach (User u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
        }
    }

    private static AppDbContext CreateAppDbContext() => new(true);


}