using System;
using System.ComponentModel.DataAnnotations;

namespace List9.ViewModels
{
    public enum Category 
    {
        Dairy, Meat, Sweets, Fruits, Vegetables, Others
    }
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = " To long name, do not exceed {1}")]
        public string Name { get; set; }
        [Required]
        [Range(0, 5000)]
        public double Price { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }
        public Category Category { get; set; }

        public ArticleViewModel() { }

        public ArticleViewModel(int id, string name, double price, DateTime expiryDate, Category category)
        {
            Id = id;
            Name = name;
            Price = price;
            ExpiryDate = expiryDate;
            Category = category;
        }
        public ArticleViewModel(string name, double price, DateTime expiryDate, Category category)
        {
            Name = name;
            Price = price;
            ExpiryDate = expiryDate;
            Category = category;
        }
    }
}
