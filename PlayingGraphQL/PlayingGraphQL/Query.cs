using Microsoft.EntityFrameworkCore;

namespace PlayingGraphQL;

public class Query
{
    [GraphQLNonNullType]
    public List<Book> GetBooks ([Service] BookDbContext dbContext) =>
        dbContext.Books.Include(x => x.Author).ToList(); 
    
    // По соглашению GetBook() будет объявлен как book() в типе запроса.
    public Book GetBook([Service] BookDbContext dbContext, int id) =>
        dbContext.Books.FirstOrDefault(x => x.Id == id);
}
