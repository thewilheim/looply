using System.ComponentModel.DataAnnotations;
namespace looply.Models
{
    public class Favourite
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Post_id { get; set; }
        public required Post Post { get; set; }

        public Guid User_id { get; set; }
        public required User User { get; set; }
    }
}