using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

// Database context configuration
public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<TodoTask> Tasks { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
}