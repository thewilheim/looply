using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace looply.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public required string Content { get; set; } = string.Empty;
        public Guid? Parent_comment_id { get; set; }
        public Current_Status Status { get; set; } = Current_Status.Active;

        public Guid Post_id { get; set; }
        public Guid User_id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        [JsonIgnore]
        public Post? Post { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public Comment? ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; } = [];
        public ICollection<CommentLikes> Likes { get; set; } = [];

    }

    public enum Current_Status
    {
        Active,
        Deleted,
        Flagged
    }

}