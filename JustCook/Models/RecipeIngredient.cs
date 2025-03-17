using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustCook.Models
{
    public class RecipeIngredient
    {
        // Composite keys are configured via Fluent API in DbContext.
        [Required(ErrorMessage = "Recipe Id is required.")]
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Ingredient Id is required.")]
        public int IngredientId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [MaxLength(50, ErrorMessage = "Quantity cannot exceed 50 characters.")]
        public string? Quantity { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe? Recipe { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient? Ingredient { get; set; }
    }
}
