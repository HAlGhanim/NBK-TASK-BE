using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Customer
    {
        [Required, Key, MaxLength(9)]
        public int Number { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required, StringLength(1)]
        public string Gender { get; set; }
    }
}
