using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustCook.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required(ErrorMessage = "Rating value is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Value { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }

        public Recipe? Recipe { get; set; }
        public User? User { get; set; }
    }
}
