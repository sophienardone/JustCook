using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JustCook.Models
{
    public class RecipeIngredient
    {
        [Key]
        public int RecipeId { get; set; }

        [Key]
        public int IngredientId { get; set; }

        public string? Quantity { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe? Recipe { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient? Ingredient { get; set; }
    }
}

