using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using projectef;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

// Adding the context
// Basic EF configuration
// builder.Services.AddDbContext<TasksContext>(opt => opt.UseInMemoryDatabase("TasksDB"));

// Config SQLserver
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("SQLTasksDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();// runs the commands to create the db. 
    return Results.Ok($"DB in memory successfully: {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext ) => {
    return Results.Ok(dbContext.Tasks.Include(p => p.Category).Include(p => p.Author).Where(p => p.Priority == projectef.Models.Priority.Low));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] TodoTask task) => {
    var newTask = new TodoTask();
    newTask.CreatedAt = DateTime.Now;

    await dbContext.AddAsync(newTask);
    // await dbContext.Tasks.AddAsync(newTask);

    await dbContext.SaveChangesAsync();

    return Results.Created("/created", newTask);

});

app.MapGet("/api/categories", async ([FromServices] TasksContext dbContext ) => {
    return Results.Ok(dbContext.Categories);
});

app.MapGet("/api/authors", async ([FromServices] TasksContext dbContext ) => {
    return Results.Ok(dbContext.Authors);
});



app.Run();
