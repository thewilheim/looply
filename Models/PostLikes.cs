namespace looply.Models
{
    public class PostLikes
    {
        public Guid Post_id { get; set; }
        public Like_type Type { get; set; } = Like_type.Like;
        public Guid User_id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public required Post Post { get; set; }
        public required User User { get; set; }
    }

}