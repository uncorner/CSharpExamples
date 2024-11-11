using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PlayingGraphQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookDbContext>(options => 
    options.UseInMemoryDatabase(databaseName: "Books" ));
//builder.Services.AddGraphQL(
//   SchemaBuilder.New().AddQueryType<Query>().AddMutationType<Mutation>().Create());

builder.AddGraphQL().AddQueryType<Query>().AddMutationType<Mutation>();

var app = builder.Build();
//app.MapGet("/", () => "Hello World!");
// добавить в конвейер
app.MapGraphQL("/graphql");

// app.RunWithGraphQLCommands(args)
app.Run();
