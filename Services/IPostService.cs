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
        Task<ServiceResponse<PostDTO>> Create(Post post);
        Task<ServiceResponse<PostDTO>> Delete(Guid id);
        Task<ServiceResponse<PostDTO>> Update(UpdatePostDTO post,  Guid id);
        Task<ServiceResponse<ICollection<PostDTO>>> GetAllPostByUser (Guid user_id);
        Task<ServiceResponse<PostDTO>> GetPostsById (Guid post_id);
        Task<PostLikes> LikePost(PostLikes liked_post);
        Task<PostLikes> Unlike(PostLikes liked_post);
        Task<List<PostLikes>> GetPostLikes(Guid post_id);
    }
}