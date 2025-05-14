using System.ComponentModel.DataAnnotations;

namespace KitabhChautari.Maui.Models
{
    public class BookDto
    {
        public int BookId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        [MaxLength(500)]
        public string CoverImageUrl { get; set; } = string.Empty;

        public bool IsOnSale { get; set; }

        public decimal? DiscountPercentage { get; set; }
    }
}