using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

// Database context configuration
public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<TodoTask> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API
        // Predomina sobre los data notations 
        // debido a que el model builder es ejecutado hasta el final.
        modelBuilder.Entity<Category>(category => {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description);
            category.Property(p => p.Importance);
        });

        modelBuilder.Entity<TodoTask>(task => {
            task.ToTable("Task");
            task.HasKey(t => t.TaskId);

            // Foreign Key
            task.HasOne(t => t.Category) // public virtual Category Category { get; set; }
                .WithMany(c => c.Tasks) // task method
                .HasForeignKey(t => t.CategoryId);
        
            task.Property(t => t.Title).IsRequired().HasMaxLength(200);
        
            task.Property(t => t.Description);

            task.Property(t => t.Priority);

            task.Property(t => t.CreatedAt);
            
            task.Ignore(t => t.Summary);
        });
        
            
    }
}