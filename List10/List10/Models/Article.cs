using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace List10.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Too short name")]
        [MaxLength(30, ErrorMessage = "To long name, do not exceed {1}")]
        public string Name { get; set; }
        [Required]
        [Range(0, 5000)]
        public double Price { get; set; }
        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
