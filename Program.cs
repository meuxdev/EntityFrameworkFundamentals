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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
        // options.SerializeAsV2 = true;
    });
}



app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();// runs the commands to create the db. 
    return Results.Ok($"DB in memory successfully: {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/tasks/low", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(p => p.Category).Include(p => p.Author).Where(p => p.Priority == Priority.Low));

});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(p => p.Category).Include(p => p.Author));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] TodoTask task) =>
{
    await dbContext.AddAsync(task);
    // await dbContext.Tasks.AddAsync(newTask);
    await dbContext.SaveChangesAsync();
    return Results.Created("/created", task);
});

app.MapPut("api/tasks/{id}", async (
    [FromServices] TasksContext dbContext,
    [FromBody] TodoTask task,
    [FromRoute] Guid id
) =>
{
    // Default looks for the key
    var currentTask = dbContext.Tasks.Find(id);

    if (currentTask != null)
    {
        currentTask.CategoryId = task.CategoryId;
        currentTask.AuthorId = task.AuthorId;
        currentTask.Title = task.Title;
        currentTask.Priority = task.Priority;
        currentTask.Description = task.Description;
        currentTask.Completed = task.Completed;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("api/tasks/{id}", async (
    [FromServices] TasksContext dbContext,
    [FromRoute] Guid id
) => 
{
    TodoTask currentTask = dbContext.Tasks.Find(id);

    if(currentTask != null)
    {
        dbContext.Remove(currentTask);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapGet("/api/categories", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Categories);
});

app.MapGet("/api/authors", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Authors);
});



app.Run();
