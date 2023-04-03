using EFCoreSample.src;

internal class Program
{

    private static void Main(string[] args)
    {
        using (var dbContext = ApplicationDbContextFactory.Create())
        {
            var users = dbContext.Users.ToList();
            dbContext.Users.RemoveRange(users);
            dbContext.SaveChanges();
        }

        using (var dbContext = ApplicationDbContextFactory.Create())
        {
            var user1 = new User { Name = "Tom", Age = 33, Hobby = "TV shows" };
            var user2 = new User { Name = "Alice", Age = 26, Hobby = "fishing" };

            dbContext.Users.AddRange(user1, user2);
            dbContext.SaveChanges();
        }

        using (var dbContext = ApplicationDbContextFactory.Create())
        {
            var users = dbContext.Users.ToList();
            Console.WriteLine("Users list:");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}.{user.Name} - {user.Age} - {user.Hobby}");
            }
        }
    }
 
}