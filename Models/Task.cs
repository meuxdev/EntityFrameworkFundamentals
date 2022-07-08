
namespace projectef.Models;

public class Task
{
    public Guid TaskId { get; init; }

    public Guid CategoryId { get; private set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority Priority { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Category Category { get; set; }
}


public enum Priority
{
    Low,
    Medium,
    High
}