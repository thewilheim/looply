using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace looply.Models
{
    public class PostTag
    {
        public Guid Tag_id { get; set; }
        public Guid Post_id { get; set; }

        public required Post Post { get; set; }
        public required Tag Tag { get; set; }
    }
}