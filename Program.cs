using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using projectef;

var builder = WebApplication.CreateBuilder(args);

// Adding the context
// Basic EF configuration
// builder.Services.AddDbContext<TasksContext>(opt => opt.UseInMemoryDatabase("TasksDB"));

// Config SQLserver
builder.Services.AddSqlServer<TasksContext>("Data Source=DESKTOP-ATPRFEE; Initial Catalog=TasksDB;user id=meuxdev;password=meuxdev;");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"DB in memory successfully: {dbContext.Database.IsInMemory()}");
});

app.Run();
