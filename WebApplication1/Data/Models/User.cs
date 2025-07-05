using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
