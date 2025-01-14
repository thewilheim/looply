using System.ComponentModel.DataAnnotations;

namespace looply.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid User_id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public required string Url { get; set; } = string.Empty;
        public string? Thumbnail_url { get; set; }
        public Privacy_Type Privacy { get; set; } = Privacy_Type.Public;
        public long Views { get; set; } = 0;
        public Current_Status Status { get; set; } = Current_Status.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;




        public ICollection<PostLikes>? Likes { get; set; } = [];
        public ICollection<Comment>? Comments { get; set; } = [];
        public ICollection<PostTag> PostTags { get; set; } = [];
    }
    public enum Privacy_Type
    {
        Public,
        Private,
        Friends
    }
}