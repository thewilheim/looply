using System.Text.Json.Serialization;


namespace looply.Models
{
    public class Follower
    {
        public Guid FollowerId { get; set; }  // ID of the follower (User)
        public Guid FollowedId { get; set; }  // ID of the followed user (User)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Follow_Status Status { get; set; } = Follow_Status.Accepted;


        [JsonIgnore]
        public User? FollowerUser { get; set; }  // The follower (User)
        [JsonIgnore]
        public User? FollowedUser { get; set; }  // The followed user (User)

    }

    public enum Follow_Status
    {
        Accepted,
        Pending,
        Blocked,
        Rejected
    }
}