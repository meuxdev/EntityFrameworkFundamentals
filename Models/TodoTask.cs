using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectef.Models;

public class TodoTask
{
    // [Key]
    public Guid TaskId { get; init; }

    // [ForeignKey("CategoryId")]
    public Guid CategoryId { get; private set; }

    // [Required]
    // [MaxLength(200)]
    public string Title { get; set; }

    public string Description { get; set; }

    public Priority Priority { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Category Category { get; set; }

    // [NotMapped] // does not add this column to the table -> no mapping the attribute
    public string Summary { get; set; }
}


public enum Priority
{
    Low,
    Medium,
    High
}