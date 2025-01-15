using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using looply.Data;
using looply.DTO;
using looply.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace looply.Services
{
    public class UserService : IUserService
    {

        private AppDbContext _appDbContext;
        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> DeleteUser(string id)
        {


            if (String.IsNullOrEmpty(id)) return null;
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == new Guid(id));
            if (user != null)
            {
                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();
            }
            return null;

        }

        public async Task<User> GetUserById(string id)
        {
            var user = await _appDbContext.Users.Include(u => u.Followers).Include(u => u.Followers).Include(u => u.Post_Likes).FirstOrDefaultAsync(u => u.Id == new Guid(id));

            if (user != null)
            {
                user.Followers = user.Followers.Where(f => f.FollowedId == user.Id).ToList();
                user.Following = user.Following.Where(f => f.FollowerId == user.Id).ToList();
                user.Post_Likes = user.Post_Likes.Where(p => p.User_id == user.Id).ToList();

                return user;
            }

            return null;
        }

        public Task<User> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User user)
        {
            if (user != null)
            {
                await _appDbContext.Users.AddAsync(user);
                await _appDbContext.SaveChangesAsync();
                return user;
            }

            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
            var existingUser = _appDbContext.Users.FirstOrDefault(u => u.Id == user.Id);

            if(existingUser == null) return null;

            existingUser.Username = user.Username;
            existingUser.Bio = user.Bio;
            existingUser.Profile_picture_url = user.Profile_picture_url;
            existingUser.Privacy = user.Privacy;

            await _appDbContext.SaveChangesAsync();

            return existingUser;
        }


        public async Task<int> Follow(Follower follower)
        {
            if(follower == null) return -1;

            _appDbContext.Follows.Add(follower);
            await _appDbContext.SaveChangesAsync();

            return 0;
        }
        public async Task<int> Unfollow(Follower follower)
        {
            if(follower == null) return -1;

            if (follower.FollowerId == Guid.Empty|| follower.FollowedId == Guid.Empty)
            {
                return -1;
            }

            var record = await _appDbContext.Follows.FirstOrDefaultAsync(x => x.FollowerId == follower.FollowerId && x.FollowedId == follower.FollowedId);
            if(record == null){
                return -1;
            }
            
            _appDbContext.Follows.Remove(record);
            await _appDbContext.SaveChangesAsync();
            
            return 0;
        }

        public async Task<List<UserDTO>> Followers(Guid user_id)
        {
        return await _appDbContext.Follows
                            .Where(x => x.FollowedId == user_id)
                            .Include(f => f.FollowerUser)
                            .Select(f => new UserDTO 
                            {
                                Id = f.FollowerUser.Id,
                                Username = f.FollowerUser.Username,
                                Profile_picture_url = f.FollowerUser.Profile_picture_url
                            })
                            .ToListAsync();
        }

        public async Task<List<UserDTO>> Following(Guid user_id)
        {
        return await _appDbContext.Follows
                            .Where(x => x.FollowerId == user_id)
                            .Include(f => f.FollowedUser)
                            .Select(f => new UserDTO 
                            {
                                Id = f.FollowedUser.Id,
                                Username = f.FollowedUser.Username,
                                Profile_picture_url = f.FollowedUser.Profile_picture_url
                            })
                            .ToListAsync();
        }
    }
}