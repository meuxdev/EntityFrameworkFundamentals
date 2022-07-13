using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

// Database context configuration
public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<TodoTask> Tasks { get; set; }

    public DbSet<Author> Authors { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API
        // Predomina sobre los data notations 
        // debido a que el model builder es ejecutado hasta el final.


        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category()
        {
            CategoryId = Guid.Parse("5f617470-bf19-4be4-9fea-f26a18bf616a"),
            Name = "Pending Activities",
            Importance = 20,
            Description = "This is a random category creating for testing the db"
        });
        categoriesInit.Add(new Category()
        {
            CategoryId = Guid.Parse("5f617470-bf20-4be4-9fea-f26a18bf616a"),
            Name = "Studying the new formulas",
            Importance = 50,
            Description = "This is a random category creating for testing the db"
        });

        var tasksInit = new List<TodoTask>();

        tasksInit.Add(new TodoTask()
        {
            TaskId = Guid.Parse("b4c54026-ec34-439d-bb61-b3e4c1cb3399"),
            CategoryId = Guid.Parse("5f617470-bf19-4be4-9fea-f26a18bf616a"),
            Priority = Priority.High,
            Title = "Review the payment for the school.",
            Description = "This is a random Task to do, this is just some random description",
            CreatedAt = DateTime.Now,
            Completed = false,
            AuthorId = Guid.Parse("5e48e5cd-0850-48f2-9b3b-572f82f0ba91")
        });


        tasksInit.Add(new TodoTask()
        {
            TaskId = Guid.Parse("b4c54026-ec34-439d-bb61-b3e4c1cb4499"),
            CategoryId = Guid.Parse("5f617470-bf20-4be4-9fea-f26a18bf616a"),
            AuthorId = Guid.Parse("656fe592-6dd1-4108-b492-c014f1faefdc"),
            Priority = Priority.Low,
            Title = "Finish Stranger things Season 4",
            Description = "This is a random Task to do, this is just some random description",
            CreatedAt = DateTime.Now,
            Completed = false
        });

        var authorsInit = new List<Author>();
        authorsInit.Add(new Author()
        {
            Name = "Alejandro",
            Age = 24,
            AuthorId = Guid.Parse("5e48e5cd-0850-48f2-9b3b-572f82f0ba91"),
            Height = 1.75f,
            Weight = 80.2f
        });
        authorsInit.Add(new Author()
        {
            Name = "Josh",
            Age = 40,
            AuthorId = Guid.Parse("656fe592-6dd1-4108-b492-c014f1faefdc"),
            Height = 1.80f,
            Weight = 95.3f
        });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description);
            category.Property(p => p.Importance);

            category.HasData(categoriesInit);
        });

        modelBuilder.Entity<TodoTask>(task =>
        {
            task.ToTable("Task");
            task.HasKey(t => t.TaskId);

            // Foreign Key
            task.HasOne(t => t.Category) // public virtual Category Category { get; set; }
                .WithMany(c => c.Tasks) // task method
                .HasForeignKey(t => t.CategoryId);

            task.HasOne(t => t.Author)
                .WithMany(a => a.Tasks)
                .HasForeignKey(t => t.AuthorId);

            task.Property(t => t.Title).IsRequired().HasMaxLength(200);

            task.Property(t => t.Description);

            task.Property(t => t.Priority);

            task.Property(t => t.CreatedAt);

            task.Property(t => t.Completed);

            task.Ignore(t => t.Summary);

            task.HasData(tasksInit);
        });


        modelBuilder.Entity<Author>(author =>
        {
            author.ToTable("Author");
            author.HasKey(a => a.AuthorId);
            author.Property(a => a.Age).HasMaxLength(120);
            author.Property(a => a.Weight).HasMaxLength(200);
            author.Property(a => a.Weight).HasMaxLength(2);
            author.Property(a => a.Name).IsRequired();

            author.HasData(authorsInit);

        });

    }
}