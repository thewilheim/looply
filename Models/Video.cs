using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace looply.Models
{
    public class Video
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public required string Url { get; set; }
        public string? Thumbnail_url { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}