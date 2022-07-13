using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projectef.Models;

public class Category
{
    // [Key]
    public Guid CategoryId { get; init; }

    // [Required]
    // [MaxLength(150)]
    // [MinLength(20)]
    public string Name { get; set; }

    public string Description { get; set; }

    public int Importance{ get; set; }

    [JsonIgnore]
    public virtual ICollection<TodoTask> Tasks { get; set; }

}