using looply.Models;
using Microsoft.AspNetCore.Mvc;

namespace looply.Services
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> DeleteUser(string id);
        Task<User> UpdateUser(User user);
        Task<User> Login(string email, string password);
        Task<User> GetUserById(string id);

    }
}