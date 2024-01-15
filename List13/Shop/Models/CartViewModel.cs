using System.Collections.Generic;

namespace Shop.Models
{
    public class CartViewModel
    {
        public Dictionary<Article, int> Articles { get; set; }
        public List<Category> Categories { get; set; }
        public double CartValue { get; set; }
    }
}
