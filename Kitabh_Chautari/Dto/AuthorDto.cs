namespace KitabhChautari.Maui.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AuthorDto
    {
        public int Author_id { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        [StringLength(100, ErrorMessage = "Author name cannot be longer than 100 characters")]
        public string Author_Name { get; set; } = string.Empty;
    }
}