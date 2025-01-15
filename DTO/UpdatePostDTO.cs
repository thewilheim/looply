using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using looply.Models;

namespace looply.DTO
{
    public class UpdatePostDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; } 
        public Privacy_Type Privacy { get; set; } = Privacy_Type.Public;
    }
}