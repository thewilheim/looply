using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using looply.Data;
using looply.DTO;
using looply.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace looply.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public PostService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<PostDTO> Create(Post post)
        {
            if(post != null)
            {
                await _appDbContext.Posts.AddAsync(post);
                await _appDbContext.SaveChangesAsync();

                return _mapper.Map<PostDTO>(post);
            }

            return null;
        }

        public async Task<PostDTO> Delete(Guid id)
        {
            if(id == Guid.Empty) return null;

            var post = _appDbContext.Posts.FirstOrDefault(p => p.Id == id);

            if(post != null)
            {
                _appDbContext.Posts.Remove(post);
                await _appDbContext.SaveChangesAsync();
                return _mapper.Map<PostDTO>(post);
            }

            return null;
        }

        public async Task<ICollection<PostDTO>> GetAllPostByUser(Guid user_id)
        {
            if(user_id == Guid.Empty) return null;

            var posts = await _appDbContext.Posts.Where(posts => posts.User_id == user_id).ToListAsync();

            if(posts != null)
            {
                return _mapper.Map<ICollection<PostDTO>>(posts);
            }

            return [];
        }

        public async Task<PostDTO> GetPostsById(Guid post_id)
        {

            if(post_id == Guid.Empty) return null;

            var post = await _appDbContext.Posts.Include(c => c.Comments).Include(l => l.Likes).FirstOrDefaultAsync(p => p.Id == post_id);

            if(post != null)
            {
                return _mapper.Map<PostDTO>(post);
            }

            return null;
        }

        public async Task<PostDTO> Update(UpdatePostDTO post, Guid id)
        {
            var exsitingPost = await _appDbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
            if(exsitingPost == null) return null;
            exsitingPost.Privacy = post.Privacy;
            exsitingPost.Description = post.Description;
            exsitingPost.Title = post.Title;

            await _appDbContext.SaveChangesAsync();

                return _mapper.Map<PostDTO>(exsitingPost);
        }

        public async Task<PostLikes> LikePost(PostLikes liked_post)
        {
            
            if(liked_post == null) return null;

            var post = await _appDbContext.PostLikes.FirstOrDefaultAsync(u => u.User_id == liked_post.User_id && u.Post_id == liked_post.Post_id);

            if(post == null){
                await _appDbContext.PostLikes.AddAsync(liked_post);
                await _appDbContext.SaveChangesAsync();
                return liked_post;
            } else {
                post.Type = liked_post.Type;
                await _appDbContext.SaveChangesAsync();
                return liked_post;
            }
        }

        public async Task<PostLikes> Unlike(PostLikes liked_post)
        {
            var post = await _appDbContext.PostLikes.FirstOrDefaultAsync(u => u.User_id == liked_post.User_id && u.Post_id == liked_post.Post_id);

            if(post == null) return null;
            _appDbContext.PostLikes.Remove(post);
            await _appDbContext.SaveChangesAsync();
            return post;
        }

        public async Task<List<PostLikes>> GetPostLikes(Guid post_id)
        {
            var likes = await _appDbContext.PostLikes.Where(u => u.Post_id == post_id).ToListAsync();

            if(likes == null || post_id == Guid.Empty) return null;

            return likes;
        }
    }
}