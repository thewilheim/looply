using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using looply.Models;

namespace looply.Services
{
    public interface ICommentService
    {
        public Task<Comment> Create(Comment comment);
        public Task<List<Comment>> GetCommentsByPostId(Guid post_id);
        public Task<CommentLikes> Like (CommentLikes liked_comment);
        public Task<Comment> Delete(Guid comment_id);
        public Task<CommentLikes> Unlike(CommentLikes liked_comment);
        public Task<List<CommentLikes>> GetLikesByCommentId (Guid comment_id);

        public Task<List<Comment>> GetRepliesByCommentId (Guid comment_id);
    }
}