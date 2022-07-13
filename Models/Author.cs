using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual ICollection<TodoTask> Tasks { get; set; }
    }
}