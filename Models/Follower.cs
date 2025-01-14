using System.Text.Json.Serialization;


namespace looply.Models
{
    public class Follower
    {
        public Guid FollowerId { get; set; }  // ID of the follower (User)
        [JsonIgnore]
        public User? FollowerUser { get; set; }  // The follower (User)
        public Guid FollowedId { get; set; }  // ID of the followed user (User)
        [JsonIgnore]
        public User? FollowedUser { get; set; }  // The followed user (User)

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        public Follow_Status Status { get; set; } = Follow_Status.Accepted;

    }

    public enum Follow_Status
    {
        Accepted,
        Pending,
        Blocked,
        Rejected
    }
}