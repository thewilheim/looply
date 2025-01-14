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
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Bio { get; set; } = "";
        public string? Profile_picture_url { get; set; }
        public Privacy_Type Privacy { get; set; } = Privacy_Type.Public;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<PostLikes>? PostLikes { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<CommentLikes>? CommentLikes { get; set; }
        public ICollection<Favourite>? Favourites { get; set; }
        public ICollection<Follower>? Followers { get; set; }
        public ICollection<Follower>? Following { get; set; }

    }
}