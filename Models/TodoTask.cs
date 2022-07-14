using System.Text.Json.Serialization;

namespace projectef.Models;

public class TodoTask
{
    // [Key]
    public Guid TaskId { get; init; }

    // [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }

    public Guid AuthorId { get; set; }

    public DateTime CreatedAt { get; set; }

    // public TodoTaskBody TodoTaskBody { get; set; }


    // [Required]
    // [MaxLength(200)]
    public string Title { get; set; }

    // [Required]
    public string Description { get; set; }

    // [Required]
    public Priority Priority { get; set; }

    // [Required]
    public bool Completed { get; set; }

    public virtual Author Author { get; set; }

    public virtual Category Category { get; init; }



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