using System.ComponentModel.DataAnnotations;

namespace JustCook.Models
{
    public class CookBook
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
    }
}
