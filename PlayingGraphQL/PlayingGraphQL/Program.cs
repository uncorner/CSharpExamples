using Microsoft.EntityFrameworkCore;
using PlayingGraphQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookDbContext>(options => 
    options.UseInMemoryDatabase(databaseName: "Books" ));
builder.AddGraphQL().AddQueryType<Query>().AddMutationType<Mutation>();

var app = builder.Build();
// добавить в конвейер
app.MapGraphQL("/graphql");

app.Run();
