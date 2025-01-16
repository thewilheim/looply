using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using looply.Data;
using looply.Models;
using Microsoft.EntityFrameworkCore;

namespace looply.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _appDbContext;

        public CommentService(AppDbContext appContext)
        {
            _appDbContext = appContext;
        }
        public async Task<Comment> Create(Comment comment)
        {
            if(comment == null) return null;

            await _appDbContext.Comments.AddAsync(comment);
            await _appDbContext.SaveChangesAsync();

            return comment;
        }

        public async Task<Comment> Delete(Guid comment_id)
        {
            if(comment_id == Guid.Empty) return null;

            var comment = await _appDbContext.Comments.FirstOrDefaultAsync(c => c.Id == comment_id);
            
            if(comment != null){
            _appDbContext.Comments.Remove(comment);
            await _appDbContext.SaveChangesAsync();
            return comment;
            }

            return null;

        }

        public async Task<List<Comment>> GetCommentsByPostId(Guid post_id)
        {
            if(post_id == Guid.Empty) return null;

            var comments = await _appDbContext.Comments.Where(c => c.Post_id == post_id).Include(u => u.Replies).Include(u => u.Likes).ToListAsync();

            if(comments!= null){
                return comments;
            }

            return null;
        }

        public async Task<CommentLikes> Like(CommentLikes liked_comment)
        {
            if(liked_comment == null) return null;

            var comment = await _appDbContext.CommentLikes.FirstOrDefaultAsync(u => u.User_id == liked_comment.User_id && u.Comment_id == liked_comment.Comment_id);

            if(comment == null){
                await _appDbContext.CommentLikes.AddAsync(liked_comment);
                await _appDbContext.SaveChangesAsync();
                return liked_comment;
            } else {
                comment.type = liked_comment.type;
                await _appDbContext.SaveChangesAsync();
                return liked_comment;
            }
        }

        public async Task<CommentLikes> Unlike(CommentLikes liked_comment)
        {
            var comment = await _appDbContext.CommentLikes.FirstOrDefaultAsync(u => u.User_id == liked_comment.User_id && u.Comment_id == liked_comment.Comment_id);

            if(comment == null) return null;

            _appDbContext.CommentLikes.Remove(comment);
            await _appDbContext.SaveChangesAsync();
            return comment;
        }
    }
}