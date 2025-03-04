using System.ComponentModel.DataAnnotations;

namespace JustCook.Models
{
    public class User
    {
        [Key]
        public string? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}

