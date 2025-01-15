using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using looply.DTO;
using looply.Models;

namespace looply.Services
{
    public interface IPostService
    {
        Task<Post> Create(Post post);
        Task<Post> Delete(Guid id);
        Task<Post> Update(UpdatePostDTO post,  Guid id);
        Task<ICollection<Post>> GetAllByUser (Guid user_id);
        Task<Post> GetByPostId (Guid post_id);
        Task<PostLikes> LikePost(PostLikes liked_post);
        Task<PostLikes> Unlike(PostLikes liked_post);
    }
}