using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using looply.Data;
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
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == new Guid(id));

            if (user != null)
            {
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

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}