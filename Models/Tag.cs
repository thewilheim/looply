using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace looply.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public required string Name { get; set; } = string.Empty;


        public ICollection<PostTag> PostTags { get; set; } = [];
    }
}