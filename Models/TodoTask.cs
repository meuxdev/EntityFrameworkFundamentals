using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projectef.Models;

public class TodoTask
{
    // [Key]
    public Guid TaskId { get; init; }

    // [ForeignKey("CategoryId")]
    public Guid CategoryId { get; init; }
    public Guid AuthorId { get; init; }

    // [Required]
    // [MaxLength(200)]
    public string Title { get; set; }

    public string Description { get; set; }

    public Priority Priority { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Category Category { get; set; }

    public virtual Author Author { get; set; }

    public bool Completed { get; set; }


    // [NotMapped] // does not add this column to the table -> no mapping the attribute
    [JsonIgnore]
    public string Summary { get; set; }
}


public enum Priority
{
    Low,
    Medium,
    High
}