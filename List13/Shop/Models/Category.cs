using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
