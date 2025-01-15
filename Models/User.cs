using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace looply.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public required string Username { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? Profile_picture_url { get; set; }
        public Privacy_Type Privacy { get; set; } = Privacy_Type.Public;
        public bool IsVerified { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        // Navigation properties
        public ICollection<Post>? Posts { get; set; } = [];
        public ICollection<Follower>? Followers { get; set; } = [];
        public ICollection<Follower>? Following { get; set; } = [];

        public ICollection<CommentLikes> Comment_Likes { get; set; } = [];
        public ICollection<PostLikes> Post_Likes { get; set; } = [];

        public ICollection<Comment> Comments {get; set;} = [];

    }
}