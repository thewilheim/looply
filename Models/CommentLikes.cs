using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace looply.Models
{
    public class CommentLikes
    {
        public Guid Comment_id { get; set; }
        public Guid User_id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Like_type type { get; set; } = Like_type.Like;

        
        public required User User { get; set; }
        public required Comment Comment { get; set; }
    }
    public enum Like_type
    {
        Like,
        Dislike
    }

}