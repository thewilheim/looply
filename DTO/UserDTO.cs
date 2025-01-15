using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace looply.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public string? Profile_picture_url { get; set; }
    }
}