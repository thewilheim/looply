using System.ComponentModel.DataAnnotations;

namespace looply.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public required string Content { get; set; }
        public Guid Parent_comment_id { get; set; }
        public Comment_Status Status { get; set; } = Comment_Status.Active;

        public Guid Post_id { get; set; }
        public Guid User_id { get; set; }

        public required Post Post { get; set; }

        public ICollection<CommentLikes>? Likes { get; set; }
        public required User User { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public enum Comment_Status
    {
        Active,
        Deleted,
        Flagged
    }

}