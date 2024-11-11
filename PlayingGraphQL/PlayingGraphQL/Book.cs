namespace PlayingGraphQL;

public class Book
{
    public int Id { get; set; }

    [GraphQLNonNullType]
    public string Title { get; set; } = null!;
    
    public int Pages { get; set; }
    
    public int Chapters { get; set; }

    [GraphQLNonNullType] 
    public Author Author { get; set; } = null!;
}
