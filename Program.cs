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

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext ) => {
    return Results.Ok(dbContext.Tasks.Include(p => p.Category).Include(p => p.Author).Where(p => p.Priority == projectef.Models.Priority.Low));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] TodoTask task) => {
    

    await dbContext.AddAsync(task);
    // await dbContext.Tasks.AddAsync(newTask);

    await dbContext.SaveChangesAsync();

    return Results.Created("/created", task);

});

app.MapGet("/api/categories", async ([FromServices] TasksContext dbContext ) => {
    return Results.Ok(dbContext.Categories);
});

app.MapGet("/api/authors", async ([FromServices] TasksContext dbContext ) => {
    return Results.Ok(dbContext.Authors);
});



app.Run();
