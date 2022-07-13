using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace projectef.Models
{
    public class Author
    {
        public Guid AuthorId { get; init; }

        public string Name { get; set; }

        public uint Age { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        [JsonIgnore]
        public virtual ICollection<TodoTask> Tasks { get; set; }
    }
}