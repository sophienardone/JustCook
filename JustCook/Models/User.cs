using System.ComponentModel.DataAnnotations;

namespace JustCook.Models
{
    public class User
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(100, ErrorMessage = "Username cannot exceed 100 characters.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
