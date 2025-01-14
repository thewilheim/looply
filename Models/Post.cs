using System.ComponentModel.DataAnnotations;

namespace looply.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Description { get; set; }
        public required string Url { get; set; }
        public string? Thumbnail_url { get; set; }
        public Privacy_Type Privacy { get; set; } = Privacy_Type.Public;
        public long Views { get; set; } = 0;
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<PostLikes>? Likes { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Favourite>? Favourites { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
    public enum Privacy_Type
    {
        Public,
        Private,
        Friends
    }
}