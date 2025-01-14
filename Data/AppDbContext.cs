using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using looply.Models;

namespace looply.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public required DbSet<User> Users { get; set; }
        public required DbSet<Post> Posts { get; set; }
        public required DbSet<Follower> Follows { get; set; }
        public required DbSet<Comment> Comments { get; set; }
        public required DbSet<PostLikes> PostLikes { get; set; }
        public required DbSet<CommentLikes> CommentLikes { get; set; }
        public required DbSet<PostTag> PostTags { get; set; }
        public required DbSet<Tag> Tags { get; set; }

        // Main configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurePost(modelBuilder);
            ConfigureFollows(modelBuilder);
            ConfigureComment(modelBuilder);
            ConfigurePostLikes(modelBuilder);
            ConfigureCommentLikes(modelBuilder);
            ConfigurePostTag(modelBuilder);

        }
        private void ConfigurePostTag(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(pt => new { pt.Post_id, pt.Tag_id });
                entity.HasOne(pt => pt.Post)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(pt => pt.Post_id);
                entity.HasOne(pt => pt.Tag)
                    .WithMany(t => t.PostTags)
                    .HasForeignKey(pt => pt.Tag_id);
            });
        }

        private void ConfigureCommentLikes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentLikes>(entity =>
                {
                    entity.HasKey(cl => new { cl.Comment_id, cl.User_id });
                    entity.HasOne(cl => cl.Comment)
                        .WithMany(c => c.Likes)
                        .HasForeignKey(cl => cl.Comment_id)
                        .OnDelete(DeleteBehavior.Cascade);
                    entity.HasOne(cl => cl.User)
                        .WithMany()
                        .HasForeignKey(cl => cl.User_id)
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }

        private void ConfigurePostLikes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostLikes>(entity =>
            {
                entity.HasKey(pl => new { pl.Post_id, pl.User_id });
                entity.HasOne(pl => pl.Post)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(pl => pl.Post_id)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(pl => pl.User)
                    .WithMany()
                    .HasForeignKey(pl => pl.User_id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureComment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(c => c.Post)
                      .WithMany(p => p.Comments)
                      .HasForeignKey(c => c.Post_id)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(c => c.User)
                      .WithMany()
                      .HasForeignKey(c => c.User_id)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(c => c.ParentComment)
                      .WithMany(c => c.Replies)
                      .HasForeignKey(c => c.Parent_comment_id)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureFollows(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follower>()
                .HasKey(f => new { f.FollowerId, f.FollowedId });

            modelBuilder.Entity<Follower>()
                .HasOne(f => f.FollowerUser)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Follower>()
                .HasOne(f => f.FollowedUser)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowedId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigurePost(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(c => c.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(c => c.User_id)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}