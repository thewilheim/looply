using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace looply.DTO
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public Guid User_id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public required string Url { get; set; }
        public string? Thumbnail_url { get; set; }
        public int Privacy { get; set; }
        public long Views { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Number_Of_Comments { get; set; }
        public int Number_Of_Likes { get; set; }
    }
}