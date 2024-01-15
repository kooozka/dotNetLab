using Microsoft.AspNetCore.Http;

namespace Shop.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IFormFile FormFile { get; set; }
        public int CategoryId { get; set; }
    }
}
