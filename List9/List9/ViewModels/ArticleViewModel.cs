using System;
using System.ComponentModel.DataAnnotations;

namespace List9.ViewModels
{
    public enum Category {Dairy, Meat, Sweets, Fruits, Vegetables, Others}
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Too long name, do not exceed {1}")]
        public string Name { get; set; }
        [Required]
        [Range(0, 5000)]
        public double Price { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }
        public Category Category { get; set; }
    }
}
