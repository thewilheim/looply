using looply.DTO;
using looply.Models;
using Microsoft.AspNetCore.Mvc;

namespace looply.Services
{
    public interface IUserService
    {
        Task<UserDTO> Register(User user);
        Task<UserDTO> DeleteUser(string id);
        Task<UserDTO> UpdateUser(User user);
        Task<UserDTO> Login(string email, string password);
        Task<UserDTO> GetUserById(string id);

        Task<int> Follow(Follower follower);
        Task<int> Unfollow(Follower follower);
        Task<List<UserDTO>> Followers(Guid user_id);
        Task<List<UserDTO>>  Following(Guid user_id);

    }
}