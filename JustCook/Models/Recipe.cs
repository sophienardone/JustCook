using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustCook.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "A title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot be more than 100 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "A description is required.")]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
